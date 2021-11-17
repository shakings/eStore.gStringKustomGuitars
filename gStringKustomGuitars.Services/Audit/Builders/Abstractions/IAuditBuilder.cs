using gStringKustomGuitars.Services.Domain.Audit.Models.Entities;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Audit.Builders.Abstractions
{
    public interface IAuditBuilder
    {
        /// <summary>
        ///  Audit Tracing
        /// </summary>
        /// <param name="pI_AUDIT_Parameters"></param>
        /// <returns></returns>
        Task<int> Insert(PI_AUDIT_Parameters pI_AUDIT_Parameters);

    }
}

