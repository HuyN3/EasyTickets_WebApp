using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.Data.Data
{
    public partial class ShowAsignment
    {
        public ShowAsignment()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int ShowAsignmentId { get; set; }
        public int? NumberOfTicket { get; set; }
        public DateTime? ShowTime { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }
        public int? ProductId { get; set; }
        public int? RommId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Room? Romm { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
