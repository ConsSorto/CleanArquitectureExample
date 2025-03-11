using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Truck : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;

        public int DriverId { get; set; } 
        public User? Driver { get; set; } 
    }

}
