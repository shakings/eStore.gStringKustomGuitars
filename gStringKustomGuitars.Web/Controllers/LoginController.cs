using Flurl;
using Flurl.Http;
using gStringKustomGuitars.Web.Controllers.Base;
using gStringKustomGuitars.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Web.Controllers
{
    public class LoginController : BaseController
    {
        #region private variables

        private string _usrApiEndpoint;
        private string _logApiEndpoint;

        #endregion

        #region constructor

        public LoginController(IConfiguration configuration) : base(configuration)
        {
            _logApiEndpoint = this.ApiBaseUrl + "/Login/";
            _usrApiEndpoint = this.ApiBaseUrl + "/User/";
        }

        #endregion

        #region controller endpoint

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            var loginSession = await _logApiEndpoint
              .AppendPathSegment("auth")
              .PostJsonAsync(loginModel)
              .ReceiveJson<LoginModel>();

            if (loginSession != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                LoginModel login = new()
                {
                    name = collection["name"],
                    surname = collection["surname"],
                    email = collection["email"],
                    password = collection["password"]
                };

                await _usrApiEndpoint
                   .AppendPathSegment("insert")
                   .PostJsonAsync(login);
            }

            return RedirectToAction("Index", "Login");

        }

        #endregion
    }
}
