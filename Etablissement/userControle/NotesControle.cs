using Etablissement.classes;
using Etablissement.DAO;
using Etablissement.services;
using Guna.UI2.WinForms;
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
    public partial class NotesControle : UserControl
    {
        FilierService filserv=new FilierService();
        Dashboard d=new Dashboard();
        ProfC _Enseignant;
        public NotesControle()
        {
            InitializeComponent();
            _Enseignant = Dashboard._Enseignant;
        }
      
        private void NotesControle_Load(object sender, EventArgs e)
        {
            label2.Text = "M (Mme) " + _Enseignant.Nom + " " + _Enseignant.Prenom;
            listView.LargeImageList = imgList_Filieres;
            List<FiliereC> liste = filserv.getListFilieresByProft(_Enseignant);

            foreach (FiliereC f in liste)
            {
                ListViewItem item = new ListViewItem();
                item.Text = f.Nom;
                item.ToolTipText = "Numéro: " + f.Id +
                                    "\nNom: " + f.Nom +
                                    "\nMatières: " + f.Nombre_module +
                                    "\nClasse: " + f.Id_groupe;
                switch (f.Id)
                {
                    case 1: item.ImageKey = "img_GINF"; break;
                    case 2: item.ImageKey = "img_GPEE"; break;
                    case 3: item.ImageKey = "img_GE"; break;
                    case 4: item.ImageKey = "img_GIND"; break;
                    case 5: item.ImageKey = "img_GM"; break;
                    case 6: item.ImageKey = "img_GC"; break;
                }
                listView.Items.Add(item);
            }
        }



        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem i = listView.SelectedItems[0];
          
            DialogResult dialogClose = MessageBox.Show("nome du filiere : "+i.Text, "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(dialogClose == DialogResult.OK)
            {
                this.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(new Us_Filiere(filserv.get_Filiere_By_Name(i.Text)));
                this.BringToFront();
            }
            

                
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
