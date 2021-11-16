using Dapper;
using System.Data;

namespace gStringKustomGuitars.Api.Data.Models
{
    public class BaseParams
    {
        public string Sql { get; set; }
        public DynamicParameters parms { get; set; }
        public CommandType commandType { get; set; } = CommandType.StoredProcedure;
        public string ConnectionStr { get; set; }
        public bool UseTransaction { get; set; }

    }
}
