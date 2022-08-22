using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.Data.Data
{
    public partial class City
    {
        public City()
        {
            Theaters = new HashSet<Theater>();
        }

        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int? ZipCode { get; set; }

        public virtual ICollection<Theater> Theaters { get; set; }
    }
}
