using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
   public interface ILoginRepositoty
    {
        bool AuthenticateUser(string user, string pass);
        List<Users> GetListaUsers();
    }
}
