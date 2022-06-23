using Microsoft.AspNetCore.Mvc;

namespace PigeonPizza.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Example(int? id)
        {
            return Content($"Index Example - {id.ToString()}");
        }
    }
}
