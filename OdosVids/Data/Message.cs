using System;
using System.Collections.Generic;

#nullable disable

namespace OdosVids.Data
{
    public partial class Message
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public DateTime EventDate { get; set; }
        public string Message1 { get; set; }
        public DateTime? SentOn { get; set; }

        public virtual Child Child { get; set; }
    }
}
