using API.Models;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using RouteAttribute = System.Web.Http.RouteAttribute;


namespace API.Controllers
{
    public class ProductController : ApiController
    {
        IProduct productRepos = new ProductRepo();
        // danh sach product
        [Route("listProduct")]
        [HttpGet]
        public List<Product> GetListProduct()
        {
            return productRepos.listProduct();
        }
        // lay 1 product
        [Route("listProduct/{id}")]
        [HttpGet]
        public Product GetProduct(string id)
        {
            return productRepos.findProduct(id);
        }
        // them 1 product
        [Route("add-product")]
        [HttpPost]
        public Boolean AddProduct([FromBody] Product product)
        {
            return productRepos.addProduct(product);
        }

        [HttpPost]
        [Route("delete-product/{id}")]
        public Boolean Post([FromUri] String id)
        {
            return productRepos.deleteProduct(id);
        }
      
        //Cap nhat lai so luong sau khi nguoi dung mua hang
        [Route("payment/{id}/{amount}")]
        [HttpGet]
        public Boolean payment(String id, int amount)

        {
           return prodRepos.updateProduct(id, amount);
        }


    }
}