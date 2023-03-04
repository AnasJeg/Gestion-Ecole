using Etablissement.classes;
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
    public partial class Us_Groupe : UserControl
    {

        private static FiliereC filiere;

       
         public Us_Groupe()
        {
            InitializeComponent();
        }
            public Us_Groupe(FiliereC f)
            {
                InitializeComponent();
                filiere = f;
            }


            private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            guna2HtmlLabel1.ForeColor = Color.FromArgb(137, 207, 240);
            guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 28.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            guna2HtmlLabel1.Location = new Point(guna2HtmlLabel1.Location.X - 7, guna2HtmlLabel1.Location.Y);

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            guna2HtmlLabel1.ForeColor = Color.Black;
            guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 22.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            guna2HtmlLabel1.Location = new Point(guna2HtmlLabel1.Location.X + 7, guna2HtmlLabel1.Location.Y);

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            guna2HtmlLabel2.ForeColor = Color.FromArgb(137, 207, 240);
            guna2HtmlLabel2.Font = new System.Drawing.Font("Century Gothic", 33.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            guna2HtmlLabel2.Location = new Point(guna2HtmlLabel2.Location.X - 7, guna2HtmlLabel2.Location.Y);

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            guna2HtmlLabel2.ForeColor = Color.Black;
            guna2HtmlLabel2.Font = new System.Drawing.Font("Century Gothic", 26.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            guna2HtmlLabel2.Location = new Point(guna2HtmlLabel2.Location.X + 7, guna2HtmlLabel2.Location.Y);

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

            DialogResult dialogClose = MessageBox.Show("Etudiant ! ", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                this.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(new Us_Etudiant(filiere));
                this.BringToFront();
            }
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {

            DialogResult dialogClose = MessageBox.Show("Notes des Etudiants ! ", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                this.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(new Us_Notes(filiere));
                this.BringToFront();
            }
        }

        private void Us_Groupe_Load(object sender, EventArgs e)
        {
            if (filiere.Nom.Length < 25)
                label2.Text = filiere.Nom;
            else
                label2.Text = filiere.Nom.Substring(0, 24) + "...";
        }
    }
}
