using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class HistoryBuy
    {
        public  long stt { get; set; }
        public String id { get; set; }
        public String fullName { get; set; }
        public String email { get; set; }
        public String address { get; set; }
        public String idProduct { get; set; }
        public String nameProduct { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public DateTime createAt { get; set; }
        public double total { get; set; }


    }
}