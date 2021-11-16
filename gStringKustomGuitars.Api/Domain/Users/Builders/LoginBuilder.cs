using gStringKustomGuitars.Api.Abstractions.Builder;
using gStringKustomGuitars.Api.Controllers.Base;
using gStringKustomGuitars.Api.Data.Abstractions;
using gStringKustomGuitars.Api.Data.Models;
using gStringKustomGuitars.Api.Domain.Users.Builders.Abstractions;
using gStringKustomGuitars.Api.Domain.Users.Models.Entities;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Domain.Users.Builders
{
    public class LoginBuilder : AbstractBuilder, ILoginBuilder
    {
        private readonly IQuery<PS_LOGIN_Results> _query;

        public LoginBuilder(IQuery<PS_LOGIN_Results> query,
                            IAptConnection aptConnection) : base(aptConnection)
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
