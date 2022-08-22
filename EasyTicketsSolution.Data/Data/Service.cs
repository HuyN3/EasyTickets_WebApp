using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.Data.Data
{
    public partial class Service
    {
        public Service()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int ServiceId { get; set; }
        public string? ServiceDescription { get; set; }
        public decimal? ServicePrice { get; set; }
        public int? TheaterId { get; set; }

        public virtual Theater? Theater { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
