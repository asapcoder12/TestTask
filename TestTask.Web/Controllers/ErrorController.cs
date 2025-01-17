using Microsoft.AspNetCore.Mvc;

namespace TestTask.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
