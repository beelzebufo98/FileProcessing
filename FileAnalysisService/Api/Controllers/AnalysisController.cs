using Microsoft.AspNetCore.Mvc;

namespace FileAnalysisService.Api.Controllers
{
    public class AnalysisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
