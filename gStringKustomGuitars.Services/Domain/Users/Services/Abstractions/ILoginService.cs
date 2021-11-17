using gStringKustomGuitars.Services.Domain.Users.Models.Dtos;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Users.Services.Abstractions
{
    public interface ILoginService
    {
        Task<UserPsResultsDto> Auth(LoginPsParametersDto loginPsParametersDto);
    }
}
