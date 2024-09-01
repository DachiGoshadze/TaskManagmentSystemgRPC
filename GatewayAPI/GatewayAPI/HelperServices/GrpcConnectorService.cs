using Grpc.Net.Client;
using TasksManagmentService;
using UserService;

namespace GatewayAPI.HelperServices
{
    public class GrpcConnectorService
    {
        private readonly IConfiguration _configuration;
        public GrpcConnectorService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public Users.UsersClient GetUserServiceConnection()
        {
            try
            {
                var channel = GrpcChannel.ForAddress(_configuration["GrpcServices:UserService"]);
                var _client = new Users.UsersClient(channel);
                return _client;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Connection With UserService Is Unavalable");
            }
        }
        public TaskManagementService.TaskManagementServiceClient GetTaskManagmentServiceConnection()
        {
            try
            {
                var channel = GrpcChannel.ForAddress(_configuration["GrpcServices:TaskManagmentService"]);
                var _client = new TaskManagementService.TaskManagementServiceClient(channel);
                return _client;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Connection With TaskManagmentService Is Unavalable");
            }
        }
    }
}
