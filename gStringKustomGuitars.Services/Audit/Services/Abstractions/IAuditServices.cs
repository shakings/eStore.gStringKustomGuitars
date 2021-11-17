using gStringKustomGuitars.Services.Domain.Audit.Models.Dtos;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Audit.Services.Abstractions
{
    public interface IAuditServices
    {             
        Task<int> Insert(AuditPiParamaterDto auditPiParamaterDto);
      
    }
}
