using Etablissement.classes;
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
    internal class NoteService
    {
        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");
       

    public bool editNoteByEtudiantMatiere(StudentC etudiant, Matiere matiere, double? newNote)
        {
            int count = 0;
            string note = newNote.ToString().Replace(',', '.');

            if (con.State != ConnectionState.Open) { con.Open(); }

            try
            {
                string sql = "SELECT note FROM note WHERE numM =" + matiere.Id + " AND num_Etud=" + etudiant.Id + " ;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    dataReader.Close();
                    if (newNote == null)
                        sql = "DELETE FROM note WHERE num_Etud=" + etudiant.Id + " AND numM=" + matiere.Id + ";";
                    else
                        sql = "UPDATE note SET note= " + note + " WHERE num_Etud=" + etudiant.Id + " AND numM=" + matiere.Id + ";";

                    MySqlCommand commande = new MySqlCommand(sql, con);
                    count = commande.ExecuteNonQuery();
                 
                }
                else
                {
                    dataReader.Close();
                    sql = "INSERT INTO note(numM,note,num_Etud) VALUES numM=" + matiere.Id + ",note=" + note + ", num_Etud=" + etudiant.Id + ";";

                    MySqlCommand commande = new MySqlCommand(sql, con);
                    count = commande.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Commande n'est pas passé Add .\n"
                                   , "Commande"
                                   , MessageBoxButtons.OK
                                   , MessageBoxIcon.Error);
            }
            finally
            {
               con.Close();
            }

            if (count > 0)
                return true;
            else
                return false;
        }
    }
}
