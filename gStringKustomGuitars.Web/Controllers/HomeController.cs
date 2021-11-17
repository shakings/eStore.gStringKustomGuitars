using gStringKustomGuitars.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace gStringKustomGuitars.Web.Controllers
{
    public class HomeController : Controller
    {
        #region ctor

        public HomeController() { }

        #endregion

        #region endpoints

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_USER_SESSION_ID")))
              return RedirectToAction("Index", "Login");
                       
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

        #endregion
    }
}
