using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.WebApp.Data
{
    public partial class BookingDetail
    {
        public int BookingDetailId { get; set; }
        public string? Seat { get; set; }
        public int? Quantity { get; set; }
        public int? BookingId { get; set; }
        public int? ShowAsignmentId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Service? Service { get; set; }
        public virtual ShowAsignment? ShowAsignment { get; set; }
    }
}
