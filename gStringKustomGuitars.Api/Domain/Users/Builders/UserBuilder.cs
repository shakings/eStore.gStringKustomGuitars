using gStringKustomGuitars.Api.Abstractions.Builder;
using gStringKustomGuitars.Api.Controllers.Base;
using gStringKustomGuitars.Api.Data.Abstractions;
using gStringKustomGuitars.Api.Data.Models;
using gStringKustomGuitars.Api.Domain.Users.Builders.Abstractions;
using gStringKustomGuitars.Api.Domain.Users.Models.Entities;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Domain.Users.Builders
{
    public class UserBuilder : AbstractBuilder, IUserBuilder
    {
        private readonly IExecute _execute;

        public UserBuilder(IExecute execute,
                           IAptConnection aptConnection) : base(aptConnection)
        {
            _execute = execute;
        }

        public async Task<int> Insert(PI_USER_Parameters pI_USER_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                Sql = "PI_USER",
                ConnectionStr = aptConnection.String,
                parms = new Dapper.DynamicParameters(pI_USER_Parameters)
            });

            return results;
        }
    }
}
