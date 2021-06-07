using API.Models;
using DatabaseAccess;
using System.Collections.Generic;
using System.Web.Http;
using RouteAttribute = System.Web.Http.RouteAttribute;


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
        [Route("listProduct/{id}")]
        [HttpGet]
        public Product GetPro(string id)
        {
            return prodRepos.findProduct(id);
        }

    }
}