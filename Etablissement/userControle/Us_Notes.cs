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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etablissement.userControle
{
    public partial class Us_Notes : UserControl
    {
        FilierService filser=new FilierService();
        private static ProfC _Enseignant;
        private static FiliereC filiere;
        MatiereService matServ= new MatiereService();
        EtudService et= new EtudService();
        public Us_Notes()
        {
            InitializeComponent();
            _Enseignant = Dashboard._Enseignant;
        }

        public Us_Notes(FiliereC f)
        {
            InitializeComponent();
            _Enseignant = Dashboard._Enseignant;
            filiere = f;
        }

        private void uc_voirNotes_Load(object sender, EventArgs e)
        {
            
           label2.Text = et.getGroupe_ByNum(filiere.Id_groupe).NomG;
            MessageDialog.Show("" + et.getGroupe_ByNum(filiere.Id_groupe).NomG);
            List<Matiere> listeMatieres = matServ.get_List_MatieresByProf_Filiere(_Enseignant,filiere);
            List<StudentC> listeEtudiants = et.getListEtudiantsBy_Class(filiere.Id_groupe);

            int nbMatieres = listeMatieres.Count;

            //Ajout des des colonnes pour les (matières) :
            foreach (Matiere m in listeMatieres)
            {
                if (m.NomM.Length < 7)
                    listView_Notes.Columns.Add(m.NomM, m.NomM.Length * 20);
                else
                    listView_Notes.Columns.Add(m.NomM, m.NomM.Length * 13);
            }


            foreach (StudentC ee in listeEtudiants)
            {
                //Construction de la ligne [dans la table des notes]
                ListViewItem item = new ListViewItem(ee.Cne + "");
                item.SubItems.Add(ee.Nom);
                item.SubItems.Add(ee.Prenom);

                foreach (Matiere m in listeMatieres)
                {
                    double note = et.getNoteByEtudiantMatiere(ee, m);
                    if (note >= 0 && note <= 20)
                        item.SubItems.Add(note + "");
                    else
                        item.SubItems.Add("-");
                }

                //Ajout de la ligne
                listView_Notes.Items.Add(item);
            }
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Back ! ", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                this.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(new Us_Groupe());
                this.BringToFront();
            }
        }
    }
}
