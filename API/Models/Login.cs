﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }

        public string token { get; set; }

    }
}