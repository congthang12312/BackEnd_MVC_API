using API.Models;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Web.Http;
using RouteAttribute = System.Web.Http.RouteAttribute;


namespace API.Controllers
{
    public class ProductController : ApiController
    {
        // GET: ProductMacbook Pro 2021
        IProduct prodRepos = new ProductRepos();
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

        [Route("numpageProduct")]
        [HttpGet]
        public int GetNumPageProduct()
        {
            List<Product> list = new List<Product>();
            list = prodRepos.listProduct();
            int quantityProductInOnePage = 10;
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
            return prodRepos.listProductByPage(page);
        }
        // them 1 product
        [Route("add-product")]
        [HttpPost]
        public Boolean AddProduct([FromBody] Product product)
        {
            return prodRepos.addProduct(product);
        }

        [HttpPost]
        [Route("delete-product/{id}")]
        public Boolean Post([FromUri] String id)
        {
            return prodRepos.deleteProduct(id);
        }

        [Route("update-product")]
        [HttpPost]
        public Boolean updateProduct([FromBody] Product product)
        {
            return prodRepos.updateProduct(product);
        }

        //Cap nhat lai so luong sau khi nguoi dung mua hang
        [Route("payment/{id}/{amount}")]
        [HttpGet]
        public Boolean payment(String id, int amount)

        {
           return prodRepos.updateProduct(id, amount);
        }


        //phan trang: 9sp 1 trang
        [Route("pages/{page}")]
        [HttpGet]
        public List<Product> GetListProInPage(int page)
        {
            return prodRepos.listProductInPage(page, 9);

        }
    }
}