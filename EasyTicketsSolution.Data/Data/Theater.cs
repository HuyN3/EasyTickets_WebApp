using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.WebApp.Data
{
    public partial class Theater
    {
        public Theater()
        {
            Rooms = new HashSet<Room>();
            Services = new HashSet<Service>();
        }

        public int TheaterId { get; set; }
        public string? Name { get; set; }
        public long? Phone { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
