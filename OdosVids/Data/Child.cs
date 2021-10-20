using System;
using System.Collections.Generic;

#nullable disable

namespace OdosVids.Data
{
    public partial class Child
    {
        public Child()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string ChildName { get; set; }
        public string CellNumber { get; set; }
        public int CustomerId { get; set; }
        public int? OnVideo { get; set; }
        public DateTime? StopOn { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
