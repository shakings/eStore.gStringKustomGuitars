using AutoMapper;
using gStringKustomGuitars.Api.Domain.Users.Builders.Abstractions;
using gStringKustomGuitars.Api.Domain.Users.Models.Dtos;
using gStringKustomGuitars.Api.Domain.Users.Models.Entities;
using gStringKustomGuitars.Api.Domain.Users.Services.Abstractions;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Domain.Users.Services
{
    public class LoginService : ILoginService
    {
        #region private variables 

        private readonly ILoginBuilder _loginBuilder;
        private readonly IMapper _mapper;

        #endregion

        #region constructor

        public LoginService(ILoginBuilder loginBuilder,
                            IMapper mapper)
        {
            this._loginBuilder = loginBuilder;
            this._mapper = mapper;
        }

        #endregion

        #region methods
        public async Task<UserPsResultsDto> Auth(LoginPsParametersDto loginPsParametersDto)
        {
            var parameters = _mapper.Map<PS_LOGIN_Parameters>(loginPsParametersDto);
            var result =
                await _loginBuilder.Auth(parameters);

            return _mapper.Map<UserPsResultsDto>(result);
        }

        #endregion 
    }
}
