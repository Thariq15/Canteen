using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenApp.Models
{
    public static class UserSession
    {
        public static int? Id { get; set; }
        public static string Name { get; set; }
        public static string Email { get; set; }
        public static string Phone { get; set; }
        public static string Password { get; set; }

        public static void Logout()
        {
            Id = null;
            Name = null;
            Phone = null;
            Email = null;
            Password = null;
        }
    }
}
