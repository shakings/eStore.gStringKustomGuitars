using gStringKustomGuitars.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Data.Abstractions
{
    public interface IQuery<T> where T : class
    {
        Task<T> Single(QueryParams getParams);
        Task<IEnumerable<T>> Many(QueryParams getParams);

    }
}
