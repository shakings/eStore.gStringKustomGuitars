using gStringKustomGuitars.Api.Domain.Categories.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Domain.Categories.Builders.Abstractions
{
    public interface ICategoryBuilder
    {
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PS_CATEGORIES_Results>> Get(PS_CATEGORIES_Parameters pS_CATEGORIES_Parameters);

        /// <summary>
        /// Get Categories By ID
        /// </summary>
        /// <param name="pS_CATEGORIES_Parameters"></param>
        /// <returns></returns>
        Task<PS_CATEGORIES_Results> GetById(PS_CATEGORIES_Parameters pS_CATEGORIES_Parameters);

        /// <summary>
        /// Add New Categories
        /// </summary>
        /// </summary>
        /// <param name="pI_CATEGORIES_Parameters"></param>
        /// <returns></returns>
        Task<int> Insert(PI_CATEGORIES_Parameters pI_CATEGORIES_Parameters);

        /// <summary>
        /// Edit Categories
        /// </summary>
        /// <param name="pI_CATEGORIES_Parameters"></param>
        /// <returns></returns>
        Task<int> Update(PU_CATEGORIES_Parameters pU_CATEGORIES_Parameters);
    }
}

