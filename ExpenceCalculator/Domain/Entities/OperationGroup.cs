namespace ExpenceCalculator.Domain.Entities
{
    public class OperationGroup : BaseEntity
    {
        public Operation Operation { get; set; }
        public string Name { get; set; }
    }
}
