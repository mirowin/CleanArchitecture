using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public class Operation: BaseEntity
    {
        public OperationType Type { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public IEnumerable<DateTime> OperationDates { get; set; }
    }
}
