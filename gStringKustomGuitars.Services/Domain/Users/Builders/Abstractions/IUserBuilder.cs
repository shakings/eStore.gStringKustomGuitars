using gStringKustomGuitars.Services.Domain.Users.Models.Entities;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Users.Builders.Abstractions
{
    public interface IUserBuilder
    {
        /// <summary>
        /// Create User 
        /// </summary>
        /// <param name="pI_USER_Parameters"></param>
        /// <returns></returns>
        Task<int> Insert(PI_USER_Parameters pI_USER_Parameters);



    }
}
