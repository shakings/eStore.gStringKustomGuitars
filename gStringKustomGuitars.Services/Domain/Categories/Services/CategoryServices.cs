using AutoMapper;
using gStringKustomGuitars.Services.Domain.Categories.Builders.Abstractions;
using gStringKustomGuitars.Services.Domain.Categories.Models.Dtos;
using gStringKustomGuitars.Services.Domain.Categories.Models.Entities;
using gStringKustomGuitars.Services.Domain.Categories.Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Categories.Services
{
    public class CategoryServices : ICategoryServices
    {
        #region private variables

        private readonly ICategoryBuilder _categoryBuilder;
        private readonly IMapper _mapper;

        #endregion

        #region constructor

        public CategoryServices(ICategoryBuilder categoryBuilder,
                                IMapper mapper)
        {
            this._categoryBuilder = categoryBuilder;
            this._mapper = mapper;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<CategoryPsResultDto>> Get()
        {
            var results = await _categoryBuilder.Get(new PS_CATEGORIES_Parameters()
            {
                cat_id = -1
            });

            return results.Select(obj => _mapper.Map<CategoryPsResultDto>(obj)).ToList();
        }

        public async Task<CategoryPsResultDto> GetBy(CategoryPsParamaterDto categoryPsParamaterDto)
        {
            var parameters = _mapper.Map<PS_CATEGORIES_Parameters>(categoryPsParamaterDto);
            var result =
                await _categoryBuilder.GetById(parameters);

            return _mapper.Map<CategoryPsResultDto>(result);
        }

        public async Task<int> Insert(CategoryPiParamaterDto categoryPiParamaterDto)
        {
            var parameters = _mapper.Map<PI_CATEGORIES_Parameters>(categoryPiParamaterDto);
            var result =
                await _categoryBuilder.Insert(parameters);

            return result;
        }

        public async Task<int> Update(CategoryPuParamaterDto categoryPuParamaterDto)
        {
            var parameters = _mapper.Map<PU_CATEGORIES_Parameters>(categoryPuParamaterDto);
            var result =
              await _categoryBuilder.Update(parameters);

            return result;
        }

        #endregion
    }
}
