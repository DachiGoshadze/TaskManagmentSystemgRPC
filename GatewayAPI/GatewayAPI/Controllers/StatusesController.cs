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
    public class StatusesController : Controller
    {
        private readonly TaskManagementService.TaskManagementServiceClient _client;
        public StatusesController(GrpcConnectorService grpcConnectorService)
        {
            _client = grpcConnectorService.GetTaskManagmentServiceConnection();
        }
        [HttpGet("GetSpaceStatusesInfo")]
        public async Task<IActionResult> GetSpaceStatusesInfo([FromQuery] GetAllSpaceStatusInfoRequest request)
        {
            try
            {
                var response = await _client.GetSpaceStatusesInfoAsync(request, new Metadata { });
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
        [HttpPost("AddNewStatus")]
        public async Task<IActionResult> AddNewStatus(AddStatusRequest request)
        {
            try
            {
                var response = await _client.AddNewStatusAsync(request, new Metadata { });
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
        [HttpPost("AddDefaultStatus")]
        public async Task<IActionResult> AddDefaultStatus(AddDefaultStatusRequest request)
        {
            try
            {
                var response = await _client.AddDefaultStatusAsync(request, new Metadata { });
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
