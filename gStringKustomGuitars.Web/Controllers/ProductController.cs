using Flurl;
using Flurl.Http;
using gStringKustomGuitars.Web.Controllers.Base;
using gStringKustomGuitars.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Web.Controllers
{
    public class ProductController : BaseController
    {
        #region private variables

        private string _apiBaseUrl;
        private string _apiControllerName;
        private string _apiUri;

        #endregion

        #region ctor

        public ProductController(IConfiguration configuration) : base(configuration)
        {
            _apiBaseUrl = this.ApiBaseUrl;
            _apiControllerName = "/Product/";
            _apiUri = string.Format("{0}{1}", _apiBaseUrl, _apiControllerName);
        }

        #endregion

        #region endpoints

        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_USER_SESSION_ID")))
                return RedirectToAction("Index", "Login");

            var product = await _apiUri
              .AppendPathSegment("list")
              .GetJsonAsync<IEnumerable<ProductModel>>();

            return View(product);
        }

        public async Task<ActionResult> CreateAsync()
        {            
            _apiControllerName = "/Categories/";
            _apiUri = string.Format("{0}{1}", _apiBaseUrl, _apiControllerName);
           
            var categoriesModels = await _apiUri
              .AppendPathSegment("list")
              .GetJsonAsync<IEnumerable<CategoryModel>>();

            CategorySelectListItem(categoriesModels);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([FromForm] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var stream = product.UploadFile.OpenReadStream();
                byte[] bytes;
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                }

                Random rnd = new();
                int number = rnd.Next(1, 100);
                product.code = string.Format("{0:yyyyMM}-{1}", DateTime.Now, number);
                product.image = Convert.ToBase64String(bytes, 0, bytes.Length);

                var result = await _apiUri
                   .AppendPathSegment("insert")
                   .PostJsonAsync(new
                   {
                       product.categoryId,
                       product.code,
                       product.description,
                       product.id,
                       product.name,
                       product.price,
                       product.image
                   });
            }

            await AuditTraceAsync(Convert.ToInt32(HttpContext.Session.GetString("_USER_SESSION_ID")),
                nameof(ProductController), string.Format("product {0} have been created.", product.name));

            return RedirectToAction("Index", "Product");

        }

        public async Task<IActionResult> Edit(int id)
        {
            _apiControllerName = "/Categories/";
            _apiUri = string.Format("{0}{1}", _apiBaseUrl, _apiControllerName);
          
            var categoriesModels = await _apiUri
               .AppendPathSegment("list")
               .GetJsonAsync<IEnumerable<CategoryModel>>();

            var categorySelectListItem 
                = CategorySelectListItem(categoriesModels);

            var category = await _apiUri
                 .AppendPathSegment("listBy")
                 .SetQueryParam("id", value: id)
                 .GetJsonAsync<ProductModel>();

            categorySelectListItem.FirstOrDefault(cat => cat.Value
               == category.categoryId.ToString()).Selected = true;

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, [FromForm] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                await _apiUri
                  .AppendPathSegment("update")
                  .PutJsonAsync(product);

                await AuditTraceAsync(Convert.ToInt32(HttpContext.Session.GetString("_USER_SESSION_ID")),
                   nameof(ProductController), string.Format("product {0} have been updated.", product.name));
                
                return RedirectToAction("Index", "Category");
            }
            return View("Edit", product);

        }

        public async Task<IActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                await _apiUri
                     .AppendPathSegment("delete")
                     .PatchJsonAsync(new ProductModel
                     {
                         id = id
                     });

             await AuditTraceAsync(Convert.ToInt32(HttpContext.Session.GetString("_USER_SESSION_ID")),
                nameof(ProductController), string.Format("product have been deleted."));
            }

            return RedirectToAction("Index", "Product");
        }


        #region import & export

        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuilkImportAsync(IFormFile fileUpload)
        {
            if (fileUpload == null)
                throw new Exception("File not avalible");

            if (fileUpload.FileName.EndsWith(".csv"))
            {
                using var sreader = new StreamReader(fileUpload.OpenReadStream());
                string[] headers = sreader.ReadLine().Split(',');
                while (!sreader.EndOfStream)
                {
                    var product = new ProductModel();
                    string[] rows = sreader.ReadLine().Split(',');

                    product.categoryId = int.Parse(rows[0].ToString());
                    product.id = int.Parse(rows[1].ToString());
                    product.code = rows[2].ToString();
                    product.name = rows[3].ToString();
                    product.description = rows[4].ToString();
                    product.price = rows[5].ToString();
                    product.image = rows[6].ToString();

                    await _apiUri
                        .AppendPathSegment("insert")
                        .PostJsonAsync(new
                        {
                            product.categoryId,
                            product.code,
                            product.description,
                            product.id,
                            product.name,
                            product.price,
                            product.image
                        });
                }

                await AuditTraceAsync(Convert.ToInt32(HttpContext.Session.GetString("_USER_SESSION_ID")),
                 nameof(ProductController), "products have been exported.");
            }

            return null;

        }

        public async Task<IActionResult> ExportAsync()
        {
            var products = await _apiUri
              .AppendPathSegment("list")
              .GetJsonAsync<IEnumerable<ProductModel>>();

            Random rnd = new();
            int number = rnd.Next(1, 100);
            string fileName = string.Format("{0:yyyyMMdd}-{1}.{2}", DateTime.Now, number, ".csv");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("categoryId, productId, productCode, productName, productDescription, productPrice, productImage");
            sb.Append("\r\n");

            foreach (var product in products)
            {
                sb.Append(product.categoryId + ','
                        + product.id + ','
                        + product.code + ','
                        + product.name + ','
                        + product.description + ','
                        + product.price + ','
                        + product.image);


                sb.Append("\r\n");

            }

            await AuditTraceAsync(Convert.ToInt32(HttpContext.Session.GetString("_USER_SESSION_ID")),
                 nameof(ProductController), "products have been imported.");

            return File(System.Text.Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", fileName);
        }

        #endregion

        #endregion

        #region private methods

        private List<SelectListItem> CategorySelectListItem(IEnumerable<CategoryModel> categoryModels) {

            List<SelectListItem> categories = new();
            foreach ((CategoryModel item, SelectListItem selectListItem) in
                from item in categoryModels.Where(cat => cat.isactive == true)
                let selectListItem = new SelectListItem()
                select (item, selectListItem))
            {
                selectListItem.Value = item.id.ToString();
                selectListItem.Text = item.name;
                categories.Add(selectListItem);
            }

            ViewBag.CategoriesLookup = categories;

            return categories;
        }

        #endregion 
    }

}
