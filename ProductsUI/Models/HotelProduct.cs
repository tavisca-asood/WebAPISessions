using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsUI.Models
{
    using System;
    using System.Collections.Generic;

    public partial class HotelProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public bool Booked { get; set; }
        public bool Saved { get; set; }
    }
}