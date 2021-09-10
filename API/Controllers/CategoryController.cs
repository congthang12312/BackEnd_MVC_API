using API.Models;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Web.Http;
using CategoryRepo = API.Models.CategoryRepo;
using RouteAttribute = System.Web.Http.RouteAttribute;


namespace API.Controllers
{
    public class CategoryController : ApiController
    {
        // GET: ProductMacbook Pro 2021
        ICategory category = new CategoryRepo();


        [Route("listCategory")]
        [HttpGet]
        public List<Category> GetListCategory()
        {
            return category.listCategory();
        }


        [Route("findCategory/{categoryName}")]
        [HttpGet]
        public List<Product> GetCategory(string categoryName)
        {
            return category.findCategory(categoryName);
        }

       
    }
}