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
    public partial class Us_All_Module : UserControl
    {
        private static FiliereC filiere;
        private static ProfC _Enseignant;
        MatiereService matserv = new MatiereService();
        public Us_All_Module()
        {
            InitializeComponent();
            _Enseignant = Dashboard._Enseignant;

        }
        public Us_All_Module(FiliereC f)
        {
            InitializeComponent();
            filiere = f;
            _Enseignant = Dashboard._Enseignant;
        }

        private void Us_All_Module_Load(object sender, EventArgs e)
        {
            l_nomFiliere.Text = filiere.Nom;
            listView_Matieres.LargeImageList = imageList_matieres;
            List<Matiere> listeMatieres = matserv.getListMatieresByEnseignantFiliere(_Enseignant, filiere);
            foreach (Matiere m in listeMatieres)
            {
                ListViewItem item = new ListViewItem();
                item.Text = m.NomM;
                if (m.Image != null)
                {
                    imageList_matieres.Images.Add("img_" + m.Id, m.Image);
                    item.ImageKey = "img_" + m.Id;
                }
                //item.ImageKey = "M_0";
                else
                {
                    imageList_matieres.Images.Add("img_" + m.Id, Properties.Resources.M_0);
                    item.ImageKey = "img_" + m.Id;
                }

                listView_Matieres.Items.Add(item);
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Back ! ", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                this.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(new Us_Filiere());
                this.BringToFront();
            }
        }

        private void l_nomFiliere_Click(object sender, EventArgs e)
        {

        }

        private void listView_Matieres_DoubleClick(object sender, EventArgs e)
        {
            Matiere mat = matserv.findMatiereBy_Name(listView_Matieres.SelectedItems[0].Text);

            DialogResult dialogClose = MessageBox.Show("Back ! ", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                this.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(new Us_Module(mat,filiere));
                this.BringToFront();
            }
        }
    }
}
