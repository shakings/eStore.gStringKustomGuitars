using gStringKustomGuitars.Services.Domain.Categories.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Categories.Services.Abstractions
{
    public interface ICategoryServices
    {
        /// <summary>
        ///  Get All Categories
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CategoryPsResultDto>> Get();

        /// <summary>
        /// Get Categories By ID
        /// </summary>
        /// <param name="categoryPsParamaterDto"></param>
        /// <returns></returns>
        Task<CategoryPsResultDto> GetBy(CategoryPsParamaterDto categoryPsParamaterDto);

        /// <summary>
        /// Insert New Category
        /// </summary>
        /// <param name="categoryPiParamaterDto"></param>
        /// <returns></returns>
        Task<int> Insert(CategoryPiParamaterDto categoryPiParamaterDto);

        /// <summary>
        /// Update Existing Category
        /// </summary>
        /// <param name="categoryPuParamaterDto"></param>
        /// <returns></returns>
        Task<int> Update(CategoryPuParamaterDto categoryPuParamaterDto);
    }
}
