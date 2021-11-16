using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace gStringKustomGuitars.Api.Data.Helpers.SqlTableTypeParameter
{
    public class SqlTableTypeParameter<T> where T : class
    {
        protected readonly DataTable _dt;

        public SqlTableTypeParameter()
        {
            _dt = new DataTable();
        }

        public virtual DataTable CreateDataTable(IEnumerable<T> Rows)
        {

            PropertyInfo[] properties = typeof(T).GetProperties
            (BindingFlags.Public | BindingFlags.Instance);

            PropertyInfo[] readableProperties = properties.Where
                  (w => w.CanRead).ToArray();


            var columnNames = readableProperties.Select(s => s.Name).ToList();

            foreach (string name in columnNames)
            {
                _dt.Columns.Add(name, readableProperties.Single
                     (s => s.Name.Equals(name)).PropertyType);
            }


            foreach (T obj in Rows)
            {
                _dt.Rows.Add(
                    columnNames.Select(s => readableProperties.Single
                        (s2 => s2.Name.Equals(s)).GetValue(obj))
                        .ToArray());
            }

            return _dt;
        }


    }
}
