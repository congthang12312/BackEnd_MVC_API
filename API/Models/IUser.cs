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

        Boolean insertUser(User user);

        Boolean deleteUser(string id);

        User findUserByEmail(String email);

        List<HistoryBuy> getHistoryBuy();
    }
}
