using Microsoft.AspNetCore.Mvc;

namespace TASKWAVE.API.Controllers
{
    public class AmbienteController : Controller
    {
        [HttpGet ("/ambiente")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
