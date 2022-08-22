using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.Data.Data
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Roles = new HashSet<Role>();
        }

        public int UserId { get; set; }
        public string? FullName { get; set; }
        public int? Gender { get; set; }
        public long? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
