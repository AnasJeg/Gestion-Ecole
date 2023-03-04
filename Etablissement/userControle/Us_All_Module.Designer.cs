namespace Etablissement.userControle
{
    partial class Us_All_Module
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Us_All_Module));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.l_nomFiliere = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_Matieres = new System.Windows.Forms.ListView();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.imageList_matieres = new System.Windows.Forms.ImageList(this.components);
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.l_nomFiliere);
            this.guna2ShadowPanel1.Controls.Add(this.label1);
            this.guna2ShadowPanel1.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(65, 43);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(715, 63);
            this.guna2ShadowPanel1.TabIndex = 4;
            // 
            // l_nomFiliere
            // 
            this.l_nomFiliere.AutoSize = true;
            this.l_nomFiliere.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_nomFiliere.Location = new System.Drawing.Point(390, 22);
            this.l_nomFiliere.Name = "l_nomFiliere";
            this.l_nomFiliere.Size = new System.Drawing.Size(93, 32);
            this.l_nomFiliere.TabIndex = 3;
            this.l_nomFiliere.Text = "label2";
            this.l_nomFiliere.Click += new System.EventHandler(this.l_nomFiliere_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Liste des modules de : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView_Matieres
            // 
            this.listView_Matieres.HideSelection = false;
            this.listView_Matieres.Location = new System.Drawing.Point(65, 180);
            this.listView_Matieres.Name = "listView_Matieres";
            this.listView_Matieres.Size = new System.Drawing.Size(620, 431);
            this.listView_Matieres.TabIndex = 17;
            this.listView_Matieres.UseCompatibleStateImageBehavior = false;
            this.listView_Matieres.DoubleClick += new System.EventHandler(this.listView_Matieres_DoubleClick);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Etablissement.Properties.Resources._74pZ;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(735, 180);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(328, 310);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 16;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Image = global::Etablissement.Properties.Resources.icons8_back_arrow;
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.Location = new System.Drawing.Point(909, 43);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Size = new System.Drawing.Size(64, 54);
            this.guna2ImageButton1.TabIndex = 15;
            this.guna2ImageButton1.UseTransparentBackground = true;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // imageList_matieres
            // 
            this.imageList_matieres.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_matieres.ImageStream")));
            this.imageList_matieres.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_matieres.Images.SetKeyName(0, "M_0");
            // 
            // Us_All_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView_Matieres);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "Us_All_Module";
            this.Size = new System.Drawing.Size(1080, 730);
            this.Load += new System.EventHandler(this.Us_All_Module_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.ListView listView_Matieres;
        private System.Windows.Forms.ImageList imageList_matieres;
        private System.Windows.Forms.Label l_nomFiliere;
    }
}
