using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace gStringKustomGuitars.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        protected IConfiguration _configuration;

        public BaseController(IConfiguration configuration)
        {
            this._configuration = configuration;

            ApiBaseUrl = this._configuration["AppSettings:ApiUrl"].ToString();
        }

        protected string ApiBaseUrl { get; }
    }
}
