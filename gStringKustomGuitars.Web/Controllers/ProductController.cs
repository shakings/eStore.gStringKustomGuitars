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

        private string _prdApiEnpoint;
        private string _catApiEndpoint;

        #endregion

        #region constructor

        public ProductController(IConfiguration configuration) : base(configuration)
        {
            _prdApiEnpoint = ApiBaseUrl + "/Product/";
            _catApiEndpoint = ApiBaseUrl + "/Categories/";
        }

        #endregion

        #region controller endpoints

        public async Task<IActionResult> Index()
        {
            var product = await _prdApiEnpoint
              .AppendPathSegment("list")
              .GetJsonAsync<IEnumerable<ProductModel>>();

            return View(product);
        }

        public async Task<ActionResult> CreateAsync()
        {
            var categoriesModels = await _catApiEndpoint
              .AppendPathSegment("list")
              .GetJsonAsync<IEnumerable<CategoryModel>>();           

            List<SelectListItem> categories = new();
            foreach ((CategoryModel item, SelectListItem selectListItem) in 
                from item in categoriesModels.Where(cat => cat.isactive == true)
                let selectListItem = new SelectListItem()
                select (item, selectListItem))
            {
                selectListItem.Value = item.id.ToString();
                selectListItem.Text = item.name;
                categories.Add(selectListItem);
            }

            ViewBag.CategoriesLookup = categories;

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

                var result = await _prdApiEnpoint
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

            return RedirectToAction("Index", "Product");

        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoriesModels = await _catApiEndpoint
               .AppendPathSegment("list")
               .GetJsonAsync<IEnumerable<CategoryModel>>();

            List<SelectListItem> categories = new();
            foreach ((CategoryModel item, SelectListItem selectListItem) in
                from item in categoriesModels.Where(cat => cat.isactive == true)
                let selectListItem = new SelectListItem()
                select (item, selectListItem))
            {
                selectListItem.Value = item.id.ToString();
                selectListItem.Text = item.name;
                categories.Add(selectListItem);
            }

            ViewBag.CategoriesLookup = categories;

            var category = await _prdApiEnpoint
                .AppendPathSegment("listBy")
               .SetQueryParam("id", value: id)
               .GetJsonAsync<ProductModel>();

            categories.FirstOrDefault(cat => cat.Value
               == category.categoryId.ToString()).Selected = true;

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, [FromForm] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                await _prdApiEnpoint
                  .AppendPathSegment("update")
                  .PutJsonAsync(product);

                return RedirectToAction("Index", "Category");
            }
            return View("Edit", product);

        }

        public async Task<IActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                await _prdApiEnpoint
                     .AppendPathSegment("delete")
                     .PatchJsonAsync(new ProductModel
                     {
                         id = id
                     });
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

                    await _prdApiEnpoint
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
            }

            return null;

        }


        public async Task<IActionResult> ExportAsync()
        {
            var apiUrsl = this.ApiBaseUrl + "/Product/";
            var products = await apiUrsl
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

            return File(System.Text.Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", fileName);
        }

        #endregion

        #endregion
    }

}
