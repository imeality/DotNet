using CodeFirstApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstApi.Models
{
    public class UserRepository:IDisposable
    {
        private HealthPlusContext dbContext = new HealthPlusContext();
        public User ValidateUser(string username,string password)
        {
            return dbContext.Users.FirstOrDefault(user => user.UserName.Equals(username) && user.Password == password);
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}