using System;
using System.Collections.Generic;

#nullable disable

namespace OdosVids.Data
{
    public partial class CustomerSchedule
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VideoId { get; set; }
        public DateTime MessageOn { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Video Video { get; set; }
    }
}
