using Etablissement.classes;
using Etablissement.DAO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etablissement.services
{
    internal class SpecService : Dao<SpecialiteC>
    {
        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");

        public void ajouter(SpecialiteC c)
        {
            throw new NotImplementedException();
        }

        public void modifier(SpecialiteC c)
        {
            throw new NotImplementedException();
        }

      
        public void supprimer(int id)
        {
            throw new NotImplementedException();
        }

        public void afficher(SpecialiteC c)
        {
            throw new NotImplementedException();
        }

        public void searchById(int id)
        {
            throw new NotImplementedException();
        }

        public int getSPbyNom(String nS)
        {
            int c = 0;

            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

                MySqlCommand cmd = new MySqlCommand("select id from specialite where nom='" + nS + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c = (int)reader[0];

                }
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("getSPbyNom sql !!");
                Console.WriteLine(ex.Message);

            }
            return c;

        }

    }
}
