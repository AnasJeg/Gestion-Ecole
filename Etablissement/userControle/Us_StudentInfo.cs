using Etablissement.classes;
using Etablissement.DAO;
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

namespace Etablissement.userControle
{
    public partial class Us_StudentInfo : UserControl
    {
        StudentC etudiant;
        EtudService etudServ = new EtudService();
        FilierService filserc = new FilierService();
        public Us_StudentInfo()
        {
            InitializeComponent();

        }

        public Us_StudentInfo(StudentC st)
        {
            InitializeComponent();
            etudiant= st;
        }

        private void Us_StudentInfo_Load(object sender, EventArgs e)
        {

            l_nomEtudiant.Text = etudiant.Prenom + " " + etudiant.Nom;
            l_cne.Text = etudiant.Cne + "";
            l_nom.Text = etudiant.Nom;
            l_prenom.Text = etudiant.Prenom;
            l_filiere.Text = etudServ.getFiliereByEtudiant(etudiant).Nom;
            l_dateNaissance.Text =etudiant.Date_N.ToString();
            l_ville.Text = etudiant.Ville;
            l_adresse.Text = etudiant.Address;
            l_tele.Text = etudiant.Telephone;
            l_cin.Text = etudiant.Cin;

            if (etudiant.Image != null)
                pb_etudiant.BackgroundImage = etudiant.Image;
            else
                switch (etudiant.Sexe)
                {
                    case "homme": pb_etudiant.BackgroundImage = Properties.Resources.nobody_male; break;
                    case "femme": pb_etudiant.BackgroundImage = Properties.Resources.nobody_female; break;
                }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Back ! ", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                this.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(new Us_Etudiant());
                this.BringToFront();
            }
        }
    }
}
