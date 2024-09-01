using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using TasksManagmentService.Data;
using TasksManagmentService.Data.Entities;
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
        _client = new Users.UsersClient(GrpcChannel.ForAddress("https://localhost:7005"));
    }

    public async Task<CreateNewSpaceResponse> CreateNewSpace(CreateNewSpaceRequest request, ServerCallContext context)
    {
        if(string.IsNullOrEmpty(request.SpaceName) || request.CreatorUserId == 0)
            throw new RpcException(new Grpc.Core.Status(StatusCode.InvalidArgument, "InvalidArguments"));
        if((await _client.CheckUserExistsAsync(new UserExistsRequest(){ Id = request.CreatorUserId})).Found)
        {
            var space = new Space()
            {
                Name = request.SpaceName,
                creatorId = request.CreatorUserId,
                Statuses = _db.Statuses.Where(s => s.isDefault == true).ToList(),
                Tasks = new List<TaskAssignment>()
            };
            await _db.Spaces.AddAsync(space);
            await _db.SaveChangesAsync();
            await AddUserToSpace(new AddUserToSpaceRequest() { SpaceId = space.Id, UserId = space.creatorId }, context);
            return new CreateNewSpaceResponse()
            {
                NewSpaceId = space.Id
            };
        }
        throw new RpcException(new Grpc.Core.Status(StatusCode.NotFound,
            $"User With Id {request.CreatorUserId} Not Found"));
    }

    public async Task<GetSpaceInfoResponse> GetSpaceInfo(GetSpaceInfoRequest request, ServerCallContext context)
    {
        if (request.SpaceId == 0)
            throw new RpcException(new Grpc.Core.Status(StatusCode.InvalidArgument, "InvalidArguments"));
        var space = await _db.Spaces.FirstOrDefaultAsync(s => s.Id == request.SpaceId);
        if(space == null)
            throw new RpcException(new Grpc.Core.Status(StatusCode.NotFound,
            $"Space With Id {request.SpaceId} Not Found"));
        var tasksResponse = space.Tasks != null ? space.Tasks.Select(task => new GetTaskInfoResponse()
        {
            TaskName = task.Name,
            TaskDescription = task.Description,
            StatusId = task.StatusId,
            TaskId = task.Id,
            SpaceId = task.SpaceId
        }).ToList() : new List<GetTaskInfoResponse>();
        var StatusesResponse = space.Statuses != null ? space.Statuses.Select(status => new GetStatusInfoResponse()
        {
            StatusId = status.Id,
            StatusName = status.Name
        }).ToList() : new List<GetStatusInfoResponse>();
        return new GetSpaceInfoResponse()
        {
            SpaceId = space.Id,
            SpaceName = space.Name,
            CreatorUserId = space.creatorId,
            Tasks = { tasksResponse },
            Statuses = { StatusesResponse }
        };
    }
    public async Task<AddUserToSpaceResponse> AddUserToSpace(AddUserToSpaceRequest request, ServerCallContext context)
    {
        if (request.SpaceId == 0 || request.UserId == 0)
            throw new RpcException(new Grpc.Core.Status(StatusCode.InvalidArgument, "InvalidArguments"));
        if(_db.Spaces.Any(s => s.Id == request.SpaceId) 
            && _client.CheckUserExists(new UserExistsRequest() { Id = request.UserId }).Found)
        {
            var userToSpace = new UserSpaces()
            {
                SpaceId = request.SpaceId,
                UserId = request.UserId
            };
            if(_db.Spaces.FirstOrDefault(s => s.Id == userToSpace.SpaceId)!.creatorId == userToSpace.UserId)
            {
                userToSpace.Role = "admin";
            }
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
}