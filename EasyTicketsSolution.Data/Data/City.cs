using System;
using System.Collections.Generic;

namespace EasyTicketsSolution.WebApp.Data
{
    public partial class City
    {
        public int CityId { get; set; }
        public string? Name { get; set; }
        public long? ZipCode { get; set; }
    }
}
