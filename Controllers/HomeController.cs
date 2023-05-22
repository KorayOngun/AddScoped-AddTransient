using IoCTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IoCTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScopedGuid scopedGuid;
        private readonly IScopedGuid scopedGuid2;
        private readonly ITransientGuid transientGuid;
        private readonly ITransientGuid transientGuid2;

        public HomeController(ILogger<HomeController> logger,IScopedGuid s1, IScopedGuid s2, ITransientGuid t1, ITransientGuid t2)
        {
            _logger = logger;
            scopedGuid = s1;
            scopedGuid2 = s2; // s1 == s2 

            transientGuid = t1;
            transientGuid2 = t2; // t1!=t2
        }

        public IActionResult Index()
        {
            ViewBag.ScopedGuid = scopedGuid.Guid; 
            ViewBag.ScopedGuid2 = scopedGuid2.Guid; // scopeGuid.Guid == scopeGuid2.Guid 

            ViewBag.TransientGuid = transientGuid.Guid;
            ViewBag.TransientGuid2 = transientGuid2.Guid; // transientGuid.Guid != transientGuid2.Guid 

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}