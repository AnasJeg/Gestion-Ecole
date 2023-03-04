using Etablissement.classes;
using Etablissement.DAO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etablissement.services
{
    internal class MatiereService : Dao<Matiere>
    {
      

        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");


        public void ajouter(Matiere c)
        {

            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); } 
                MySqlCommand req = new MySqlCommand("INSERT INTO matiere(nomM,nbrHeures,id_prof,id_filiere,image) values (@1,@2,@3,@4,@5)", con);
                req.Parameters.AddWithValue("@1", c.NomM);
                req.Parameters.AddWithValue("@2", c.Nbrheures);
                req.Parameters.AddWithValue("@3", c.Num_Ens);
                req.Parameters.AddWithValue("@4", c.Id_filiere);
                req.Parameters.AddWithValue("@5", c.Image);

                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("add matiere sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void modifier(Matiere c)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("UPDATE matiere SET  nomM=@1, nbrHeures=@2,id_prof=@3, id_filiere=@4, image=@5 where id=@id", con);
                req.Parameters.AddWithValue("@1", c.NomM);
                req.Parameters.AddWithValue("@2", c.Nbrheures);
                req.Parameters.AddWithValue("@3", c.Num_Ens);
                req.Parameters.AddWithValue("@4", c.Id_filiere);
                req.Parameters.AddWithValue("@5", c.Image);
                req.Parameters.AddWithValue("@id", c.Id);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("Update matiere sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void searchById(int id)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("DELETE FROM  matiere WHERE id = '" + id + "'", con);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("Delete matiere sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void supprimer(int id)
        {
            throw new NotImplementedException();
        }

        public void afficher(Matiere c)
        {
            throw new NotImplementedException();
        }

        public int getId_Mod_byNom(String nM)
        {
            int c = 0;

            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

                MySqlCommand cmd = new MySqlCommand("select id from matiere where nomM='" + nM + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c = (int)reader[0];

                }
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("getId_Mod_byNom sql !!");
                Console.WriteLine(ex.Message);

            }
            return c;

        }

        public List<Matiere> getListMatieresByEnseignantFiliere(ProfC ens, FiliereC f)
        {
            List<Matiere> listeMatieres = null;
           /*
            string sql = "SELECT distinct m.* FROM filiere_matiere fm, filiere f, enseignant e, matiere m " +
                         "WHERE m.num_ens=e.num_ens and m.numM=fm.numM and e.num_ens=" + ens.num_Ens + " and fm.numF=" + f.numF + " ;";
            */
            string sql = "SELECT distinct m.* FROM  matiere m,  filiere f, prof e WHERE m.id_prof=e.id and m.id_filiere=f.id and e.id=" + ens.Id + " and f.id="+ f.Id+" ;";
            if (con.State != ConnectionState.Open) { con.Open(); }

            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader dataReader = cmd.ExecuteReader();
            try
            {
                if (dataReader != null)
                    listeMatieres = new List<Matiere>();
                while (dataReader.Read())
                {
                    Matiere m = new Matiere();

                    m.Id = dataReader.GetInt32(0);
                    m.NomM = dataReader.GetString(1);
                    m.Nbrheures = dataReader.GetInt32(2);
                    
                    try { m.Num_Ens = dataReader.GetInt32(3); }
                    catch (Exception ex) { }
                    try { m.Id_filiere = dataReader.GetInt32(4); }
                    catch (Exception ex) { }
                    if (dataReader[5] != System.DBNull.Value)
                    {
                        Byte[] bytes = (Byte[])dataReader[5];
                        if (bytes != null && bytes.Length > 0)
                              m.Image = Image.FromStream(new MemoryStream(bytes));
                         
                        else
                            m.Image = null;
                    }
                    else
                        m.Image = null;

                    listeMatieres.Add(m);
                }
                return listeMatieres;
            }
            finally
            {
                    con.Close();
            }
        }

        public Matiere findMatiereBy_Name(string nom)
        {
            Matiere matiere = null;
            string sql = "SELECT * FROM matiere WHERE nomM ='" + nom.Replace("'", "''") + "';";

            if (con.State != ConnectionState.Open) { con.Open(); }

            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader dataReader = cmd.ExecuteReader();


            try
             {
                if (dataReader.Read())
                {
                    matiere = new Matiere();

                    matiere.Id = dataReader.GetInt32(0);
                    matiere.NomM = dataReader.GetString(1);
                    matiere.Nbrheures = dataReader.GetInt32(2);
                    try { matiere.Num_Ens = dataReader.GetInt32(3); }
                    catch (Exception ex) { }
                    try { matiere.Id_filiere = dataReader.GetInt32(4); }
                    catch (Exception ex) { }
                    if (dataReader[5] != System.DBNull.Value)
                    {
                        Byte[] bytes = (Byte[])dataReader[5];
                        if (bytes != null && bytes.Length > 0)
                            matiere.Image = Image.FromStream(new MemoryStream(bytes));
                        else
                            matiere.Image = null;
                    }
                    else
                        matiere.Image = null;
                }
                return matiere;
            }
            finally
            {
               con.Close();
            }
        }

        public List<Matiere> get_List_MatieresByProf_Filiere(ProfC ens, FiliereC f)
        {
            List<Matiere> listeMatieres = null;

            // string sql = "SELECT distinct m.* FROM filiere_matiere fm, filiere f, enseignant e, matiere m WHERE m.num_ens=e.num_ens and m.numM=fm.numM and e.num_ens=" + ens.Id + " and fm.numF=" + f.numF + " ;";
            //      String sql = "SELECT distinct m.* FROM  matiere m ,filiere f, prof e WHERE m.id_prof=e.id and e.id_filiere=f.id AND e.id='"+ens.Id+"' and f.id='"+f.Id +"'";

            String sql = "SELECT distinct m.* FROM  matiere m, filiere f, prof e WHERE m.id_prof = e.id and m.id_filiere = f.id AND e.id = '" + ens.Id + "' and f.id = '" + f.Id + "'";

            if (con.State != ConnectionState.Open) { con.Open(); }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            try
            {
                if (dataReader != null)
                    listeMatieres = new List<Matiere>();
                while (dataReader.Read())
                {
                    Matiere m = new Matiere();

                    m.Id = dataReader.GetInt32(0);
                    m.NomM = dataReader.GetString(1);
                    m.Nbrheures = dataReader.GetInt32(2);
                    try { m.Num_Ens = dataReader.GetInt32(3); }
                    catch (Exception ex) { }
                    try { m.Id_filiere = dataReader.GetInt32(4); }
                    catch (Exception ex) { }
                    if (dataReader[5] != System.DBNull.Value)
                    {
                        Byte[] bytes = (Byte[])dataReader[5];
                        if (bytes != null && bytes.Length > 0)
                            m.Image = Image.FromStream(new MemoryStream(bytes));
                        else
                            m.Image = null;
                    }
                    else
                        m.Image = null;

                    listeMatieres.Add(m);
                }
                return listeMatieres;
            }
            finally
            {
                con.Close();
            }
        }


    }
}
