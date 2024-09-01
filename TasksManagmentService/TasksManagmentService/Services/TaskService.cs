using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using TasksManagmentService.Data;
using TasksManagmentService.Data.Entities;

namespace TasksManagmentService.Services;

public class TaskService
{
    private readonly ApplicationContext _db;
    private readonly StatusService _statusService;
    public TaskService(ApplicationContext db, StatusService statusService)
    {
        _db = db;
        _statusService = statusService;
    }

    public async Task<AddNewTaskResponse> AddNewTask(AddNewTaskRequest request, ServerCallContext context)
    {
        if (string.IsNullOrEmpty(request.TaskTitle) || request.SpaceId == 0)
        {
            throw new RpcException(new Grpc.Core.Status(StatusCode.InvalidArgument, "InvalidArguments"));
        }

        if (!await _db.Spaces.AnyAsync(s => s.Id == request.SpaceId))
            throw new RpcException(new Grpc.Core.Status(StatusCode.NotFound,
                $"Space With Id {request.SpaceId} Not Found"));
        if (!await _db.Statuses.AnyAsync(s => s.Id == request.StatusId))
            throw new RpcException(new Grpc.Core.Status(StatusCode.NotFound,
                $"Status With Id {request.SpaceId} Not Found"));
        var newTask = new TaskAssignment()
        {
            Name = request.TaskTitle,
            Description = request.TaskDescription,
            StatusId = request.StatusId,
            SpaceId = request.SpaceId
        };
        await _db.Tasks.AddAsync(newTask);
        await _db.SaveChangesAsync();
        return new AddNewTaskResponse()
        {
            SpaceId = newTask.SpaceId,
            StatusId = newTask.StatusId,
            TaskDescription = newTask.Description,
            TaskTitle = newTask.Name
        };
    }

    public async Task<GetTaskInfoResponse> GetTaskInfo(GetTaskInfoRequest request, ServerCallContext context)
    {
        if (request.TaskId == 0)
        {
            throw new RpcException(new Grpc.Core.Status(StatusCode.InvalidArgument, "InvalidArguments"));
        }

        var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == request.TaskId);
        if(task == null) throw new RpcException(new Grpc.Core.Status(StatusCode.NotFound, $"Task With Id {request.TaskId} Not Found"));
        return new GetTaskInfoResponse()
        {
            TaskName = task.Name,
            TaskDescription = task.Description,
            StatusId = task.StatusId,
            TaskId = task.Id,
            SpaceId = task.SpaceId
        };
    }

    public  Task<RemoveTaskResponse> RemoveTask(RemoveTaskRequest request, ServerCallContext context)
    {
        return Task.FromResult(new RemoveTaskResponse() { Result = false });
    }
}