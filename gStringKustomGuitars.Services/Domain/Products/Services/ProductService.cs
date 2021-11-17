using AutoMapper;
using gStringKustomGuitars.Services.Domain.Categories.Models.Dtos;
using gStringKustomGuitars.Services.Domain.Products.Builders.Abstractions;
using gStringKustomGuitars.Services.Domain.Products.Models.Entities;
using gStringKustomGuitars.Services.Domain.Products.Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Products.Services
{
    public class ProductService : IProductService
    {
        #region private variables

        private readonly IProductBuilder _productBuilder;
        private readonly IMapper _mapper;

        #endregion

        #region constructor

        public ProductService(IProductBuilder productBuilder,
                              IMapper mapper)
        {
            this._productBuilder = productBuilder;
            this._mapper = mapper;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<ProductPsResultDto>> Get()
        {
            var result = await _productBuilder.GetAsync();

            return result.Select(obj => _mapper.Map<ProductPsResultDto>(obj)).ToList();
        }

        public async Task<ProductPsResultDto> GetById(ProductPsParamaterDto productPsParamaterDto)
        {
            var parameters = _mapper.Map<PS_PRODUCTS_Parameters>(productPsParamaterDto);
            var result = await _productBuilder.GetByIdAsync(parameters);

            return _mapper.Map<ProductPsResultDto>(result);
        }

        public async Task<int> Insert(ProductPiParamaterDto productPiParamaterDto)
        {
            var parameters = _mapper.Map<PI_PRODUCTS_Parameters>(productPiParamaterDto);
            var result =
                await _productBuilder.InsertAsync(parameters);

            return result;
        }

        public async Task<int> Update(ProductPuParamaterDto productPuParamaterDto)
        {
            var parameters = _mapper.Map<PU_PRODUCTS_Parameters>(productPuParamaterDto);
            var result =
                await _productBuilder.UpdateAsync(parameters);

            return result;
        }

        public async Task<int> Delete(ProductPdParamaterDto productPdParamaterDto)
        {
            var result =
                await _productBuilder.DeleteAsync(new PD_PRODUCTS_Parameters()
                {
                    prd_id = productPdParamaterDto.id
                });

            return result;
        }

        #endregion

    }
}
