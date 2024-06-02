using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenApp.Models
{
    internal class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public UserModel(string name, string email, string phone, string password)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}
