using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataMapper.Extensions
{
    public static class DataTabelExtension
    {
        public static IEnumerable<object> MapTo(this DataTable table, Type type)
        {
            return from DataRow row in table.Rows select row.MapTo(type);
        }

        public static IEnumerable<T> MapTo<T>(this DataTable table) where T : new()
        {
            return from DataRow row in table.Rows select row.MapTo<T>();
        }
    }
}