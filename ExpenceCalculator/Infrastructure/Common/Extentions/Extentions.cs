using ExpenceCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceCalculator.Infrastructure.Common.Extentions
{
    public static class Extentions
    {
        public static OperationDate CreateOpeationDate(this DateTime dt)
        {
            return new OperationDate() { Date = dt };
        }

        public static OperationGroup GetOperationGroup(this string group)
        {
            return new OperationGroup() { Name = group };
        }
    }
}
