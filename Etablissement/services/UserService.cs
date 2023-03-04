using Etablissement.classes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.services
{
    internal class UserService
    {
        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");
        ProfService ps= new ProfService();

        public ProfC isExiste(User log)
        {
            ProfC enseignant = null;
            if (con.State != ConnectionState.Open) { con.Open(); }
            string sql = "SELECT COUNT(*) FROM user WHERE username='" + log.Username.Replace("'", "''") + "' AND password='" + log.Password.Replace("'", "''") + "'";
            MySqlCommand req = new MySqlCommand(sql, con);
           MySqlDataReader dataReader = req.ExecuteReader();

            try
            {
                if (dataReader.Read())
                {
                    int count = dataReader.GetInt32(0);
                    if (count == 1)
                        enseignant = ps.findProfCByUsername(log.Username);
                }

                return enseignant;
            }
            finally
            {
                con.Close();
            }
        }

        public string getPasswordByLogin(string login)
        {
            string password = null;
         
            string sql = "SELECT password FROM user WHERE username='" + login + "';";
            if (con.State != ConnectionState.Open) { con.Open(); }

            MySqlCommand req = new MySqlCommand(sql, con);
            MySqlDataReader dataReader = req.ExecuteReader();
            try
            {
                if (dataReader.Read())
                {
                    password = dataReader[0].ToString();
                }
                return password;
            }
            finally
            {
                con.Close();   
            }
        }
    }
}
