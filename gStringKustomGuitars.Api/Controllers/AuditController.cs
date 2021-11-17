using gStringKustomGuitars.Services.Domain.Audit.Models.Dtos;
using gStringKustomGuitars.Services.Domain.Audit.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        #region private variables

        private readonly IAuditServices _auditServices;

        #endregion

        #region ctro
        public AuditController(IAuditServices auditServices)
        {
            _auditServices = auditServices;
        }
        #endregion

        #region endpoints

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] AuditPiParamaterDto auditPiParamaterDto)
        {
            return Ok(await _auditServices.Insert(auditPiParamaterDto));
        }

        #endregion
    }
}
