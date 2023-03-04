using Etablissement.classes;
using Etablissement.DAO;
using Etablissement.services;
using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etablissement.userControle
{
    public partial class Us_Etudiant : UserControl
    {
        EtudService et = new EtudService();
        public static FiliereC filiere;
        private static ProfC _Enseignant;
        public Us_Etudiant()
        {
            InitializeComponent();
            _Enseignant = Dashboard._Enseignant;
        }
        public Us_Etudiant(FiliereC f)
        {
            InitializeComponent();
            filiere= f;
            _Enseignant = Dashboard._Enseignant;
        }


        private void Us_Etudiant_Load(object sender, EventArgs e)
        {
          label2.Text = filiere.Nom;

            listView_Etudiants.LargeImageList = imgList_etudiants;
            List<StudentC> liste = et.getListEtudiantsBy_Class(filiere.Id) ;

            foreach (StudentC ee in liste)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ee.Nom + " " + ee.Prenom;
                item.ToolTipText = "Numéro: " + ee.Id;
              //  System.Drawing.Image im = ee.Image;
                if (ee.Image != null)
                {
                    imgList_etudiants.Images.Add("f_" + ee.Nom, ee.Image);
                    
                    item.ImageKey = "f_" + ee.Nom;
                }
                else
                    switch (ee.Sexe)
                    {
                        case "homme":
                            imgList_etudiants.Images.Add("f_" + ee.Nom, Properties.Resources.nobody_male);
                            item.ImageKey = "f_" + ee.Nom;
                            break;
                        case "femme":
                            imgList_etudiants.Images.Add("f_" + ee.Nom, Properties.Resources.nobody_female);
                            item.ImageKey = "f_" + ee.Nom;
                            break;
                    }

                listView_Etudiants.Items.Add(item);
            }
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

        private void listView_Etudiants_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem i = listView_Etudiants.SelectedItems[0];
            string ss = i.ToolTipText.Substring(8, i.ToolTipText.Length - 8);
            int num = Int32.Parse(ss);
            DialogResult dialogClose = MessageBox.Show("Next ! ", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                this.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(new Us_StudentInfo(et.getEtudiant_ById(num)));
                this.BringToFront();
            }
           
        }
    }
}
