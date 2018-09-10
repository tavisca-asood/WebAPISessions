using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CarProduct
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }
        public bool Booked { get; set; }
        public bool Saved { get; set; }
    }
}
