using gStringKustomGuitars.Services.Domain.Categories.Models.Dtos;
using gStringKustomGuitars.Services.Domain.Categories.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
    
        private readonly ICategoryServices _categoryServices;

        #region construtor

        public CategoriesController(ICategoryServices categoryServices)
        {          
            _categoryServices = categoryServices;
        }
        
        #endregion

        #region controller endpoint

        [HttpGet("list")]
        public async Task<IEnumerable<CategoryPsResultDto>> Get()
        {
            return await _categoryServices.Get();
        }

        [HttpGet("listBy")]
        public async Task<CategoryPsResultDto> GetById(int Id)
        {
            return await _categoryServices.GetBy(new CategoryPsParamaterDto()
            {
                id = Id
            });
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] CategoryPiParamaterDto categoryPiParamaterDto)
        {
            return Ok(await _categoryServices.Insert(categoryPiParamaterDto));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] CategoryPuParamaterDto categoryPiParamaterDto)
        {
            return Ok(await _categoryServices.Update(categoryPiParamaterDto));
        }

        #endregion
    }
}
