﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class categories
    {
        public categories()
        {
            toys = new HashSet<toys>();
        }

        public int category_code { get; set; }
        public string category_name { get; set; }
        public bool? state { get; set; }

        public virtual ICollection<toys> toys { get; set; }
    }
}