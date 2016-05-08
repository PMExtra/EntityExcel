using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataMapper.Extensions;

namespace DataMapper.Models
{
    public class TableMapper<T> : IEnumerable<T> where T : new()
    {
        public TableMapper(DataTable table)
        {
            Table = table;
        }

        public DataTable Table { get; }

        public IEnumerator<T> GetEnumerator()
        {
            return (from DataRow row in Table.Rows select row.MapTo<T>()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (from DataRow row in Table.Rows select row.MapTo<T>()).GetEnumerator();
        }
    }
}