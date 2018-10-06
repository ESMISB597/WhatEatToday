using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhatEatToday.Models
{
    public class Shop
    {
        [Key] //primary key
        public int shop_id { get; set; }

        public string name { get; set; }
        public string location { get; set; }
        public string details { get; set; }
        public string type { get; set; }
        public string pic { get; set; }

    }
}