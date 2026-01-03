using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ORM.EFConverters
{
    public class NullableDateOnlyConverter : ValueConverter<DateOnly?, DateTime?>
    {
        public NullableDateOnlyConverter() : base(
            dateOnly => dateOnly == null
                ? null
                : new DateTime?(dateOnly.Value.ToDateTime(TimeOnly.MinValue)),
            dateTime => dateTime == null
                ? null
                : new DateOnly?(DateOnly.FromDateTime(dateTime.Value)))
        { }
    }
}
