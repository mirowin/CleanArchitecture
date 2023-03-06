using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceCalculator.Domain.DTO
{
    public class OperationViewModel
    {
        public OperationType Type { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public IEnumerable<OperationDateViewModel> OperationDates { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
