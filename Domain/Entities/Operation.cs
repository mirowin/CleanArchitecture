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
