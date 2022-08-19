﻿using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.WebApp.Data
{
    public partial class User
    {
        public User()
        {
            //  Customers = new HashSet<Customer>();
            Bookings = new HashSet<Booking>();
            Roles = new HashSet<Role>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
        public virtual Customer? Customer { get; set; }
        // public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
