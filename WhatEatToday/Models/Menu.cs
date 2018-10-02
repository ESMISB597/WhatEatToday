using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhatEatToday.Models
{
    public class Menu
    {
        [Key]
        public int menu_id { get; set; }

        public int shop_id { get; set; }
        public string menu_name { get; set; }
        public string comment { get; set; }
    }
}