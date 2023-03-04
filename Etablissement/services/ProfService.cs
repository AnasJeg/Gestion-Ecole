using Etablissement.classes;
using Etablissement.DAO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Etablissement.services
{
    internal class ProfService : Dao<ProfC>
    {
        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");


        public void ajouter(ProfC c)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("INSERT INTO prof(nom,prenom,cin,email,age,sexe,ville,telephone,adresse,image,salaire,id_filiere,login) VALUES (@1,@2,@3,@4,@age,@5,@6,@7,@8,@9,@s,@10,@11)", con);
                req.Parameters.AddWithValue("@1", c.Nom);
                req.Parameters.AddWithValue("@2", c.Prenom);
                req.Parameters.AddWithValue("@3", c.Cin);
                req.Parameters.AddWithValue("@4", c.Email);
                req.Parameters.AddWithValue("@age", c.Age);
                req.Parameters.AddWithValue("@5", c.Sexe);          
                req.Parameters.AddWithValue("@6", c.Ville);             
                req.Parameters.AddWithValue("@7", c.Telephone);
                req.Parameters.AddWithValue("@8", c.Adresse);        
                req.Parameters.AddWithValue("@9", c.Image);
                req.Parameters.AddWithValue("@s", c.Salaire);
                req.Parameters.AddWithValue("@10", c.Id_filiere);
                req.Parameters.AddWithValue("@11", c.Login);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("add Prof sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void modifier(ProfC c)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("UPDATE  prof SET nom=@1 ,  prenom=@2 ,cin=@3, email=@4,age=@age, sexe=@5,ville=@6, telephone=@7 , adresse=@8,salaire=@s, id_filiere=@10, login=@11 WHERE id=@id", con);
                req.Parameters.AddWithValue("@1", c.Nom);
                req.Parameters.AddWithValue("@2", c.Prenom);
                req.Parameters.AddWithValue("@3", c.Cin);
                req.Parameters.AddWithValue("@4", c.Email);
                req.Parameters.AddWithValue("@age", c.Age);
                req.Parameters.AddWithValue("@5", c.Sexe);
                req.Parameters.AddWithValue("@6", c.Ville);
                req.Parameters.AddWithValue("@7", c.Telephone);
                req.Parameters.AddWithValue("@8", c.Adresse);
                // req.Parameters.AddWithValue("@9", c.Image);
                req.Parameters.AddWithValue("@s", c.Salaire);
                req.Parameters.AddWithValue("@10", c.Id_filiere);
                req.Parameters.AddWithValue("@11", c.Login);
                req.Parameters.AddWithValue("@id", c.Id);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("Update Prof sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void supprimer(int id)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("DELETE FROM  prof WHERE id='" + id + "'", con);

                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("delete prof sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void afficher(ProfC c)
        {
            throw new NotImplementedException();
        }

        public void searchById(int id)
        {
            throw new NotImplementedException();
        }

        public int getIdProfByCIN(String a)
        {
            if (con.State != ConnectionState.Open) { con.Open(); }
            int c = 0;
            MySqlCommand cmd = new MySqlCommand("select id from prof where cin='" + a + "'", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                c = (int)reader[0];

            }
            con.Close();
            return c;
        }

        public String get_CIN_ProfBy_Nom(String nom)
        {
            if (con.State != ConnectionState.Open) { con.Open(); }
            String c = null;
            MySqlCommand cmd = new MySqlCommand("select cin from prof where nom='" + nom + "'", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                c = reader[0].ToString();

            }
            con.Close();
            return c;
        }

        public int getId_ProfByNom(String a)
        {
            if (con.State != ConnectionState.Open) { con.Open(); }
            int c = 0;
            MySqlCommand cmd = new MySqlCommand("select id from prof where nom='" + a + "'", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                c = (int)reader[0];

            }
            con.Close();
            return c;
        }

       

        public ProfC findProfCByUsername(string username)
        {
            ProfC enseignant = null;
            if (con.State != ConnectionState.Open) { con.Open(); }
            string sql = "SELECT * FROM prof WHERE login='" + username.Replace("'", "''") + "';";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            try
            {
                if (dataReader.Read())
                {
                    enseignant = new ProfC();

                    enseignant.Id = dataReader.GetInt32(0);
                    enseignant.Nom = dataReader[1].ToString().ToUpper();
                    enseignant.Prenom = char.ToUpper(dataReader[2].ToString().First()) + dataReader[2].ToString().Substring(1).ToLower();
                    enseignant.Cin = dataReader[3].ToString();
                    enseignant.Email = dataReader[4].ToString();
                    enseignant.Age =int.Parse (dataReader[5].ToString());
                    enseignant.Sexe = dataReader[6].ToString();
                    enseignant.Ville = dataReader[7].ToString();
                    enseignant.Telephone = dataReader[8].ToString();
                    enseignant.Adresse = dataReader[9].ToString();
                   


                    if (dataReader[10] != System.DBNull.Value)
                    {
                        byte[] bytes = (byte[])dataReader[10];
                        MemoryStream ms = new MemoryStream(bytes);
                        if (bytes != null && bytes.Length > 0)

                            enseignant.Image = ms.ToArray();
                        else
                            enseignant.Image = null;

                    }
                    else
                        enseignant.Image = null;
                    enseignant.Salaire= Double.Parse(dataReader[11].ToString());
                    enseignant.Id_filiere = int.Parse(dataReader[12].ToString());
                    enseignant.Login = dataReader[13].ToString();
                }
                return enseignant;
            }
            finally
            {
                con.Close();    
            }
        }
    }
}
