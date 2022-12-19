using Microsoft.AspNetCore.Mvc;
using UserManager.Models;
using UserManager.Models.Extensions;
using UserManager.Services;

namespace UserManager.Web.Controllers
{
    [ApiController, Route("api/[controller]")]
    [Consumes("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IRequestWriterService _requestWriterService;
        private readonly ILogger<RequestWriterService> _logger;
        public UserController(IRequestWriterService requestWriterService, 
            ILogger<RequestWriterService> logger)
        {
            _requestWriterService = requestWriterService;
            _logger = logger;
        }
        [HttpPost]
        public ActionResult CreateUser(RequestModel request)
        {
            try
            {
                _logger.LogInformation("Received Request {Request}", request);
                _requestWriterService.WriteRequest(request.Map());
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
