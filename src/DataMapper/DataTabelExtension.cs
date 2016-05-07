using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataMapper
{
    public static class DataTabelExtension
    {
        public static IEnumerable<T> MapTo<T>(this DataTable table) where T : new()
        {
            return from DataRow row in table.Rows select row.MapTo<T>();
        }
    }
}