using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.Data.Data
{
    public partial class ShowType
    {
        public ShowType()
        {
            Products = new HashSet<Product>();
        }

        public int ShowTypeId { get; set; }
        public string? ShowTypeName { get; set; }
        public string? ShowTypeDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
