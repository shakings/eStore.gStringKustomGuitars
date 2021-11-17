using AutoMapper;
using gStringKustomGuitars.Services.Domain.Audit.Builders.Abstractions;
using gStringKustomGuitars.Services.Domain.Audit.Models.Dtos;
using gStringKustomGuitars.Services.Domain.Audit.Models.Entities;
using gStringKustomGuitars.Services.Domain.Audit.Services.Abstractions;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Audit.Services
{
    public class AuditServices : IAuditServices
    {
        #region private variables

        private readonly IAuditBuilder _auditBuilder;
        private readonly IMapper _mapper;

        #endregion

        #region constructor

        public AuditServices(IAuditBuilder auditBuilder,
                             IMapper mapper)
        {
            this._auditBuilder = auditBuilder;
            this._mapper = mapper;
        }

        #endregion

        #region methods

        public async Task<int> Insert(AuditPiParamaterDto auditPiParamaterDto)
        {
            var parameters = _mapper.Map<PI_AUDIT_Parameters>(auditPiParamaterDto);
            var result =
                await _auditBuilder.Insert(parameters);

            return result;
        }


        #endregion
    }
}
