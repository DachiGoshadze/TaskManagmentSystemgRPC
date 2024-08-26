using System.Security.Cryptography;
using System.Text;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Data.Entities;

namespace UserService.Services
{
    public class UsersService : Users.UsersBase
    {
        private readonly ApplicationContext _db;
        public UsersService(ApplicationContext db)
        {
            _db = db;
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
        public override async Task<UserInfoResponse> AddUser(AddNewUserRequest addNewUserRequest, ServerCallContext context)
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
                Id = user.id.ToString(),
                Username = user.username,
                Email = user.email
            };
        }

        public override async Task<UserInfoResponse> GetUserInfo(GetUserInfoRequest request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.Id))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Some Request Arguments Are Null"));
            }

            var user = await _db.Users.FirstOrDefaultAsync(u => u.id.ToString() == request.Id);
            if(user == null) throw new RpcException(new Status(StatusCode.NotFound, "User With This Id Not Exists"));
            
            return new UserInfoResponse()
            {
                Id = user.id.ToString(),
                Username = user.username,
                Email = user.email
            };
        }
    }
}
