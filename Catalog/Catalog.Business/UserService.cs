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
                var userList = GetUsers();
                foreach (var item in userList)
                {
                    if(item == username)
                    {
                        return false;
                        
                    }
                }
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

                var user = db.Users.FirstOrDefault(x => x.Username == username);
                var pass = db.Users.Where(x => x.Username == user.Username).First(x => x.Password == password);
                    if(user != null && pass != null && user.ID == pass.ID)
                    {
                        return true;
                    } 
                    
                    return false;               
              
            }
        }

        public List<string> GetUsers()
        {
            using(var db = new EFCoreContext())
            {
                return db.Users.Select(x => x.Username).ToList();
               
            }
        }
    }
}
