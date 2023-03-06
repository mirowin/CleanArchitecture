using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExpenceCalculator.Domain.Entities
{
    public class OperationDate : BaseEntity
    {
        public Operation Operation { get; set; }
        public DateTime Date { get; set; }

        public OperationDate() {}

        public OperationDate(DateTime dateTime)
        {
            this.Date = dateTime;
        }
    }
}
