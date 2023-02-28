using System.ComponentModel.DataAnnotations;

namespace ExpenceCalculator.Domain.DTO
{
    public class CreateOperationModel
    {
        public OperationType Type { get; set; } = OperationType.once;
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Value { get; set; }
        public IEnumerable<DateTime> OperationTime { get; set; } = new DateTime[1] { DateTime.Now };
    }
}
