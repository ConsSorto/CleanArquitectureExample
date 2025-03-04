using Domain.Common;

namespace Domain.Entities
{
    public class BranchOffice: Entity
    {
        public string Name { set; get; }
        public string Address { set; get; }

        public BranchOffice(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
