using BETTER.DataAccessLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BETTER.BusinessLayer.Classes
{
    public class User
    {

        public string UserEmail { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
        
        public string UserPasscode { get; set; }
        
        public string UserParentEmail { get; set; }

        public void AddUser()
        {
            UserDAL obj = new UserDAL();
            obj.AddUser(UserEmail, UserName, FirstName, LastName, UserPasscode, UserParentEmail);
        } 

    }
}