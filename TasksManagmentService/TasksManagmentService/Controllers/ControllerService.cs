﻿using Grpc.Core;
using TasksManagmentService.HelperServices;
using TasksManagmentService.Services;

namespace TasksManagmentService.Controllers
{
    public class ControllerService : TaskManagementService.TaskManagementServiceBase
    {
        private readonly SpaceService _spaceService;
        private readonly TaskService _taskService;
        private readonly StatusService _statusService;
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
            var token = context.RequestHeaders
                .FirstOrDefault(header => header.Key == "authorization")?.Value.Split(" ").Last();
            return await _spaceService.CreateNewSpace(request, context, TokenParseService.ParseUserIdentity(token!));
        }

        public override async Task<GetSpaceInfoResponse> GetSpaceInfo(GetSpaceInfoRequest request, ServerCallContext context)
        {
            var token = context.RequestHeaders
                .FirstOrDefault(header => header.Key == "authorization")?.Value.Split(' ').Last();
            return await _spaceService.GetSpaceInfo(request, context,TokenParseService.ParseUserIdentity(token!));
        }

        public override async Task<GetAllSpaceStatusInfoResponse> GetSpaceStatusesInfo(GetAllSpaceStatusInfoRequest request, ServerCallContext context)
        {
            return await _statusService.GetSpaceStatusesInfo(request, context);
        }

        public override async Task<GetTaskInfoResponse> GetTaskInfo(GetTaskInfoRequest request, ServerCallContext context)
        {
            return await _taskService.GetTaskInfo(request, context);
        }

        public override async Task<RemoveTaskResponse> RemoveTask(RemoveTaskRequest request, ServerCallContext context)
        {
            return await _taskService.RemoveTask(request, context);
        }
        public override async Task<AddUserToSpaceResponse> AddUserToSpace(AddUserToSpaceRequest request, ServerCallContext context)
        {
            var token = context.RequestHeaders
                .FirstOrDefault(header => header.Key == "authorization")?.Value.Split(' ').Last();
            return await _spaceService.AddUserToSpace(request, context, TokenParseService.ParseUserIdentity(token!));
        }

        public override async Task<GetAllMySpacesRequestResponse> GetAllMySpaces(GetAllMySpacesRequest request, ServerCallContext context)
        {
            var token = context.RequestHeaders
                .FirstOrDefault(header => header.Key == "authorization")?.Value.Split(' ').Last();
            return await _spaceService.GetAllMySpaces(request, context, TokenParseService.ParseUserIdentity(token!));
        }
    }
}
