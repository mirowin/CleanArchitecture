using System.Text.Json.Serialization;

namespace ExpenceCalculator.Domain.Entities
{
    public class Category : BaseEntity
    {
        public virtual List<Operation> Operations { get; set; }
        public string Name { get; set; }

        public Category() {}

        public Category(string name)
        {
            this.Name = name;
        }
    }
}
