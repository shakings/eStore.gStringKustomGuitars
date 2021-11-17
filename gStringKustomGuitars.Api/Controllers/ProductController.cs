using gStringKustomGuitars.Services.Domain.Categories.Models.Dtos;
using gStringKustomGuitars.Services.Domain.Products.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {      
        private readonly IProductService _productServices;

        #region constructor

        public ProductController(IProductService productServices)
        {       
            _productServices = productServices;
        }

        #endregion

        #region controller endpoints

        [HttpGet("list")]
        public async Task<IEnumerable<ProductPsResultDto>> Get()
        {
            return await _productServices.Get();
        }

        [HttpGet("listBy")]
        public async Task<ProductPsResultDto> GetById(int id)
        {
            return await _productServices.GetById(new ProductPsParamaterDto()
            {
                id = id
            });
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] ProductPiParamaterDto productPiParamaterDto)
        {
            return Ok(await _productServices.Insert(productPiParamaterDto));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] ProductPuParamaterDto productPiParamaterDto)
        {
            return Ok(await _productServices.Update(productPiParamaterDto));
        }

        [HttpPatch]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] ProductPdParamaterDto productPdParamaterDto)
        {
            return Ok(await _productServices.Delete(productPdParamaterDto));
        }

        #endregion
    }
}
