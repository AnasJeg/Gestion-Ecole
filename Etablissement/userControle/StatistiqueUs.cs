using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etablissement.userControle
{
    public partial class StatistiqueUs : UserControl
    {
        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");

        public StatistiqueUs()
        {
            InitializeComponent();
        }

        private void Statistique_Load(object sender, EventArgs e)
        {
            ShowNbrEtud();
            ShowNbrProf();
            ShowNbrFiliere();
            ShowNbrModule();
            fillchart();
            Profchart();
        }
        private void fillchart()
        { String fl = "Filiere";
            String cnt = "nbr";
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("SELECT filiere.nom as'"+ fl +"', COUNT(filiere.nom) as '"+cnt+"'from etudiants , filiere where etudiants.id_filiere = filiere.id GROUP BY etudiants.id_filiere;", con);

            MySqlDataReader myreader;
            try
            {
               
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    this.chartA.Series["FiliereN"].Points.AddXY(myreader.GetString("Filiere"), myreader.GetInt32("nbr"));

                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Profchart()
        {
            String fl = "Filiere";
            String cnt = "nbr";
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("SELECT filiere.nom as'" + fl + "', COUNT(filiere.nom) as '" + cnt + "'from prof , filiere where prof.id_filiere = filiere.id GROUP BY prof.id_filiere;", con);

            MySqlDataReader myreader;
            try
            {

                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    this.chart1.Series["FiliereP"].Points.AddXY(myreader.GetString("Filiere"), myreader.GetInt32("nbr"));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ShowNbrEtud()
        {
            nbrEtud.Text = "";
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand Command = new MySqlCommand("select count(*) from etudiants", con);
            // MySqlDataReader reader = Command.ExecuteReader();
            Int32 rows_c = Convert.ToInt32(Command.ExecuteScalar());
            // categoriecombo.Items.Add(reader.GetString("libelle"));


            con.Close();
            nbrEtud.Text = "" + rows_c.ToString();
        }

        public void ShowNbrProf()
        {
            nbrProf.Text = "";
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand Command = new MySqlCommand("select count(*) from prof", con);
            // MySqlDataReader reader = Command.ExecuteReader();
            Int32 rows_c = Convert.ToInt32(Command.ExecuteScalar());
            // categoriecombo.Items.Add(reader.GetString("libelle"));


            con.Close();
            nbrProf.Text = "" + rows_c.ToString();
        }

        public void ShowNbrFiliere()
        {
            nbrFiliere.Text = "";
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand Command = new MySqlCommand("select count(*) from etudiants", con);
            // MySqlDataReader reader = Command.ExecuteReader();
            Int32 rows_c = Convert.ToInt32(Command.ExecuteScalar());
            // categoriecombo.Items.Add(reader.GetString("libelle"));


            con.Close();
            nbrFiliere.Text = "" + rows_c.ToString();
        }

        public void ShowNbrModule()
        {
            nbrMatiere.Text = "";
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand Command = new MySqlCommand("select count(*) from matiere", con);
            // MySqlDataReader reader = Command.ExecuteReader();
            Int32 rows_c = Convert.ToInt32(Command.ExecuteScalar());
            // categoriecombo.Items.Add(reader.GetString("libelle"));


            con.Close();
            nbrMatiere.Text = "" + rows_c.ToString();
        }

    }
}
