using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class RegisterLocal
    {
        public string id { get; set; }

        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public string hashPassword(string password)
        {
            return this.password = password + "00000000";
        }

        public override string ToString()
        {
            return "Person: " + id + "  " + fullname + " " + email + " " + password;
        }

    }
}