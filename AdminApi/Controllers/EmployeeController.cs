using DemoGrpcService;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly GrpcChannel _channel;
        private readonly EmployeeDetail.EmployeeDetailClient _client;
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _channel = GrpcChannel.ForAddress(_configuration.GetValue<string>("GrpcSettings:EmployeeServiceUrl"));
            _client = new EmployeeDetail.EmployeeDetailClient(_channel);
        }

        [HttpGet("getAllEmployees")]
        public GetAllResponse GetAllEmployees()
        {
            GetAllRequest request = new GetAllRequest();
            var response =  _client.GetAllEmployees(request);

            return response;
        }

        [HttpGet("getEmployeeById")]
        public GetResponse GetEmployeeById(string id)
        {
            GetRequest request = new GetRequest() { Id = id };
            var response = _client.GetEmployee(request);

            return response;
        }

        [HttpPost("createEmployee")]
        public CreateEmployeeResponse CreateEmployee(CreateEmployeeRequest request)
        {
            var response = _client.CreateEmployee(request);

            return response;
        }

        [HttpPut("updateEmployee")]
        public UpdateResponse UpdateEmployee(UpdateRequest request)
        {
            var response = _client.UpdateEmployee(request);

            return response;
        }

        [HttpDelete("deleteEmployee")]
        public DeleteResponse DeleteEmployee(DeleteRequest request)
        {
            var response = _client.DeleteEmployee(request);

            return response;
        }
    }
}
