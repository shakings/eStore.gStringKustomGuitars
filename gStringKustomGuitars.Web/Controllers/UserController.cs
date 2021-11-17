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
    public class UserController : BaseController
    {

        #region private variables

        private string _apiBaseUrl;
        private string _apiControllerName;
        private string _apiUri;

        #endregion

        #region ctor

        public UserController(IConfiguration configuration) : base(configuration)
        {

            _apiBaseUrl = this.ApiBaseUrl;
            _apiControllerName = "/User/";
            _apiUri = string.Format("{0}{1}", _apiBaseUrl, _apiControllerName);
        }

        #endregion

        #region http endpoints

        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_USER_SESSION_ID")))
                return RedirectToAction("Index", "Login");

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

                await _apiUri
                   .AppendPathSegment("insert")
                   .PostJsonAsync(login);


                await AuditTraceAsync(Convert.ToInt32(HttpContext.Session.GetString("_USER_SESSION_ID")),
                   nameof(UserController), string.Format("new user {0} {1} have been created.", login.name, login.surname));
            }           

            return RedirectToAction("Index", "Login");

        }

        #endregion
    }
}
