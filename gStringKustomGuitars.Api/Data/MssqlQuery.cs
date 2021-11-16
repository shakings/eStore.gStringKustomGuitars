using Dapper;
using gStringKustomGuitars.Api.Data.Abstractions;
using gStringKustomGuitars.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Data
{
    public class MssqlQuery<T> : IQuery<T> where T : class
    {
        public async Task<IEnumerable<T>> Many(QueryParams queryParams)
        {
            return await WrapQuery<IEnumerable<T>>(
                queryParams: queryParams,
                queryFunc: async (connection, transaction, queryparms) =>
                {
                    return await connection.QueryAsync<T>(
                        sql: queryParams.Sql,
                        param: queryParams.parms,
                        transaction: transaction,
                        commandType: queryParams.commandType
                        );
                });
        }

        public async Task<T> Single(QueryParams queryParams)
        {
            return await WrapQuery<T>(
               queryParams: queryParams,
               queryFunc: async (connection, transaction, queryparms) =>
               {
                   return await connection.QueryFirstOrDefaultAsync<T>(
                       sql: queryParams.Sql,
                       param: queryParams.parms,
                       transaction: transaction,
                       commandType: queryParams.commandType);
               });
        }


        private async Task<TResult> WrapQuery<TResult>(QueryParams queryParams,
                Func<SqlConnection, IDbTransaction,
                QueryParams, Task<TResult>> queryFunc)
        {
            using (SqlConnection connection = new SqlConnection(queryParams.ConnectionStr))
            {
                if (queryParams.UseTransaction)
                {
                    using (SqlTransaction tran = connection.BeginTransaction())
                    {
                        try
                        {

                            TResult rows = await queryFunc(connection, tran, queryParams);
                            tran.Commit();
                            return rows;

                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }

                }
                else
                {
                    return await queryFunc(connection, null, queryParams);
                }
            }
        }
    }
}
