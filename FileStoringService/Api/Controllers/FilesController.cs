using Microsoft.AspNetCore.Mvc;

namespace FileStoringService.Api.Controllers
{
    public class FilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
