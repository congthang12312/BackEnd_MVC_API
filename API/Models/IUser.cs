using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess;

namespace API.Models
{
    interface IUser
    {
        List<User> findAll();
        User findIdUser(String id);

        User findUserByEmail(String email);

        Boolean insertUser(User user);

        Boolean deleteUser(int id);
    }
}
