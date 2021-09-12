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

        [HttpPost]
        [Route("delete-user/{id}")]
        public Boolean Post([FromUri] int id)
        {
            return userRepos.deleteUser(id);
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
                    bool isMatchPassword = String.Equals(login.password, isExist.password);

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
                    User infoUser = new User();
                    infoUser.id = generate_id;
                    infoUser.role = 1;
                    infoUser.fullname = useRegister.fullname;
                    infoUser.email = useRegister.email;
                    infoUser.password = useRegister.password;
                    bool isCreateSuccess = userRepos.insertUser(infoUser);
                    if (isCreateSuccess == true)
                    {
                        infoUser.password = null;
                        String token = TokenManager.generateToken(infoUser);
                        respon.message = "Tạo tài khoản thành công!";
                        respon.error = false;
                        respon.data = token;
                        return respon;
                    }
                    else
                    {
                        respon.message = "Tạo tài khoản thất bại!";
                        respon.error = true;
                        respon.data = null;
                        return respon;
                    }
                }
                else
                {
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
