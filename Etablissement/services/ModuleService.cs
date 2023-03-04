using Etablissement.classes;
using Etablissement.DAO;
using Etablissement.userControle;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Etablissement.services
{
    internal class ModuleService : Dao<ModuleC>
    {

        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");

       
        public void ajouter(ModuleC c)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("INSERT INTO module(nomM,id_filiere,id_prof) values (@1,@2,@3)", con);
                req.Parameters.AddWithValue("@1", c.Nom);
                req.Parameters.AddWithValue("@2", c.Id_filiere);
                req.Parameters.AddWithValue("@3", c.Id_prof);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("add Module sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void modifier(ModuleC c)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("UPDATE module SET  nomM=@1, id_filiere=@2,id_prof=@3 where id=@id", con);
                req.Parameters.AddWithValue("@1", c.Nom);
                req.Parameters.AddWithValue("@2", c.Id_filiere);
                req.Parameters.AddWithValue("@3", c.Id_prof);
                req.Parameters.AddWithValue("@id", c.Id);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("Update Module sql !!");
                Console.WriteLine(ex.Message);

            }
        }

       

        public void supprimer(int id)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("DELETE FROM  module WHERE id = '" + id + "'", con);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("Delete Module sql !!");
                Console.WriteLine(ex.Message);

            }
        }
        public void afficher(ModuleC c)
        {
            throw new NotImplementedException();
        }
        public void searchById(int id)
        {
            throw new NotImplementedException();
        }


        public int getId_ModulebyNom(String nM)
        {
            int c = 0;

            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

                MySqlCommand cmd = new MySqlCommand("select id from module where nomM='" + nM + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c = (int)reader[0];

                }
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("getId_ModulebyNom sql !!");
                Console.WriteLine(ex.Message);

            }
            return c;

        }

        public List<Matiere> getListMatieresByProf_Filiere(ProfC ens, FiliereC f)
        {
            List<Matiere> listeMatieres = null;

            // string sql = "SELECT distinct m.* FROM filiere_matiere fm, filiere f, enseignant e, matiere m WHERE m.num_ens=e.num_ens and m.numM=fm.numM and e.num_ens=" + ens.Id + " and fm.numF=" + f.numF + " ;";
            //      String sql = "SELECT distinct m.* FROM  matiere m ,filiere f, prof e WHERE m.id_prof=e.id and e.id_filiere=f.id AND e.id='"+ens.Id+"' and f.id='"+f.Id +"'";

            String sql = "SELECT distinct m.*FROM  matiere m, filiere f, prof e WHERE m.id_prof = e.id and m.id_filiere = f.id AND e.id = '" + ens.Id + "' and f.id = '" + f.Id + "'";

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
