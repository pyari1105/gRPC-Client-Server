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
        public GetAllResponse GetOfferListAsync()
        {
            GetAllRequest request = new GetAllRequest();
            var response =  _client.GetAllEmployees(request);

            return response;
        }
    }
}
