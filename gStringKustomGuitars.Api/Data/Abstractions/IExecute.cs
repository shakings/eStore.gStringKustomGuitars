using gStringKustomGuitars.Api.Data.Models;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Api.Data.Abstractions
{
    public interface IExecute
    {
        Task<int> Sql(QueryParams queryParams);
        Task<T> Scaler<T>(QueryParams queryParams);
    }
}
