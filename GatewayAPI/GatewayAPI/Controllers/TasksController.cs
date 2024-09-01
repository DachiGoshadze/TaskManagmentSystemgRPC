using GatewayAPI.HelperServices;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasksManagmentService;
using UserService;

namespace GatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : Controller
    {
        private readonly TaskManagementService.TaskManagementServiceClient _client;
        public TasksController(GrpcConnectorService grpcConnectorService)
        {
            _client = grpcConnectorService.GetTaskManagmentServiceConnection();
        }
        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateSpace([FromBody] AddNewTaskRequest request)
        {
            try
            {
                var response = await _client.AddNewTaskAsync(request, new Metadata { });
                return Ok(response);
            }
            catch (RpcException ex)
            {
                return ex.StatusCode switch
                {
                    Grpc.Core.StatusCode.NotFound => NotFound(ex.Status.Detail),
                    Grpc.Core.StatusCode.Unauthenticated => Unauthorized(ex.Status.Detail),
                    Grpc.Core.StatusCode.InvalidArgument => BadRequest(ex.Status.Detail),
                    _ => StatusCode((int)ex.StatusCode, ex.Status.Detail)
                };
            }
        }
        [HttpGet("GetTaskInfo")]
        public async Task<IActionResult> GetTaskInfo(GetTaskInfoRequest request)
        {
            try
            {
                var response = await _client.GetTaskInfoAsync(request, new Metadata { });
                return Ok(response);
            }
            catch (RpcException ex)
            {
                return ex.StatusCode switch
                {
                    Grpc.Core.StatusCode.NotFound => NotFound(ex.Status.Detail),
                    Grpc.Core.StatusCode.Unauthenticated => Unauthorized(ex.Status.Detail),
                    Grpc.Core.StatusCode.InvalidArgument => BadRequest(ex.Status.Detail),
                    _ => StatusCode((int)ex.StatusCode, ex.Status.Detail)
                };
            }
        }
        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(RemoveTaskRequest request)
        {
            try
            {
                var response = await _client.RemoveTaskAsync(request, new Metadata { });
                return Ok(response);
            }
            catch (RpcException ex)
            {
                return ex.StatusCode switch
                {
                    Grpc.Core.StatusCode.NotFound => NotFound(ex.Status.Detail),
                    Grpc.Core.StatusCode.Unauthenticated => Unauthorized(ex.Status.Detail),
                    Grpc.Core.StatusCode.InvalidArgument => BadRequest(ex.Status.Detail),
                    _ => StatusCode((int)ex.StatusCode, ex.Status.Detail)
                };
            }
        }
    }
}
