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
       
        //Cap nhat lai so luong sau khi nguoi dung mua hang
        Boolean updateProduct(string id, int amount);
    }
}