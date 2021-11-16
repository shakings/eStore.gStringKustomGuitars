using gStringKustomGuitars.Api.Domain.Categories.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Domain.Products.Services.Abstractions
{
    public interface IProductService
    {
        /// <summary>
        ///  Get All Products
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductPsResultDto>> Get();

        /// <summary>
        /// Get Product By ID
        /// </summary>
        /// <param name="productPsParamaterDto"></param>
        /// <returns></returns>
        Task<ProductPsResultDto> GetById(ProductPsParamaterDto productPsParamaterDto);

        /// <summary>
        /// Insert New Product
        /// </summary>
        /// <param name="productPiParamaterDto"></param>
        /// <returns></returns>
        Task<int> Insert(ProductPiParamaterDto productPiParamaterDto);

        /// <summary>
        /// Update Existing Product
        /// </summary>
        /// <param name="productPuParamaterDto"></param>
        /// <returns></returns>
        Task<int> Update(ProductPuParamaterDto productPuParamaterDto);

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productPuParamaterDto"></param>
        /// <returns></returns>
        Task<int> Delete(ProductPdParamaterDto productPdParamaterDto);
    }
}
