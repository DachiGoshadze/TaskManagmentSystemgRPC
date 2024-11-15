using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using TasksManagmentService.Data;
using TasksManagmentService.Data.Entities;
using TasksManagmentService.Models;
using UserService;

namespace TasksManagmentService.Services;

public class SpaceService
{
    private readonly ApplicationContext _db;
    private readonly StatusService _statusService;
    private readonly TaskService _taskService;
    private readonly Users.UsersClient _client;

    public SpaceService(ApplicationContext db, StatusService statusService, TaskService taskService)
    {
        _db = db;
        _taskService = taskService;
        _statusService = statusService;
        _client = new Users.UsersClient(GrpcChannel.ForAddress("http://localhost:5194"));
    }

    public async Task<CreateNewSpaceResponse> CreateNewSpace(CreateNewSpaceRequest request, ServerCallContext context,
        UserIdentity user)
    {
        if (string.IsNullOrEmpty(request.SpaceName))
            throw new RpcException(new Grpc.Core.Status(StatusCode.InvalidArgument, "InvalidArguments"));
        if ((await _client.CheckUserExistsAsync(new UserExistsRequest() { Id = int.Parse(user.user_id) })).Found)
        {
            var space = new Space()
            {
                Name = request.SpaceName,
                creatorId = int.Parse(user.user_id),
                Statuses = _db.Statuses.Where(s => s.isDefault == true).ToList(),
                Tasks = new List<TaskAssignment>()
            };
            await _db.Spaces.AddAsync(space);
            await _db.SaveChangesAsync();
            await AddUserToSpace(new AddUserToSpaceRequest() { SpaceId = space.Id, UserId = int.Parse(user.user_id) },
                context, user);
            return new CreateNewSpaceResponse()
            {
                NewSpaceId = space.Id
            };
        }

        throw new RpcException(new Grpc.Core.Status(StatusCode.NotFound,
            $"User {user.user_id} not found."));
    }

    public async Task<GetSpaceInfoResponse> GetSpaceInfo(GetSpaceInfoRequest request, ServerCallContext context,
        UserIdentity user)
    {
        if (request.SpaceId == 0)
            throw new RpcException(new Grpc.Core.Status(StatusCode.InvalidArgument, "InvalidArguments"));
        var space = await _db.Spaces.Include(s => s.Tasks).Include(s => s.Statuses).FirstOrDefaultAsync(s => s.Id == request.SpaceId);
        if (space == null)
            throw new RpcException(new Grpc.Core.Status(StatusCode.NotFound,
                $"Space With Id {request.SpaceId} Not Found"));
        var tasksResponse = space.Tasks != null
            ? space.Tasks.Select(task => new GetTaskInfoResponse()
            {
                TaskName = task.Name,
                TaskDescription = task.Description,
                StatusId = task.StatusId,
                TaskId = task.Id,
                SpaceId = task.Space.Id
            }).ToList()
            : new List<GetTaskInfoResponse>();
        var statusesResponse = space.Statuses.Select(status => new GetStatusInfoResponse()
        {
            StatusId = status.Id,
            StatusName = status.Name
        }).ToList();
        return new GetSpaceInfoResponse()
        {
            SpaceId = space.Id,
            SpaceName = space.Name,
            CreatorUserId = space.creatorId,
            Tasks = { tasksResponse },
            Statuses = { statusesResponse }
        };
    }

    public async Task<AddUserToSpaceResponse> AddUserToSpace(AddUserToSpaceRequest request, ServerCallContext context,
        UserIdentity user)
    {
        if (request.SpaceId == 0 || request.UserId == 0)
            throw new RpcException(new Grpc.Core.Status(StatusCode.InvalidArgument, "InvalidArguments"));
        if (_db.Spaces.Any(s => s.Id == request.SpaceId)
            && _client.CheckUserExists(new UserExistsRequest() { Id = request.UserId }).Found &&
            _db.Spaces.FirstOrDefault(s => s.Id == request.SpaceId).creatorId == int.Parse(user.user_id))
        {
            var userToSpace = new UserSpaces()
            {
                SpaceId = request.SpaceId,
                UserId = request.UserId
            };
            await _db.UserSpaces.AddAsync(userToSpace);
            await _db.SaveChangesAsync();
            return new AddUserToSpaceResponse()
            {
                Result = true
            };
        }

        throw new RpcException(new Grpc.Core.Status(StatusCode.NotFound,
            $"Space With Id {request.SpaceId} or User with Id {request.UserId} Not Found"));
    }

    public async Task<GetAllMySpacesRequestResponse> GetAllMySpaces(GetAllMySpacesRequest request,
        ServerCallContext context, UserIdentity user)
    {
        var spacesIndexes = _db.Spaces.Where(s =>
            s.creatorId == int.Parse(user.user_id) || _db.UserSpaces.Where(u => u.UserId.Equals(user.user_id))
                .Select(t => t.SpaceId).Contains(s.Id)).Select(s => s.Id).ToList();
        var spaces = new GetAllMySpacesRequestResponse();
        foreach(var ind in spacesIndexes)
        {
            spaces.Spaces.Add(await GetSpaceInfo(request: new GetSpaceInfoRequest() { SpaceId = ind }, context: context, user: user));
        }

        return spaces;
    }
}