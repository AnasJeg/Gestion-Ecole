using Etablissement.classes;
using Etablissement.DAO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Drawing;
using Image = System.Drawing.Image;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Etablissement.services
{
    internal class EtudService : Dao<StudentC>
    {
        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");
      

        public void ajouter(StudentC c)
        {   
        try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
    MySqlCommand req = new MySqlCommand("INSERT INTO etudiants(nom,prenom,cin,cne,email,age,sexe,date_naissance,ville,telephone,adresse,image,id_filiere,niveau,groupe) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)", con);
                req.Parameters.AddWithValue("@1", c.Nom);
                req.Parameters.AddWithValue("@2", c.Prenom);
                req.Parameters.AddWithValue("@3", c.Cin);
                req.Parameters.AddWithValue("@4", c.Cne);
                req.Parameters.AddWithValue("@5", c.Email);
                req.Parameters.AddWithValue("@6", c.Age);
                req.Parameters.AddWithValue("@7", c.Sexe);
                req.Parameters.AddWithValue("@8", c.Date_N);
                req.Parameters.AddWithValue("@9", c.Ville);
                req.Parameters.AddWithValue("@10",c.Telephone);
                req.Parameters.AddWithValue("@11",c.Address);
                // req.Parameters.AddWithValue("@12",c.Image);
                req.Parameters.AddWithValue("@12", File.ReadAllBytes(c.Image.Tag.ToString()));
                req.Parameters.AddWithValue("@13",c.Filiere);
                req.Parameters.AddWithValue("@14",c.Niveau);
                req.Parameters.AddWithValue("@15",c.Groupe);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
{
    DialogResult dd = MessageBox.Show("add etudiants sql !!");
    Console.WriteLine(ex.Message);

}
        }

        public void modifier(StudentC c)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("UPDATE  etudiants SET nom=@1 ,  prenom=@2 ,cin=@3, cne=@4, email=@5, age=@6, sexe=@7, date_naissance=@8, ville=@9, telephone=@10 , adresse=@11, id_filiere=@13, niveau=@14, groupe=@15  WHERE id=@id", con);
                req.Parameters.AddWithValue("@1", c.Nom);
                req.Parameters.AddWithValue("@2", c.Prenom);
                req.Parameters.AddWithValue("@3", c.Cin);
                req.Parameters.AddWithValue("@4", c.Cne);
                req.Parameters.AddWithValue("@5", c.Email);
                req.Parameters.AddWithValue("@6", c.Age);
                req.Parameters.AddWithValue("@7", c.Sexe);
                req.Parameters.AddWithValue("@8", c.Date_N);
                req.Parameters.AddWithValue("@9", c.Ville);
                req.Parameters.AddWithValue("@10", c.Telephone);
                req.Parameters.AddWithValue("@11", c.Address);
                req.Parameters.AddWithValue("@13", c.Filiere);
                req.Parameters.AddWithValue("@14", c.Niveau);
                req.Parameters.AddWithValue("@15", c.Groupe);
                req.Parameters.AddWithValue("@id", c.Id);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("update etudiants sql !!");
                Console.WriteLine(ex.Message);

            }
        }

     

        public void supprimer(int id)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("DELETE FROM  etudiants WHERE id='"+id+"'", con);
               
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("delete etudiants sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void afficher(StudentC c)
        {
            throw new NotImplementedException();
        }

        public void searchById(int id)
        {
            throw new NotImplementedException();
        }

        public StudentC getEtudiant_ById(int id)
        {
          
            StudentC e = null;
           
            string sql = "SELECT * FROM  etudiants WHERE id='" + id + "'";
            if (con.State != ConnectionState.Open) { con.Open(); }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    e = new StudentC();

                    e.Id = reader.GetInt32(0);
                    e.Nom = reader[1].ToString().ToUpper();
                    e.Prenom = reader[2].ToString().ToUpper();
                    e.Cin = reader[3].ToString();
                    e.Cne = reader[4].ToString();
                    e.Email = reader[5].ToString();
                    e.Age = int.Parse(reader[6].ToString());
                    e.Sexe = reader[7].ToString();
                    e.Date_N = DateTime.Parse(reader[8].ToString());
                    e.Ville = reader[9].ToString();
                    e.Telephone = reader[10].ToString();
                    e.Address = reader[11].ToString();

                    if (reader[12] != System.DBNull.Value)
                    {
                        Byte[] bytes = (Byte[])reader[12];
                        if (bytes != null && bytes.Length > 0)

                            e.Image = Image.FromStream(new MemoryStream(bytes));

                        else
                            e.Image = null;

                    }

                    e.Filiere = int.Parse(reader[13].ToString());
                    e.Niveau = int.Parse(reader[14].ToString());
                    e.Groupe = int.Parse(reader[15].ToString());

                }
                return e;
            }
            finally
            {
                con.Close();
            }

        }

        public int getIdEtudiantByCIN(String a)
        {
            if (con.State != ConnectionState.Open) { con.Open(); }
            int c = 0;
            MySqlCommand cmd = new MySqlCommand("select id from etudiants where cin='" + a + "'", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                c = (int)reader[0];

            }
            con.Close();
            return c;
        }


        public List<StudentC> getListEtudiantsBy_Class(int classe)
        {


            StudentC e = null;
          
            List<StudentC> listeEtudiants = null;
            string sql = "SELECT e.* FROM etudiants as e WHERE e.groupe = " + classe + ";";
            if (con.State != ConnectionState.Open) { con.Open(); }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader != null)
                    listeEtudiants = new List<StudentC>();
                while (reader.Read())
                {
                    e = new StudentC();

                    e.Id = reader.GetInt32(0);
                    e.Nom = reader[1].ToString().ToUpper();
                    e.Prenom =reader[2].ToString().ToUpper();
                    e.Cin= reader[3].ToString();
                    e.Cne = reader[4].ToString();
                    e.Email = reader[5].ToString();
                    e.Age =int.Parse(reader[6].ToString());
                    e.Sexe = reader[7].ToString();
                    e.Date_N = DateTime.Parse(reader[8].ToString());
                    e.Ville = reader[9].ToString();
                    e.Telephone = reader[10].ToString();
                    e.Address = reader[11].ToString();

                    if (reader[12] != System.DBNull.Value)
                    {
                        Byte[] bytes = (Byte[])reader[12];
                        if (bytes != null && bytes.Length > 0)

                            e.Image = Image.FromStream(new MemoryStream(bytes));

                        else
                            e.Image = null;

                    }

                    e.Filiere =int.Parse(reader[13].ToString());
                    e.Niveau = int.Parse(reader[14].ToString());
                    e.Groupe = int.Parse(reader[15].ToString());
                   
                    listeEtudiants.Add(e);
                }
                return listeEtudiants;
            }
            finally
            {
               con.Close();
            }
        }

        public Double getNoteByEtudiantMatiere(StudentC ee, Matiere m)
        {

            double note = -1;

            // string sql = "SELECT note FROM note WHERE num_Etud =" + ee.Id + " and numM=" + m.numM + ";";
            string sql = "SELECT note FROM note WHERE num_Etud =" + ee.Id + " and numM=" + m.Id+ ";";
            if (con.State != ConnectionState.Open) { con.Open(); }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    note = reader.GetDouble(0);
                }
                return note;
            }
            finally
            {
               con.Close();
            }
        }


        public GroupesC getGroupe_ByNum(int num)
        {
            GroupesC classe = null;
            string sql = "SELECT * FROM groupes WHERE id=" + num + ";";

            if (con.State != ConnectionState.Open) { con.Open(); }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dataReader = cmd.ExecuteReader();


            try
            {
                if (dataReader.Read())
                {
                    classe = new GroupesC();

                    classe.Id = dataReader.GetInt32(0);
                    classe.NomG = dataReader.GetString(1);
                    classe.NbrEtudiants = dataReader.GetInt32(2);
                    classe.NumSalle = dataReader.GetString(3);
                    classe.Id_filiere = dataReader.GetInt32(4);
                }
                return classe;
            }
            finally
            {
              con.Close() ;
            }
        }

        public FiliereC getFiliereByEtudiant(StudentC etudiant)
        {
            FiliereC filiere = null;
            string sql = "SELECT distinct f.* FROM filiere f,etudiants e WHERE f.id_groupe='"+etudiant.Groupe+"' AND e.groupe='"+etudiant.Groupe+"'";

            if (con.State != ConnectionState.Open) { con.Open(); }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            try
            {
                if (dataReader.Read())
                {
                    filiere = new FiliereC();
                    filiere.Id = dataReader.GetInt32(0);
                    filiere.Nom = dataReader.GetString(1);
                    filiere.Id_resp = dataReader.GetInt32(2);
                    filiere.Nombre_module = dataReader.GetInt32(3);
                    filiere.Id_groupe = dataReader.GetInt32(4);
                }
                return filiere;
            }
            finally
            {
                con.Close();
            }
        }


    }
}
