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

        public Users AuthenticateUser(string user, string pass)
        {
            return  _dbContext.Users.FirstOrDefault(x => x.userId == user && x.password == pass);
            
        }

        public List<Users> GetListaUsers()
        {
            return _dbContext.Users.ToList();
        }
    }
}
