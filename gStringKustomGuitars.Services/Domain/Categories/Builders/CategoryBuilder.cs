using gStringKustomGuitars.Data.Abstractions;
using gStringKustomGuitars.Data.Models;
using gStringKustomGuitars.Services.Domain.Categories.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Categories.Builders.Abstractions
{
    public class CategoryBuilder : gStringKustomBase, ICategoryBuilder
    {
        #region private variables

        private readonly IQuery<PS_CATEGORIES_Results> _query;
        private readonly IExecute _execute;

        #endregion

        #region constructor

        public CategoryBuilder(IQuery<PS_CATEGORIES_Results> query,
                               IExecute execute,
                               IgStringKustomConnection igStringKustomConnection) : base(igStringKustomConnection)
        {
            _query = query;
            _execute = execute;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<PS_CATEGORIES_Results>> Get(PS_CATEGORIES_Parameters pS_CATEGORIES_Parameters)
        {
            return await _query.Many(new QueryParams
            {
                Sql = "PS_CATEGORIES",
                ConnectionStr = aptConnection.String,
                parms = new Dapper.DynamicParameters(pS_CATEGORIES_Parameters)
            });
        }

        public async Task<PS_CATEGORIES_Results> GetById(PS_CATEGORIES_Parameters pS_CATEGORIES_Parameters)
        {
            return await _query.Single(new QueryParams
            {
                Sql = "PS_CATEGORIES",
                ConnectionStr = aptConnection.String,
                parms = new Dapper.DynamicParameters(pS_CATEGORIES_Parameters)
            });
        }

        public async Task<int> Insert(PI_CATEGORIES_Parameters pI_CATEGORIES_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                Sql = "PI_CATEGORIES",
                ConnectionStr = aptConnection.String,
                parms = new Dapper.DynamicParameters(pI_CATEGORIES_Parameters)
            });

            return results;
        }

        public async Task<int> Update(PU_CATEGORIES_Parameters pU_CATEGORIES_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                Sql = "PU_CATEGORIES",
                ConnectionStr = aptConnection.String,
                parms = new Dapper.DynamicParameters(pU_CATEGORIES_Parameters)
            });

            return results;
        }

        #endregion
    }
}
