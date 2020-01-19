using DataAccess.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Entities;

namespace Repository
{
    public class LoginRepository : ILoginRepository
    {
        public readonly DevPGSContext _dbContext;
        public LoginRepository(DevPGSContext pGSContext)
        {
            _dbContext = pGSContext;
        }

        public bool AuthenticateUser(string user, string pass)
        {
          bool isAuthenticated =  _dbContext.Users.Any(x => x.userId == user && x.password == pass);
          
         
          return isAuthenticated;
        }

        public List<Users> GetListaUsers()
        {
            return _dbContext.Users.ToList();
        }
    }
}
