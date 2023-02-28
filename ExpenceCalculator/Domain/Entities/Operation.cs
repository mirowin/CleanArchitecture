namespace ExpenceCalculator.Domain.Entities
{
    public class Operation: BaseEntity
    {
        public OperationType Type { get; set; }
        public IEnumerable<OperationGroup> Group { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public IEnumerable<OperationDate> OperationDates { get; set; }
    }
}
