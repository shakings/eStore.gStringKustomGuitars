using gStringKustomGuitars.Data.Abstractions;
using System;

namespace gStringKustomGuitars.Data
{
    public class gStringKustomConnection : IgStringKustomConnection
    {
        public string String { get; private set; }

        public void SetString(string connStr)
        {
            if (ValueIsInvalid(String) && ValueIsInvalid(connStr))
            {
                throw new ArgumentNullException($"{nameof(connStr)} cannot be null");
            }

            String = connStr;
        }

        private static bool ValueIsInvalid(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
