using API.Models;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Cors;
using RouteAttribute = System.Web.Http.RouteAttribute;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;

namespace API.Controllers
{
    public class ProductController : ApiController
    {
        // GET: Product
        IProduct prodRepos = new ProductRepo();
        [Route("listProduct")]
        [HttpGet]
        public List<Product> GetListPro()
        {
            return prodRepos.listProduct();
        }
        

        [HttpGet]
        public Product GetProduct(int id)
        {
            return prodRepos.findIdProduct(id);

        }
    }
}