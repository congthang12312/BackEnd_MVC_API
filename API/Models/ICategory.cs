using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    interface ICategory
    {
         List<Category> ListCategory();
    }
}