using gStringKustomGuitars.Data.Abstractions;
using gStringKustomGuitars.Data.Models;
using gStringKustomGuitars.Services.Domain.Users.Builders.Abstractions;
using gStringKustomGuitars.Services.Domain.Users.Models.Entities;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Users.Builders
{
    public class UserBuilder : gStringKustomBase, IUserBuilder
    {
        private readonly IExecute _execute;

        public UserBuilder(IExecute execute,
                           IgStringKustomConnection aptConnection) : base(aptConnection)
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
