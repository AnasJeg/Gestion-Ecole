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
    internal class GroupeService : Dao<GroupesC>
    {
        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");


        // id_fil
        public void ajouter(GroupesC c)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("INSERT INTO groupes(nomG,nbrEtudiants,numSalle,id_fil) values (@1,@2,@3,@4)", con);
                req.Parameters.AddWithValue("@1", c.NomG);
                req.Parameters.AddWithValue("@2", c.NbrEtudiants);
                req.Parameters.AddWithValue("@3", c.NumSalle);
                req.Parameters.AddWithValue("@4", c.Id_filiere);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("add Filiere sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void modifier(GroupesC c)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("UPDATE groupes SET  nomG=@1, nbrEtudiants=@2,numSalle=@3,id_fil=@4 where id=@id", con);
                req.Parameters.AddWithValue("@1", c.NomG);
                req.Parameters.AddWithValue("@2", c.NbrEtudiants);
                req.Parameters.AddWithValue("@3", c.NumSalle);
                req.Parameters.AddWithValue("@4", c.Id_filiere);
                req.Parameters.AddWithValue("@id", c.Id);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("Update groupes sql !!");
                Console.WriteLine(ex.Message);

            }
        }


        // id nomG nbrEtudiants numSalle id_fil
        public void supprimer(int id)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("DELETE FROM  groupes WHERE id = '" + id + "'", con);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("Delete groupes sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void afficher(GroupesC c)
        {
            throw new NotImplementedException();
        }

        public void searchById(int id)
        {
            throw new NotImplementedException();
        }

        public int get_idGroupe_byNom(String nG)
        {
            int c = 0;

            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

                MySqlCommand cmd = new MySqlCommand("select id from groupes where nomG='" + nG + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c = (int)reader[0];

                }
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("get_idGroupe_byNom sql !!");
                Console.WriteLine(ex.Message);

            }
            return c;

        }

        public String get_NomGroupe_byId(int nG)
        {
            String c = null;

            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

                MySqlCommand cmd = new MySqlCommand("select nomG from groupes where id='" + nG + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c = reader[0].ToString();

                }
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("get_NomGroupe_byId sql !!");
                Console.WriteLine(ex.Message);

            }
            return c;

        }

    }
}
