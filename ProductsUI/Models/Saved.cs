﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsUI.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Saved
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Nullable<double> Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Date { get; set; }
    }
}