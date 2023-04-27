using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public enum RoleType
    {
        ADMIN,
        USER
    }
    public class Roles
    {
        public static string Password { get; set; }
        public static RoleType Role { get; set; }

        static Roles()
        {
            Password = "qwerty";
        }

    }

}
