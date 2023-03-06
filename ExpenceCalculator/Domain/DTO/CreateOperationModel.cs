using ExpenceCalculator.Domain.Entities;
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
        public IEnumerable<OperationDateViewModel> OperationTime { get; set; } = new OperationDateViewModel[1] { new OperationDateViewModel() { Date = DateTime.Now } };
        public IEnumerable<CategoryViewModel> OperationGroup { get; set; }
    }
}
