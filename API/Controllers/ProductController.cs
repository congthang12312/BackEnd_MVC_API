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
        
        [Route("listProduct")]
        [HttpGet]
        public List<Product> GetListProduct()
        {
            return productRepos.listProduct();
        }
       
        [HttpGet]
        public Product GetProduct(string id)
        {
            return productRepos.findProduct(id);
        }
       

    }
}