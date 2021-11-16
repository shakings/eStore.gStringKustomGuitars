using gStringKustomGuitars.Api.Domain.Users.Models.Entities;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Domain.Users.Builders.Abstractions
{
    public interface ILoginBuilder
    {
        /// <summary>
        /// Autenticate User Access 
        /// </summary>
        /// <param name="pI_LOGIN_Parameters"></param>
        /// <returns></returns>
        Task<PS_LOGIN_Results> Auth(PS_LOGIN_Parameters pI_LOGIN_Parameters);
    }
}
