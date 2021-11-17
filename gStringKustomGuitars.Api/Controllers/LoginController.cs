using gStringKustomGuitars.Services.Domain.Users.Models.Dtos;
using gStringKustomGuitars.Services.Domain.Users.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {     
        private readonly ILoginService _loginService;

        #region ctor
        
        public LoginController(ILoginService loginService)
        {          
            this._loginService = loginService;
        }

        #endregion

        [HttpPost]
        [Route("auth")]
        public async Task<UserPsResultsDto> Auth([FromBody] LoginPsParametersDto loginPsParametersDto)
        {
            return await _loginService.Auth(loginPsParametersDto);
        }
    }
}
