using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceCalculator.Domain.Entities
{
    public class OperationDate : BaseEntity
    {
        public Operation Operation { get; set; }
        public DateTime Date { get; set; }
    }
}
