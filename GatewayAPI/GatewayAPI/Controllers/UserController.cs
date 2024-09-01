using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService;

namespace GatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly Users.UsersClient _client;
        public UserController() 
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7005");
            _client = new Users.UsersClient(channel);
        }
        [HttpPost("SingIn")]
        public async Task<IActionResult> SignInUser([FromBody] UserSignInRequest request)
        {
            try
            {
                var response = await _client.SingInUserAsync(request, new Grpc.Core.Metadata());
                return Ok(response);
            } catch (RpcException ex)
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
        [HttpPut("SingUp")]
        public async Task<IActionResult> SignUpUser([FromBody] AddNewUserRequest request)
        {
            try
            {
                var response = await _client.AddUserAsync(request, new Grpc.Core.Metadata());
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
        [Authorize]
        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo(GetUserInfoRequest request)
        {
            try
            {
                var response = await _client.GetUserInfoAsync(request, new Grpc.Core.Metadata());
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
        [Authorize]
        [HttpGet("CheckUserExists")]
        public async Task<IActionResult> CheckUser(UserExistsRequest request)
        {
            try
            {
                var response = await _client.CheckUserExistsAsync(request, new Grpc.Core.Metadata());
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
