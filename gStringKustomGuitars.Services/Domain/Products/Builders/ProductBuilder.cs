using gStringKustomGuitars.Data.Abstractions;
using gStringKustomGuitars.Data.Models;
using gStringKustomGuitars.Services.Domain.Products.Builders.Abstractions;
using gStringKustomGuitars.Services.Domain.Products.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Services.Domain.Products.Builders
{
    public class ProductBuilder : gStringKustomBase, IProductBuilder
    {
        #region private variables

        private readonly IQuery<PS_PRODUCTS_Results> _query;
        private readonly IExecute _execute;

        #endregion

        #region constructors

        public ProductBuilder(IQuery<PS_PRODUCTS_Results> query,
                              IExecute execute,
                              IgStringKustomConnection igStringKustomConnection) : base(igStringKustomConnection)
        {
            _query = query;
            _execute = execute;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<PS_PRODUCTS_Results>> GetAsync()
        {
            return await _query.Many(new QueryParams
            {
                Sql = "PS_PRODUCTS",
                ConnectionStr = aptConnection.String
            });
        }

        public async Task<PS_PRODUCTS_Results> GetByIdAsync(PS_PRODUCTS_Parameters pS_PRODUCTS_Parameters)
        {
            return await _query.Single(new QueryParams
            {
                Sql = "PS_PRODUCTS",
                ConnectionStr = aptConnection.String,
                parms = new Dapper.DynamicParameters(pS_PRODUCTS_Parameters)
            });
        }

        public async Task<int> InsertAsync(PI_PRODUCTS_Parameters pI_PRODUCTS_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                Sql = "PI_PRODUCTS",
                ConnectionStr = aptConnection.String,
                parms = new Dapper.DynamicParameters(pI_PRODUCTS_Parameters)
            });

            return results;
        }

        public async Task<int> UpdateAsync(PU_PRODUCTS_Parameters pU_PRODUCTS_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                Sql = "PU_PRODUCTS",
                ConnectionStr = aptConnection.String,
                parms = new Dapper.DynamicParameters(pU_PRODUCTS_Parameters)
            });

            return results;
        }

        public async Task<int> DeleteAsync(PD_PRODUCTS_Parameters pD_PRODUCTS_Parameters)
        {
            var results = await _execute.Sql(new QueryParams
            {
                Sql = "PD_PRODUCTS",
                ConnectionStr = aptConnection.String,
                parms = new Dapper.DynamicParameters(pD_PRODUCTS_Parameters)
            });

            return results;
        }

        #endregion
    }
}
