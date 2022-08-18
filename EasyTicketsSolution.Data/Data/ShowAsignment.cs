using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.WebApp.Data
{
    public partial class ShowAsignment
    {
        public ShowAsignment()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int ShowAsignmentId { get; set; }
        public DateTime? ShowTime { get; set; }
        public decimal? Price { get; set; }
        public int? NumberOfTickets { get; set; }
        public string? Status { get; set; }
        public int? ProductId { get; set; }
        public int? RoomId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Room? Room { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
