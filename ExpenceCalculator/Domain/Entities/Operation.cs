namespace ExpenceCalculator.Domain.Entities
{
    public class Operation: BaseEntity
    {
        public OperationType Type { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public virtual List<OperationDate> OperationDates { get; set; }
        public virtual List<Category> Categories { get; set; }

        public Operation() {}
    }
}
