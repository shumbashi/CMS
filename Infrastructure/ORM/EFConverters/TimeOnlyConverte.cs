using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ORM.EFConverters
{
    public class TimeOnlyConvert : ValueConverter<TimeOnly, DateTime>
    {
        public TimeOnlyConvert() : base(
                timeOnly => new DateTime(1, 1, 1, timeOnly.Hour, timeOnly.Minute, timeOnly.Second, timeOnly.Millisecond),
                dateTime => TimeOnly.FromDateTime(dateTime))
        { }
    }
}
