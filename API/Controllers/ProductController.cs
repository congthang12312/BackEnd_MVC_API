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

        [Route("numpageProduct")]
        [HttpGet]
        public int GetNumPageProduct()
        {
            List<Product> list = new List<Product>();
            list = productRepos.listProduct();
            int quantityProductInOnePage = 3;
            int totalUser = list.Count;
            int numPageUser = totalUser / quantityProductInOnePage;
            if (totalUser % quantityProductInOnePage != 0)
            {
                numPageUser++;
            }
            return numPageUser;
        }

        // lay product theo page
        [Route("listProductPage/{page}")]
        [HttpGet]
        public List<Product> GetProduct(int page)
        {
            return productRepos.listProductByPage(page);
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

        [Route("update-product")]
        [HttpPost]
        public Boolean updateProduct([FromBody] Product product)
        {
            return productRepos.updateProduct(product);
        }

    }
}