using GatewayAPI.HelperServices;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasksManagmentService;

namespace GatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SpacesController : Controller
    {
        private readonly TaskManagementService.TaskManagementServiceClient _client;
        public SpacesController(GrpcConnectorService grpcConnectorService)
        {
            _client = grpcConnectorService.GetTaskManagmentServiceConnection();
        }
        [HttpPost("CreateSpace")]
        public async Task<IActionResult> CreateSpace([FromBody] CreateNewSpaceRequest request)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString();
                var metadata = new Metadata
                {
                    { "Authorization", token }
                };
                var response = await _client.CreateNewSpaceAsync(request, metadata);
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
        [HttpGet("GetSpaceInfo")]
        public async Task<IActionResult> GetSpaceInfo([FromQuery] GetSpaceInfoRequest request)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString();
                var metadata = new Metadata
                {
                    { "Authorization", token }
                };
                var response = await _client.GetSpaceInfoAsync(request, metadata);
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
        [HttpGet("AddUserToSpace")]
        public async Task<IActionResult> AddUserToSpace(AddUserToSpaceRequest request)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString();
                var metadata = new Metadata
                {
                    { "Authorization", token }
                };
                var response = await _client.AddUserToSpaceAsync(request, metadata);
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
