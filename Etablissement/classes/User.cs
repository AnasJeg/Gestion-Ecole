using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.classes
{
    internal class User
    {
        private int id;
        private string username;
        private string password;
        private static int cnt = 0;

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public User(string username, string password)
        {
            this.Id = ++cnt;
            this.Username = username;
            this.Password = password;
        }
    }
}
