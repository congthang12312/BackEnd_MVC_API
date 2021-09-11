using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public interface ICategory
    {
        List<DatabaseAccess.Category> listCategory();
        List<Product> findCategory(string category);

        // code cua Thang
        List<Category> ListCategory();

    }
}