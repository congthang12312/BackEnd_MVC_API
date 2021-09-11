using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    interface IProduct
    {
        List<Product> listProduct();

        Product findProduct(string id);

        Boolean addProduct(Product product);

        Boolean deleteProduct(String id);
        List<Product> listProductByPage(int page);

        Boolean updateProduct(Product product);
    }
}