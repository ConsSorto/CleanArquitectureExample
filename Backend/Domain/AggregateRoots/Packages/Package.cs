using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Domain.AggregateRoots.Packages
{
    public class Package : AggregateRoot
    {
        public int TruckId { get; set; }
        public Truck? Truck { get; set; }

        public int BranchId { get; set; }
        public Branch? Branch { get; set; }

        public int StateId { get; set; }
        public State? State { get; set; }

        public DateTime Date { get; set; }
        public string Tracking { get; set; } = string.Empty;

        public int UserCreateId { get; set; }
        public User? UserCreate { get; set; }

        public int? UserReceiveId { get; set; }
        public User? UserReceive { get; set; }

        public List<PackageDetail> Details { get; set; } = new();
    }
}
