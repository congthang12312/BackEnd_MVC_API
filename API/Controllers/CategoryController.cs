using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatabaseAccess;
using System.Web.Http.Cors;
namespace API.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class CategoryController : ApiController
    {
        ICategory categoryRes = new CategoryRes();
       
        [HttpGet]
        [Route("get-list-category")]
        public IEnumerable<Category> Index()
        {
            return categoryRes.ListCategory();  
        }
     

    }    
    
}
