using Flurl;
using Flurl.Http;
using gStringKustomGuitars.Web.Controllers.Base;
using gStringKustomGuitars.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Web.Controllers
{
    public class LoginController : BaseController
    {
        #region private variables

        private string _apiBaseUrl;
        private string _apiControllerName;
        private string _apiUri;

        #endregion

        #region ctor

        public LoginController(IConfiguration configuration) : base(configuration)
        {
            _apiBaseUrl = this.ApiBaseUrl;
            _apiControllerName = "/Login/";
            _apiUri = string.Format("{0}{1}", _apiBaseUrl, _apiControllerName);
        }

        #endregion

        #region endpoint

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            var loginSession = await _apiUri
              .AppendPathSegment("auth")
              .PostJsonAsync(loginModel)
              .ReceiveJson<LoginModel>();

            if (loginSession != null)
            {
                HttpContext.Session.SetString("_USER_SESSION_ID", loginSession.id.ToString());
              
                await AuditTraceAsync(loginSession.id,
                    nameof(LoginController),
                    string.Format("User :{0} have succesfully logged in.",
                    loginSession.email));
               
                return RedirectToAction("Index", "Home");
            }
            else {

                await AuditTraceAsync(loginSession.id,
                    nameof(LoginController),
                    string.Format("User :{0} have NOT succesfully logged in.",
                    loginSession.email));
            }

            return View();
        }
       

        #endregion
    }
}
