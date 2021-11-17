using gStringKustomGuitars.Services.Domain.Users.Models.Dtos;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Users.Services.Abstractions
{
    public interface IUserService
    {
        /// <summary>
        /// Insert New User
        /// </summary>
        /// <param name="userPiParametersDto"></param>
        /// <returns></returns>
        Task<int> Insert(UserPiParametersDto userPiParametersDto);
    }
}
