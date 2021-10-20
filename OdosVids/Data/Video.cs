using System;
using System.Collections.Generic;

#nullable disable

namespace OdosVids.Data
{
    public partial class Video
    {
        public Video()
        {
            CustomerSchedules = new HashSet<CustomerSchedule>();
        }

        public int Id { get; set; }
        public string VideoName { get; set; }
        public string VideoDesc { get; set; }
        public string VideoLink { get; set; }

        public virtual ICollection<CustomerSchedule> CustomerSchedules { get; set; }
    }
}
