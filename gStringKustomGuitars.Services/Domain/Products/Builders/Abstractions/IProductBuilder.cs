using gStringKustomGuitars.Services.Domain.Products.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Products.Builders.Abstractions
{
    public interface IProductBuilder
    {
        /// <summary>
        ///  Get All Products
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PS_PRODUCTS_Results>> GetAsync();

        /// <summary>
        /// Get Product By ID
        /// </summary>
        /// <param name="pS_PRODUCTS_Parameters"></param>
        /// <returns></returns>
        Task<PS_PRODUCTS_Results> GetByIdAsync(PS_PRODUCTS_Parameters pS_PRODUCTS_Parameters);

        /// <summary>
        /// Insert New Product
        /// </summary>
        /// <param name="pI_PRODUCTS_Parameters"></param>
        /// <returns></returns>
        Task<int> InsertAsync(PI_PRODUCTS_Parameters pI_PRODUCTS_Parameters);

        /// <summary>
        /// Update Existing Product
        /// </summary>
        /// <param name="pU_PRODUCTS_Parameters"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(PU_PRODUCTS_Parameters pU_PRODUCTS_Parameters);

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="pD_PRODUCTS_Parameters"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(PD_PRODUCTS_Parameters pD_PRODUCTS_Parameters);
    }
}
