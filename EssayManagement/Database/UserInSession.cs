using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssayManagement.Database
{
    internal class UserInSession
    {
        private static string loggedInUser;
        public static string LoggedInUser
        {
            get { return loggedInUser; }
            set { loggedInUser = value; }
        }
    }
}
