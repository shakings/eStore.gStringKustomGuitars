using Flurl;
using Flurl.Http;
using gStringKustomGuitars.Web.Controllers.Base;
using gStringKustomGuitars.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Web.Controllers
{
    public class CategoryController : BaseController
    {
        #region private variables

        private string _catApiEndpoint;

        #endregion

        #region constructor

        public CategoryController(IConfiguration configuration) : base(configuration)
        {
            _catApiEndpoint = this.ApiBaseUrl + "/Categories/";
        }

        #endregion

        #region controller endpoints

        public async Task<IActionResult> Index()
        {
            var categories = await _catApiEndpoint
                .AppendPathSegment("list")
                .GetJsonAsync<IEnumerable<CategoryModel>>();

            return View(categories);
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
                CategoryModel category = new()
                {
                    name = collection["name"],
                    code = collection["code"]
                };

                await _catApiEndpoint
                   .AppendPathSegment("insert")
                   .PostJsonAsync(category);
            }

            return RedirectToAction("Index", "Category");

        }

        public async Task<IActionResult> Edit(int id)
        {
            var apiUrl = this.ApiBaseUrl + "/Categories/";
            var categories = await apiUrl
                .AppendPathSegment("listBy")
               .SetQueryParam("id", value: id)
               .GetJsonAsync<CategoryModel>();

            return View(categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, [FromForm] CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                await _catApiEndpoint
                  .AppendPathSegment("update")
                  .PutJsonAsync(category);

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
