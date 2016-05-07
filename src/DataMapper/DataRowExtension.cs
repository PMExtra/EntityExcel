using System;
using System.Data;
using System.Linq;

namespace DataMapper
{
    public static class DataRowExtension
    {
        public static T MapTo<T>(this DataRow row) where T : new()
        {
            var model = new T();
            var type = model.GetType();

            foreach (var property in type.GetProperties().Where(p => p.CanWrite))
            {
                if (row.Table.Columns.Contains(property.Name))
                {
                    var data = row[property.Name];
                    if (property.PropertyType.IsEnum)
                    {
                        property.SetValue(model, Convert.ToInt32(data));
                    }
                    else
                    {
                        property.SetValue(model, Convert.ChangeType(data, property.PropertyType));
                    }
                }
            }

            return model;
        }
    }
}