//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WhatEatToday.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Owner
    {
        [Display(Name = "Owner ID")]
        public int owner_id { get; set; }
        
        public string login { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        public string token { get; set; }
        [Display(Name = "Shop ID")]
        public int shop_id { get; set; }
        
        public virtual Shop Shop { get; set; }
    }
}
