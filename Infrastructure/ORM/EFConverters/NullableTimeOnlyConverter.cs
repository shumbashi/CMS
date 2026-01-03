using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ORM.EFConverters
{
    public class NullableTimeOnlyConverter : ValueConverter<TimeOnly?, DateTime?>
    {
        public NullableTimeOnlyConverter() : base(
            timeOnly => timeOnly == null
                ? null
                : new DateTime?(new DateTime(1, 1, 1, timeOnly.Value.Hour, timeOnly.Value.Minute, timeOnly.Value.Second, timeOnly.Value.Millisecond)),
            dateTime => dateTime == null
                ? null
                : new TimeOnly?(TimeOnly.FromDateTime(dateTime.Value)))
        { }
    }
}
