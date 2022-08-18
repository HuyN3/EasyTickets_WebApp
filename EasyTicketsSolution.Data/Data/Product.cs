using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.WebApp.Data
{
    public partial class Product
    {
        public Product()
        {
            ShowAsignments = new HashSet<ShowAsignment>();
        }

        public int ProductId { get; set; }
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Publisher { get; set; }

        public virtual ICollection<ShowAsignment> ShowAsignments { get; set; }
    }
}
