using Microsoft.AspNetCore.Mvc;

namespace UserManager.Web.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PingController : Controller
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok($"Ping {DateTime.Now:f}");
        }
    }
}
