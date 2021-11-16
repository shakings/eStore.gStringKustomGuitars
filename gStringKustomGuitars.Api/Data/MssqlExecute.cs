using Dapper;
using gStringKustomGuitars.Api.Data.Abstractions;
using gStringKustomGuitars.Api.Data.Models;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Data
{
    public class MssqlExecute : DALBase, IExecute
    {
        public async Task<T> Scaler<T>(QueryParams queryParams)
        {
            return await WrapQuery<T>(
                queryParams: queryParams,
                queryFunc: async (con, trans, queryParams) =>
                 {
                     return await con.ExecuteScalarAsync<T>(
                         sql: queryParams.Sql,
                         param: queryParams.parms,
                         transaction: trans,
                         commandType: queryParams.commandType

                         );
                 });
        }
        public async Task<int> Sql(QueryParams queryParams)
        {
            return await WrapQuery<int>(
                 queryParams: queryParams,
                 queryFunc: async (con, trans, queryParams) =>
                 {
                     return await con.ExecuteAsync(
                         sql: queryParams.Sql,
                         param: queryParams.parms,
                         transaction: trans,
                         commandType: queryParams.commandType
                         );
                 });
        }


    }
}