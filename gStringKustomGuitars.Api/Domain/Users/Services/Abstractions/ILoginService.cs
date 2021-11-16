using gStringKustomGuitars.Api.Domain.Users.Models.Dtos;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Domain.Users.Services.Abstractions
{
    public interface ILoginService
    {
        Task<UserPsResultsDto> Auth(LoginPsParametersDto loginPsParametersDto);
    }
}
