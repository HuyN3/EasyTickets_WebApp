using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.Data.Data
{
    public partial class Theater
    {
        public Theater()
        {
            Rooms = new HashSet<Room>();
            Services = new HashSet<Service>();
        }

        public int TheaterId { get; set; }
        public string? TheaterName { get; set; }
        public long? TheaterPhone { get; set; }
        public string? TheaterAddress { get; set; }
        public int? CityId { get; set; }

        public virtual City? City { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
