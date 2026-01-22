using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helper
{
    public static class UpdateHelper
    {
        public static void MapIfNotNull<TSource, TTarget>(TSource source, TTarget target)
        {
            var sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var targetProperties = typeof(TTarget).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var sourceProp in sourceProperties)
            {
                var value = sourceProp.GetValue(source);
                if (value == null)
                    continue;

                var targetProp = targetProperties.FirstOrDefault(p => p.Name == sourceProp.Name);
                if (targetProp != null && targetProp.CanWrite)
                {
                    if (value != null)
                    {
                        var targetType = Nullable.GetUnderlyingType(targetProp.PropertyType) ?? targetProp.PropertyType;
                        targetProp.SetValue(target, Convert.ChangeType(value, targetType));
                    }
                }
            }
        }
    }

}
