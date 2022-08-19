using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.WebApp.Data
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int BookingId { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? DateBooking { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
