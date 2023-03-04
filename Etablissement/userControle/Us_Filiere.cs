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
    public partial class Us_Filiere : UserControl
    {
        private static FiliereC filiere;
        public int idFiliere;

        public Us_Filiere()
        {
            InitializeComponent();
        }
        public Us_Filiere(FiliereC f)
        {
            InitializeComponent();
            filiere= f;
        }

        private void Us_Matiere_Load(object sender, EventArgs e)
        {
            label2.Text = filiere.Nom;
        }

      

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            guna2HtmlLabel1.ForeColor = Color.FromArgb(255, 235, 183);
            guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 22.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            guna2HtmlLabel1.Location = new Point(guna2HtmlLabel1.Location.X - 7, guna2HtmlLabel1.Location.Y);
       //     pp_hover1.BackColor = Color.FromArgb(255, 235, 183);

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            guna2HtmlLabel1.ForeColor = Color.White;
            guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 16.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            guna2HtmlLabel1.Location = new Point(guna2HtmlLabel1.Location.X + 7, guna2HtmlLabel1.Location.Y);
         //   pp_hover1.BackColor = Color.White;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            guna2HtmlLabel2.ForeColor = Color.FromArgb(255, 235, 183);
            guna2HtmlLabel2.Font = new System.Drawing.Font("Century Gothic", 22.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            guna2HtmlLabel2.Location = new Point(guna2HtmlLabel2.Location.X - 7, guna2HtmlLabel2.Location.Y);
        //    pp_hover2.BackColor = Color.FromArgb(255, 235, 183);

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            guna2HtmlLabel2.ForeColor = Color.White;
            guna2HtmlLabel2.Font = new System.Drawing.Font("Century Gothic", 16.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            guna2HtmlLabel2.Location = new Point(guna2HtmlLabel2.Location.X + 7, guna2HtmlLabel2.Location.Y);
         //   pp_hover2.BackColor = Color.White;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("groupe ! ", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                this.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(new Us_Groupe(filiere));
                this.BringToFront();
            }

        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Module ! ", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                this.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(new Us_All_Module(filiere));
                this.BringToFront();
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Back ! ", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                this.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(new NotesControle());
                this.BringToFront();
            }


        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
