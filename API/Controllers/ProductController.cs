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