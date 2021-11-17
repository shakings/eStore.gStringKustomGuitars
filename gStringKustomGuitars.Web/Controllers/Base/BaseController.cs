using Flurl;
using Flurl.Http;
using gStringKustomGuitars.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        #region protected variables

        protected IConfiguration _configuration;
        protected string ApiBaseUrl { get; }

        #endregion

        #region private variables

        private string _apiBaseUrl;
        private string _apiControllerName;
        private string _apiUri;

        #endregion

        #region ctor

        public BaseController(IConfiguration configuration)
        {
            this._configuration = configuration;

             ApiBaseUrl = this._configuration["AppSettings:ApiUrl"].ToString();

            _apiBaseUrl = this.ApiBaseUrl;
            _apiControllerName = "/Audit/";
            _apiUri = string.Format("{0}{1}", _apiBaseUrl, _apiControllerName);
        }
        
        #endregion

        #region methods
        
        public async Task AuditTraceAsync(int userSessionId,
            string eventName,
            string actionDescription)
        {
            var audit = new AuditModel()
            {
                eventName = eventName,
                eventAction = actionDescription,
                userId = userSessionId
            };            

            await _apiUri
                .AppendPathSegment("insert")
                .PostJsonAsync(audit);
        }
        
        #endregion
    }
}
