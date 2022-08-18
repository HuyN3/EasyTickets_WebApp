using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.WebApp.Data
{
    public partial class Room
    {
        public Room()
        {
            ShowAsignments = new HashSet<ShowAsignment>();
        }

        public int RoomId { get; set; }
        public string? Name { get; set; }
        public int? TheaterId { get; set; }

        public virtual Theater? Theater { get; set; }
        public virtual ICollection<ShowAsignment> ShowAsignments { get; set; }
    }
}
