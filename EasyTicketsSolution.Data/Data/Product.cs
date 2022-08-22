using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.Data.Data
{
    public partial class Product
    {
        public Product()
        {
            ShowAsignments = new HashSet<ShowAsignment>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? Publisher { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Image { get; set; }
        public int? ShowTypeId { get; set; }

        public virtual ShowType? ShowType { get; set; }
        public virtual ICollection<ShowAsignment> ShowAsignments { get; set; }
    }
}
