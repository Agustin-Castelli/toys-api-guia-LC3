﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class UserDTO
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int? role_id { get; set; }
        public bool? state { get; set; }
    }
}