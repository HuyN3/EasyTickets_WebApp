using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.WebApp.Data
{
    public partial class Service
    {
        public Service()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int ServiceId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? TheaterId { get; set; }

        public virtual Theater? Theater { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
