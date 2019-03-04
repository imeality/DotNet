using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenBased.Models
{
    public class UserRepository:IDisposable
    {
        CvaniEntities context = new CvaniEntities();
        public UserMaster ValidateUser(string username,string password)
        {
            return context.UserMasters.FirstOrDefault(user => user.UserName.Equals(username) && user.UserPassword == password);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}