using gStringKustomGuitars.Services.Domain.Users.Models.Dtos;
using gStringKustomGuitars.Services.Domain.Users.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {       
        private readonly IUserService _userService;

        #region constructor
        
        public UserController(IUserService userService)
        {           
            this._userService = userService;
        }

        #endregion

        #region conttroller endpoints
        
        [HttpPost]
        [Route("insert")]
        public async Task<int> Insert([FromBody] UserPiParametersDto userPiParametersDto)
        {
            return await _userService.Insert(userPiParametersDto);
        }

        #endregion
    }
}
