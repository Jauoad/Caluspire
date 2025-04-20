using Microsoft.AspNetCore.Mvc;

namespace Caluspire.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/home
        [HttpGet]
        public IActionResult GetMessage()
        {
            var message = "Welcome to Caluspire, your job platform !";
            return Ok(new { message });
        }
    }
}
