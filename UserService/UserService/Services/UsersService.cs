using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FileSystemAppBackend.Services;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Data.Entities;

namespace UserService.Services
{
    public class UsersService : Users.UsersBase
    {
        private readonly ApplicationContext _db;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public UsersService(ApplicationContext db, JwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        private static string GetHashedPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var sByte in bytes)
                {
                    builder.Append(sByte.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public override async Task<UserInfoResponse> AddUser(AddNewUserRequest addNewUserRequest,
            ServerCallContext context)
        {
            if (string.IsNullOrEmpty(addNewUserRequest.Username) || string.IsNullOrEmpty(addNewUserRequest.Username) ||
                string.IsNullOrEmpty(addNewUserRequest.Username))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Some Request Arguments Are Null"));
            }

            var user = new User()
            {
                username = addNewUserRequest.Username,
                email = addNewUserRequest.Email,
                password = GetHashedPassword(addNewUserRequest.Password)
            };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return new UserInfoResponse()
            {
                Id = user.id,
                Username = user.username,
                Email = user.email
            };
        }
        [Authorize]
        public override async Task<UserInfoResponse> GetUserInfo(GetUserInfoRequest request, ServerCallContext context)
        {
            if (request.Id == 0)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "User Id Must Be Greater Then 0"));
            }

            var user = await _db.Users.FirstOrDefaultAsync(u => u.id == request.Id);
            if (user == null) throw new RpcException(new Status(StatusCode.NotFound, "User With This Id Not Exists"));

            return new UserInfoResponse()
            {
                Id = user.id,
                Username = user.username,
                Email = user.email
            };
        }

        public override async Task<UserSignInResponse> SingInUser(UserSignInRequest request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Some Request Arguments Are Null"));
            }

            var hashedPassword = GetHashedPassword(request.Password);
            var user = await _db.Users.FirstOrDefaultAsync(
                u => u.email == request.Email && u.password == hashedPassword);
            if (user == null) throw new RpcException(new Status(StatusCode.NotFound, "User With This Id Not Exists"));
            var claims = new List<Claim>
            {
                new Claim("id", user.id.ToString()),
                new Claim("userName", user.username!),
                new Claim("email", user.email!),
            };

            var jwtToken = _jwtTokenGenerator.GenerateJWTtoken(new List<Claim>(claims));
            return new UserSignInResponse()
            {
                Id = user.id,
                Username = user.username,
                Email = user.email,
                JwtToken = jwtToken
            };
        }
        public override async Task<UserExistsResponse> CheckUserExists(UserExistsRequest request, ServerCallContext context)
        {
            if (request.Id == 0)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Some Request Arguments Are Null"));
            }
            var result = await _db.Users.AnyAsync(u => u.id == request.Id);
            return new UserExistsResponse()
            {
                Found = result
            };
        }
    }
}
