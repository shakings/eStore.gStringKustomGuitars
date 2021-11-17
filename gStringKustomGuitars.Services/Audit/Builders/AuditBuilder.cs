using gStringKustomGuitars.Data.Abstractions;
using gStringKustomGuitars.Data.Models;
using gStringKustomGuitars.Services.Domain.Audit.Models.Entities;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Audit.Builders.Abstractions
{
    public class AuditBuilder : gStringKustomBase, IAuditBuilder
    {
        #region private variables

        private readonly IExecute _execute;

        #endregion

        #region constructor

        public AuditBuilder(IExecute execute,
                            IgStringKustomConnection igStringKustomConnection) : base(igStringKustomConnection)
        {
            _execute = execute;
        }

        #endregion

        #region methods

        public async Task<int> Insert(PI_AUDIT_Parameters pI_AUDIT_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                Sql = "PI_AUDIT_TRACE",
                ConnectionStr = aptConnection.String,
                parms = new Dapper.DynamicParameters(pI_AUDIT_Parameters)
            });

            return results;
        }

        #endregion
    }
}
