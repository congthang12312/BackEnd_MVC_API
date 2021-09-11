using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class DataRespon<T>
    {
        public bool error { get; set; }
        public string message { get; set; }

        public T data { get; set; }
    }
}