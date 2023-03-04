namespace Etablissement.userControle
{
    partial class Us_Etudiant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Us_Etudiant));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_Etudiants = new System.Windows.Forms.ListView();
            this.imgList_etudiants = new System.Windows.Forms.ImageList(this.components);
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.label2);
            this.guna2ShadowPanel1.Controls.Add(this.label1);
            this.guna2ShadowPanel1.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(81, 50);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(715, 63);
            this.guna2ShadowPanel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(298, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
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
            this.label1.Location = new System.Drawing.Point(48, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Les etudiants : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView_Etudiants
            // 
            this.listView_Etudiants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.listView_Etudiants.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_Etudiants.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_Etudiants.HideSelection = false;
            this.listView_Etudiants.Location = new System.Drawing.Point(92, 174);
            this.listView_Etudiants.Name = "listView_Etudiants";
            this.listView_Etudiants.Size = new System.Drawing.Size(705, 397);
            this.listView_Etudiants.TabIndex = 6;
            this.listView_Etudiants.TileSize = new System.Drawing.Size(50, 50);
            this.listView_Etudiants.UseCompatibleStateImageBehavior = false;
            this.listView_Etudiants.DoubleClick += new System.EventHandler(this.listView_Etudiants_DoubleClick);
            // 
            // imgList_etudiants
            // 
            this.imgList_etudiants.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList_etudiants.ImageStream")));
            this.imgList_etudiants.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList_etudiants.Images.SetKeyName(0, "nobody_male");
            this.imgList_etudiants.Images.SetKeyName(1, "nobody_female");
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Image = global::Etablissement.Properties.Resources.icons8_back_arrow1;
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.Location = new System.Drawing.Point(923, 59);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Size = new System.Drawing.Size(64, 54);
            this.guna2ImageButton1.TabIndex = 15;
            this.guna2ImageButton1.UseTransparentBackground = true;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // Us_Etudiant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.listView_Etudiants);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "Us_Etudiant";
            this.Size = new System.Drawing.Size(1080, 730);
            this.Load += new System.EventHandler(this.Us_Etudiant_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_Etudiants;
        private System.Windows.Forms.ImageList imgList_etudiants;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private System.Windows.Forms.Label label2;
    }
}
