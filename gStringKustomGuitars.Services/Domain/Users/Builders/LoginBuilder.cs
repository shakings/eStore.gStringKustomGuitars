using gStringKustomGuitars.Data.Abstractions;
using gStringKustomGuitars.Data.Models;
using gStringKustomGuitars.Services.Domain.Users.Builders.Abstractions;
using gStringKustomGuitars.Services.Domain.Users.Models.Entities;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Users.Builders
{
    public class LoginBuilder : gStringKustomBase, ILoginBuilder
    {
        private readonly IQuery<PS_LOGIN_Results> _query;

        public LoginBuilder(IQuery<PS_LOGIN_Results> query,
                            IgStringKustomConnection aptConnection) : base(aptConnection)
        {
            _query = query;
        }

        public async Task<PS_LOGIN_Results> Auth(PS_LOGIN_Parameters pI_LOGIN_Parameters)
        {
            return await _query.Single(new QueryParams
            {
                Sql = "PS_LOGIN",
                ConnectionStr = aptConnection.String,
                parms = new Dapper.DynamicParameters(pI_LOGIN_Parameters)
            });

        }
    }
}
