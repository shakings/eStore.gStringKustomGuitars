using Flurl;
using Flurl.Http;
using gStringKustomGuitars.Web.Controllers.Base;
using gStringKustomGuitars.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Web.Controllers
{
    public class CategoryController : BaseController
    {
        #region private variables
              
        private string _apiBaseUrl;
        private string _apiControllerName;
        private string _apiUri;
        
        #endregion

        #region ctor

        public CategoryController(IConfiguration configuration) : base(configuration)
        {         
            _apiBaseUrl = this.ApiBaseUrl;
            _apiControllerName = "/Categories/";
            _apiUri = string.Format("{0}{1}", _apiBaseUrl, _apiControllerName);
        }

        #endregion

        #region endpoints

        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_USER_SESSION_ID")))
                return RedirectToAction("Index", "Login");

            var categories = await _apiUri
                .AppendPathSegment("list")
                .GetJsonAsync<IEnumerable<CategoryModel>>();

            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _apiUri
                .AppendPathSegment("listBy")
               .SetQueryParam("id", value: id)
               .GetJsonAsync<CategoryModel>();
            
            return View(categories);
        }
          

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                CategoryModel category = new()
                {
                    name = collection["name"],
                    code = collection["code"]
                };

                await _apiUri
                   .AppendPathSegment("insert")
                   .PostJsonAsync(category);

                await AuditTraceAsync(Convert.ToInt32(HttpContext.Session.GetString("_USER_SESSION_ID")),
                   nameof(CategoryController), string.Format("category {0} have been created.", category.name));
            }          

            return RedirectToAction("Index", "Category");

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, [FromForm] CategoryModel category)
        {
            if (ModelState.IsValid)
            {              
                await _apiUri
                  .AppendPathSegment("update")
                  .PutJsonAsync(category);

                await AuditTraceAsync(Convert.ToInt32(HttpContext.Session.GetString("_USER_SESSION_ID")),
                nameof(CategoryController), string.Format("category {0} have been updated.", category.name));

                return RedirectToAction("Index", "Category");
            }

            return View("Edit", category);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

    }
}
