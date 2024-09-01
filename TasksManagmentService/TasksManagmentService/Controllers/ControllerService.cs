using Grpc.Core;
using TasksManagmentService.Services;

namespace TasksManagmentService.Controllers
{
    public class ControllerService : TaskManagementService.TaskManagementServiceBase
    {
        public readonly SpaceService _spaceService;
        public readonly TaskService _taskService;
        public readonly StatusService _statusService;
        public ControllerService(SpaceService spaceService, TaskService taskService, StatusService statusService)
        {
            _spaceService = spaceService;
            _taskService = taskService;
            _statusService = statusService;
        }
        public override async Task<AddDefaultStatusResponse> AddDefaultStatus(AddDefaultStatusRequest request, ServerCallContext context)
        {
            return await _statusService.AddDefaultStatus(request , context);
        }

        public override async Task<AddStatusResponse> AddNewStatus(AddStatusRequest request, ServerCallContext context)
        {
            return await _statusService.AddNewStatus(request, context);
        }

        public override async Task<AddNewTaskResponse> AddNewTask(AddNewTaskRequest request, ServerCallContext context)
        {
            return await _taskService.AddNewTask(request, context);
        }

        public override async Task<CreateNewSpaceResponse> CreateNewSpace(CreateNewSpaceRequest request, ServerCallContext context)
        {
            return await _spaceService.CreateNewSpace(request, context);
        }

        public override async Task<GetSpaceInfoResponse> GetSpaceInfo(GetSpaceInfoRequest request, ServerCallContext context)
        {
            return await _spaceService.GetSpaceInfo(request, context);
        }

        public override async Task<GetStatusInfoResponse> GetStatusInfo(GetStatusInfoRequest request, ServerCallContext context)
        {
            return await _statusService.GetStatusInfo(request, context);
        }

        public override async Task<GetTaskInfoResponse> GetTaskInfo(GetTaskInfoRequest request, ServerCallContext context)
        {
            return await _taskService.GetTaskInfo(request, context);
        }

        public override async Task<RemoveTaskResponse> RemoveTask(RemoveTaskRequest request, ServerCallContext context)
        {
            return await _taskService.RemoveTask(request, context);
        }
    }
}
