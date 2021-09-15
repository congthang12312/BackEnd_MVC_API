using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatabaseAccess;
using System.Web.Http.Cors;
using API.Helper;
using System.Diagnostics;

namespace API.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class AdminController : ApiController
    {
        // GET: api/Admin
        IUser userRepos = new UserRepos();
        [AllowAnonymous]
        //[CustomAuthentication("ADMIN")]
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

        [HttpGet]
        [Route("delete-user/{id}")]
        public Boolean Post(string id)
        {
            return userRepos.deleteUser(id);
        }

        [HttpGet]
        [Route("get-history")]
        public List<HistoryBuy> getHistory()
        {
            return userRepos.getHistoryBuy();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public DataRespon<Login> Login(Login login)
        {
            DataRespon<Login> respon = new DataRespon<Login>();
            try
            {
                User isExist = userRepos.findUserByEmail(login.email);
                if (isExist != null)
                {
                    Debug.WriteLine(login.email);
                    Debug.WriteLine(login.password);
                    String hashPassword = login.password + "00000000";
                    if (login.email == "admin@gmail.com") hashPassword = login.password;
                    bool isMatchPassword = String.Equals(hashPassword, isExist.password);

                    if (isMatchPassword == true)
                    {

                        User userToken = new User();
                        DataRespon<string> responToken = new DataRespon<string>();

                        userToken.id = isExist.id;
                        userToken.role = isExist.role;
                        userToken.fullname = isExist.fullname;
                        userToken.email = isExist.email;

                        String token = TokenManager.generateToken(userToken);
                        Login userLoginRespon = new Login();
                        userLoginRespon.token = token;

                        respon.message = "Đăng nhập thành công";
                        respon.error = false;
                        respon.data = userLoginRespon;
                        return respon;

                    }
                    else
                    {

                        respon.error = true;
                        respon.message = "notMatchPassword";
                        return respon;
                    }
                }
                else
                {
                    respon.error = true;
                    respon.message = "userNotExist";
                    return respon;
                }

            }
            catch
            {
                respon.error = true;
                respon.message = "errorLogin";
                return respon;
            }
        }

        //[WebApiJWT]
        [AllowAnonymous]
        [HttpPost]
        [Route("registerLocal")]
        public DataRespon<String> registerLocal([FromBody] RegisterLocal useRegister)
        {
            DataRespon<String> respon = new DataRespon<String>();

            try
            {
              
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
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                    if (rs == true)
                    {
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
                else
                {
                    // emmail da ton tai
                    respon.message = "emailExist";
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

    }
}
