using gStringKustomGuitars.Api.Domain.Users.Models.Dtos;
using gStringKustomGuitars.Api.Domain.Users.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {     
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {          
            this._loginService = loginService;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<UserPsResultsDto> Auth([FromBody] LoginPsParametersDto loginPsParametersDto)
        {
            return await _loginService.Auth(loginPsParametersDto);
        }
    }
}
