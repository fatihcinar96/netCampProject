using Catalog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Business
{
    public class UserService
    {
        public bool Register(string username,string password)
        {
            using (var db = new EFCoreContext())
            {
                var user = new User
                {
                    Username = username,
                    Password = password
                };
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
        }

        public bool Login(string username,string password)
        {
            using(var db = new EFCoreContext())
            {
                db.Users.FirstOrDefault(x => x.Username == username);
                db.Users.FirstOrDefault(x => x.Password == password);
                return true;
              
            }
        }
    }
}
