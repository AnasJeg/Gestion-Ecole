using Etablissement.classes;
using Etablissement.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etablissement
{
    public partial class Login : Form
    {
        ProfService pfserv=new ProfService();
        UserService us=new UserService();
        public Login()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
                if (checkBox_ens.Checked)
                {
                    ProfC ee = us.isExiste(new User(Tu.Text, Tp.Text));
                    if (ee != null)
                    {


                       new Dashboard(ee).Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Enseignant(e) non trouvé(e).\n\nNom d'utilisateur/Mot de passe est incorrect."
                                       , "Authentification"
                                       , MessageBoxButtons.OK
                                       , MessageBoxIcon.Stop);
                }
                else if (checkBox_admin.Checked)
                {
                    string login = Tu.Text;
                    string passe = Tp.Text;

                    if (login == "admin" && passe == "admin")
                    {


                        Dashboard dh = new Dashboard();
                        dh.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Admin non trouvé.\n\nNom d'utilisateur/Mot de passe est incorrect."
                                       , "Authentification"
                                       , MessageBoxButtons.OK
                                       , MessageBoxIcon.Stop);
                }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_ens_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox_admin_Click(object sender, EventArgs e)
        {
            checkBox_ens.Checked = false;
            checkBox_admin.Checked = true;
        }

        private void checkBox_ens_Click(object sender, EventArgs e)
        {
            checkBox_admin.Checked = false;
            checkBox_ens.Checked = true;
        }

        private void checkBox_admin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Tp.PasswordChar = guna2CheckBox1.Checked ? (char)0 : '*';
            
        }
    }
}
