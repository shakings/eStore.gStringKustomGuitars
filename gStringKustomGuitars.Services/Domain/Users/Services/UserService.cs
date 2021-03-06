using AutoMapper;
using gStringKustomGuitars.Services.Domain.Users.Builders.Abstractions;
using gStringKustomGuitars.Services.Domain.Users.Models.Dtos;
using gStringKustomGuitars.Services.Domain.Users.Models.Entities;
using gStringKustomGuitars.Services.Domain.Users.Services.Abstractions;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Users.Services
{
    public class UserService : IUserService
    {
        #region private variables

        private readonly IUserBuilder _userBuilder;
        private readonly IMapper _mapper;

        #endregion

        #region constructor

        public UserService(IUserBuilder userBuilder,
                           IMapper mapper)
        {
            this._userBuilder = userBuilder;
            this._mapper = mapper;
        }

        #endregion

        #region methods

        public async Task<int> Insert(UserPiParametersDto userPiParametersDto)
        {
            var parameters = _mapper.Map<PI_USER_Parameters>(userPiParametersDto);
            var result =
             await this._userBuilder.Insert(parameters);

            return result;
        }

        #endregion
    }
}
