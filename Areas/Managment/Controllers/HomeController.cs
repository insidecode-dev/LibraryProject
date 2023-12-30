using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Areas.Managment.Controllers
{
    [Area("Managment")]
    [Authorize(Policy = "AdminPolicy")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}

// 0559081919     10 842