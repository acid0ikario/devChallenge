using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
   public interface ILoginRepository
    {
        Users AuthenticateUser(string user, string pass);
        List<Users> GetListaUsers();
    }
}
