using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatabaseAccess;
using System.Web.Http.Cors;
using System.Diagnostics;
using System.Web;
using System.Security.Claims;

// using System.Security.Claims;

namespace API.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class AdminController : ApiController
    {
        // GET: api/Admin
        IUser userRepos = new UserRepos();

        // [WebApiJWT("ADMIN")]
        [AllowAnonymous]
        [HttpGet]
        [Route("get-list-user")]
        public IEnumerable<User> Get()
        {
            return userRepos.findAll();
        }

        // GET: api/Admin/5
        [HttpGet]
        [Route("get-id-user/{id}")]
        public User Get(String id)
        {
            return userRepos.findIdUser(id);
        }

        // POST: api/Admin
        [HttpPost]
        [Route("insert-user")]
        public Boolean Post([FromBody]User user)
        {
            return userRepos.insertUser(user);
        }

        [HttpPost]
        [Route("delete-user/{id}")]
        public Boolean Post([FromUri] int id)
        {
            return userRepos.deleteUser(id);
        }

        [HttpPost]
        [Route("login")]
        public DataRespon<Login> Login([FromBody] Login login)
        {
            User userToken = new User();

            Debug.WriteLine("email ");

            DataRespon<Login> respon = new DataRespon<Login>();

            Debug.WriteLine("email " + login.email);
            Debug.WriteLine("pass " + login.password);
            respon.message = "Thành công";
            respon.error = false;
            respon.data = new Login() { email = login.email, password = login.password };
            return respon;
        }

        //[WebApiJWT]
        [AllowAnonymous]
        [HttpPost]
        [Route("registerLocal")]
        public DataRespon<String> registerLocal([FromBody]RegisterLocal useRegister)
        {
            DataRespon<String> respon = new DataRespon<String>();

            try
            {
                //Debug.WriteLine("okey ne"  + name);
                //Debug.WriteLine("info "+ userRegister.Value);
                //  RegisterLocal new_user = new RegisterLocal();
                //new_user.fullname = userRegister.fullname;
                //     new_user.email = userRegister.email;
                //    new_user.password = userRegister.hashPassword(userRegister.password);
                //   User user_2 = new User();
                //  user_2.fullname = userRegister.fullname;
                //   user_2.email = userRegister.email;
                // user_2.id = "id_2115151515154445";
                //  Debug.WriteLine("xin chao" + user_2);
                //  respon.message = TokenManager.generateToken(user_2);
                //GetPrincipal
                // Debug.WriteLine("day la cia gi day ::: " + TokenManager.GetPrincipal(respon.message).Identity);
                //  Claim usernameClaim = TokenManager.GetPrincipal(respon.message).Identity.FindFirst(ClaimTypes.Name);
                //  username = usernameClaim.Value;
                //  Debug.WriteLine("rs == " + TokenManager.ValidateToken(respon.message).ToString());
                User isExist = userRepos.findUserByEmail(useRegister.email);
                if (isExist == null)
                {
                    Guid myuuid = Guid.NewGuid();
                    string generate_id = myuuid.ToString();

                    User userToken = new User();
                    userToken.id = generate_id;
                    userToken.role = 1;
                    userToken.fullname = useRegister.fullname;
                    userToken.email = useRegister.email;
                    userToken.password = userToken.hashPassword(useRegister.password);
                    userToken.googleID = "null";
                    userToken.facebookID = "null";
                    DateTime localDate = DateTime.Now;
                    userToken.createAt = localDate;
                    userToken.modifyAt = localDate;

                    Boolean rs = false;
                    try
                    {
                        rs = userRepos.insertUser(userToken);
                        Debug.WriteLine("ket qua : " + rs);
                    }
                    catch (Exception ex) {
                        Debug.WriteLine(ex);
                    }
                    if (rs == true) {
                        // GENERATE TOKEN
                        String token = TokenManager.generateToken(userToken);

                        // VALIDATE TOKEN
                        // User de_token = TokenManager.ValidateToken(token);
                        // SET CLAIMS REQUEST
                        // ClaimsPrincipal hehe = TokenManager.GetPrincipal(token);
                        // LOG PROPERTY
                        //Debug.WriteLine("Gi day ta == " + hehe.FindFirst("ROLE").Value);



                        var webRequest = System.Net.WebRequest.Create("https://localhost:44308");
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                        respon.message = "Tạo tài khoản thành công";
                        respon.error = false;
                        respon.data = token;
                        return respon;
                    }
                    else
                    {
                        respon.message = "Không thể tạo tài khoản!";
                        respon.error = true;
                        respon.data = null;
                        return respon;
                    }

                }
                else {
                    respon.message = "Email đã tồn tại!";
                    respon.error = true;
                    respon.data = null;
                    return respon;
                }
            }
            catch 
            {
                respon.message = "Lỗi đăng ký";
                respon.error = true;
                respon.data = null;
                return respon;
            }
        }

        [WebApiJWT]
        [HttpGet]
        [Route("api/data/forall")]
        public IHttpActionResult Gethihi()
        {
            return Ok("Now server time is: " + DateTime.Now.ToString());
        }
    }
}
