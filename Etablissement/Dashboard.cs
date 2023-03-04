using Etablissement.classes;
using Etablissement.userControle;
using iTextSharp.text.pdf.parser;
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
    public partial class Dashboard : Form
    {
        public static ProfC _Enseignant;


        public Dashboard()
        {
            InitializeComponent();
        }
            
        public Dashboard(ProfC ee)
        {
            InitializeComponent();
            _Enseignant = ee;
            profB.Enabled= false;
            etudiantB.Enabled= false;
            gestionB.Enabled= false;
        }

      


        public bool AdduserControle(UserControl usc)
        {
                usc.Dock= DockStyle.Fill;
            deskpane.Controls.Clear();
            deskpane.Controls.Add(usc);
            deskpane.BringToFront();
            return true;

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(x, y);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
              AdduserControle(st);
              /*
            if (deskpane.Controls.Count > 1)
            {
                deskpane.Controls.RemoveAt(1);
            }
            deskpane.Controls.Add(new Student());
             deskpane.BringToFront();
            this.Refresh();
            */
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Professeur pf = new Professeur();
             AdduserControle(pf);
          /*
            if (deskpane.Controls.Count > 1)
            {
                deskpane.Controls.RemoveAt(1);
            }
            deskpane.Controls.Add(new Professeur());
             deskpane.BringToFront();
            this.Refresh();
            */
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            GestionFGN gs = new GestionFGN();
              AdduserControle(gs);
          /*  if (deskpane.Controls.Count > 1)
            {
                deskpane.Controls.RemoveAt(1);
            }
            deskpane.Controls.Add(new GestionFGN());
             deskpane.BringToFront();
            this.Refresh();
        */
            }

        private void note_Click(object sender, EventArgs e)
        {
            NotesControle nt=new NotesControle();
            AdduserControle(nt);
          /*  if (deskpane.Controls.Count > 1) { 
                deskpane.Controls.RemoveAt(1);
            }
            deskpane.Controls.Add(new NotesControle());
             deskpane.BringToFront();
            this.Refresh();
          */
        }

        private void statistique_Click(object sender, EventArgs e)
        {
            StatistiqueUs stq= new StatistiqueUs();
            AdduserControle(stq);
        }

        private void guna2PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
