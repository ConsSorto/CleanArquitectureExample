using Domain.Common;

namespace Domain.Entities
{
    public class Product: Entity
    {
        public string Name { get; set; }
        public Product(string name)
        {
            Name = name;
        }

    }
}
