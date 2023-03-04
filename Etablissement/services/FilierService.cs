using Etablissement.classes;
using Etablissement.DAO;
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

namespace Etablissement.services
{
    internal class FilierService : Dao<FiliereC>
    {
        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");
        UserService userServ = new UserService();   
      

        public void ajouter(FiliereC c)
        {
            try
            {

                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("INSERT INTO filiere(nom,id_resp,nombre_module,id_groupe) values (@1,@3,@4,@5)", con);
                req.Parameters.AddWithValue("@1", c.Nom);
                req.Parameters.AddWithValue("@3", c.Id_resp);
                req.Parameters.AddWithValue("@4",c.Nombre_module);
                req.Parameters.AddWithValue("@5", c.Id_groupe);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("add Filiere sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void modifier(FiliereC c)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("UPDATE filiere SET  nom=@1,id_resp=@3,nombre_module=@4, id_groupe=@5 where id=@id", con);
                req.Parameters.AddWithValue("@1", c.Nom);
                req.Parameters.AddWithValue("@3", c.Id_resp);
                req.Parameters.AddWithValue("@4", c.Nombre_module);
                req.Parameters.AddWithValue("@5", c.Id_groupe);
                req.Parameters.AddWithValue("@id", c.Id);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("Update Filiere sql !!");
                Console.WriteLine(ex.Message);

            }
        }

       
        public void supprimer(int id)
        {
            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand req = new MySqlCommand("DELETE FROM  filiere WHERE id = '" + id + "'", con);
                req.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("Delete Filiere sql !!");
                Console.WriteLine(ex.Message);

            }
        }

        public void afficher(FiliereC c)
        {
            throw new NotImplementedException();
        }

        public void searchById(int id)
        {
            throw new NotImplementedException();
        }


        public int getFilierbyNom(String nf)
        {
            int c = 0;

            try
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                
                MySqlCommand cmd = new MySqlCommand("select id from filiere where nom='" + nf + "'",con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c = (int)reader[0];

                }
                con.Close();
                
            }
            catch (Exception ex)
            {
                DialogResult dd = MessageBox.Show("getFilierbyNom sql !!");
                Console.WriteLine(ex.Message);

            }
            return c;

        }

        public List<FiliereC> getListFilieresByProft(ProfC pf)
        {
            List<FiliereC> listeFilieres = null;
            if (con.State != ConnectionState.Open) { con.Open(); }
            /*  MySqlCommand cmd = new MySqlCommand("SELECT distinct filiere.* FROM filiere,filiere_matiere,matiere,enseignant,login " +
                            "WHERE filiere.numF=filiere_matiere.numF " +
                            "AND filiere_matiere.numM=matiere.numM " +
                            "AND matiere.num_Ens=enseignant.num_Ens " +
                            "AND enseignant.login=login.login ",con);
            */
            //   SELECT distinct filiere.* FROM filiere,prof,module WHERE filiere.id=module.id_filiere AND module.id_prof=prof.id AND  prof.nom="jeg" AND prof.login='prof';
            // "SELECT distinct filiere.* FROM filiere,prof,module WHERE filiere.id=module.id_filiere AND module.id_prof=prof.id AND  prof.nom='"+pf.Nom+ "'"
            string sql = "SELECT distinct filiere.* FROM filiere,prof,matiere,user  WHERE filiere.id=matiere.id_filiere AND matiere.id_prof=prof.id AND prof.login = user.username AND user.username='"+pf.Login+"' AND user.password='"+userServ.getPasswordByLogin(pf.Login)+"'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            // SELECT distinct filiere.* FROM filiere,prof,matiere,user  WHERE filiere.id=matiere.id_filiere AND matiere.id_prof=prof.id AND prof.login = user.username AND user.username="prof1" AND user.password="prof1"

            MySqlDataReader dataReader = cmd.ExecuteReader();
            try
            {
                if (dataReader != null)
                    listeFilieres = new List<FiliereC>();
                while (dataReader.Read())
                {
                    FiliereC f = new FiliereC();

                    f.Id = dataReader.GetInt32(0);
                    f.Nom = dataReader.GetString(1);
                    f.Id_resp = dataReader.GetInt32(2);
                    f.Nombre_module = dataReader.GetInt32(3);
                    f.Id_groupe = dataReader.GetInt32(4);
                    listeFilieres.Add(f);
                }
                return listeFilieres;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Matiere> getListFByProft()
        {
           if (con.State != ConnectionState.Open) { con.Open(); }
           
            List<Matiere> listeMatieres = null;
            MySqlCommand cmd = new MySqlCommand("SELECT distinct matiere.* FROM matiere", con);
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
                    if (dataReader[4] != System.DBNull.Value)
                    {
                        Byte[] bytes = (Byte[])dataReader[4];
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

        public FiliereC get_Filiere_By_Name(string nomFiliere)
        {
            FiliereC filiere = null;
            string sql = "SELECT * FROM filiere WHERE nom='" + nomFiliere.Replace("'", "''") + "';";
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
