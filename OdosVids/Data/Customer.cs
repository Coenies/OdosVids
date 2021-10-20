using System;
using System.Collections.Generic;

#nullable disable

namespace OdosVids.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Children = new HashSet<Child>();
            CustomerSchedules = new HashSet<CustomerSchedule>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }

        public virtual ICollection<Child> Children { get; set; }
        public virtual ICollection<CustomerSchedule> CustomerSchedules { get; set; }
    }
}
