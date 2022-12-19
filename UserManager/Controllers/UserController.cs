using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManager.Models;
using UserManager.Services;

namespace UserManager.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    [Consumes("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IRequestWriterService _requestWriterService;
        private readonly IDataConversionService _dataConversionService;
        private readonly ILogger<RequestWriterService> _logger;
        public UserController(IRequestWriterService requestWriterService, 
            IDataConversionService dataConversionService, 
            ILogger<RequestWriterService> logger)
        {
            _requestWriterService = requestWriterService;
            _dataConversionService = dataConversionService;
            _logger = logger;
        }
        [HttpPost]
        public ActionResult CreateUser(RequestModel request)
        {
            try
            {
                _logger.LogInformation("Received Request {Request}", request);
                _requestWriterService.WriteRequest(_dataConversionService.ConvertRequestToUserModel(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred: {ErrorMessage} \n {StackTrace}", ex.Message, ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }
    }
}
