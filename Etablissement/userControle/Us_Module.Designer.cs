namespace Etablissement.userControle
{
    partial class Us_Module
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Notes = new Guna.UI2.WinForms.Guna2DataGridView();
            this.c_cne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_matiere = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox_modif = new Guna.UI2.WinForms.Guna2CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_export = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Notes)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.label1);
            this.guna2ShadowPanel1.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(91, 23);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(715, 63);
            this.guna2ShadowPanel1.TabIndex = 11;
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
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "collecter les Notes ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView_Notes
            // 
            this.dataGridView_Notes.AllowUserToAddRows = false;
            this.dataGridView_Notes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView_Notes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Notes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Notes.ColumnHeadersHeight = 15;
            this.dataGridView_Notes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView_Notes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_cne,
            this.c_nom,
            this.c_prenom,
            this.c_matiere});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Notes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Notes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_Notes.Location = new System.Drawing.Point(91, 112);
            this.dataGridView_Notes.Name = "dataGridView_Notes";
            this.dataGridView_Notes.RowHeadersVisible = false;
            this.dataGridView_Notes.Size = new System.Drawing.Size(646, 404);
            this.dataGridView_Notes.TabIndex = 15;
            this.dataGridView_Notes.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView_Notes.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridView_Notes.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridView_Notes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridView_Notes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridView_Notes.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView_Notes.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_Notes.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridView_Notes.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView_Notes.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_Notes.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView_Notes.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView_Notes.ThemeStyle.HeaderStyle.Height = 15;
            this.dataGridView_Notes.ThemeStyle.ReadOnly = false;
            this.dataGridView_Notes.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView_Notes.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView_Notes.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_Notes.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView_Notes.ThemeStyle.RowsStyle.Height = 22;
            this.dataGridView_Notes.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView_Notes.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView_Notes.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_Notes_CellBeginEdit);
            this.dataGridView_Notes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Notes_CellEndEdit);
            // 
            // c_cne
            // 
            this.c_cne.HeaderText = "CNE";
            this.c_cne.Name = "c_cne";
            // 
            // c_nom
            // 
            this.c_nom.HeaderText = "Nom";
            this.c_nom.Name = "c_nom";
            // 
            // c_prenom
            // 
            this.c_prenom.HeaderText = "Prenom";
            this.c_prenom.Name = "c_prenom";
            // 
            // c_matiere
            // 
            this.c_matiere.HeaderText = "xxx";
            this.c_matiere.Name = "c_matiere";
            // 
            // checkBox_modif
            // 
            this.checkBox_modif.AutoSize = true;
            this.checkBox_modif.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkBox_modif.CheckedState.BorderRadius = 0;
            this.checkBox_modif.CheckedState.BorderThickness = 0;
            this.checkBox_modif.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkBox_modif.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F);
            this.checkBox_modif.Location = new System.Drawing.Point(467, 560);
            this.checkBox_modif.Name = "checkBox_modif";
            this.checkBox_modif.Size = new System.Drawing.Size(270, 23);
            this.checkBox_modif.TabIndex = 16;
            this.checkBox_modif.Text = "Autoriser la modification des notes *";
            this.checkBox_modif.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.checkBox_modif.UncheckedState.BorderRadius = 0;
            this.checkBox_modif.UncheckedState.BorderThickness = 0;
            this.checkBox_modif.UncheckedState.FillColor = System.Drawing.Color.Silver;
            this.checkBox_modif.CheckedChanged += new System.EventHandler(this.guna2CheckBox1_CheckedChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.InitialDirectory = "C:/Users/Public/Desktop/";
            this.saveFileDialog1.Title = "Exportation des notes";
            // 
            // btn_export
            // 
            this.btn_export.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_export.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_export.Image = global::Etablissement.Properties.Resources.pdf_file;
            this.btn_export.ImageOffset = new System.Drawing.Point(0, 0);
            this.btn_export.ImageRotate = 0F;
            this.btn_export.Location = new System.Drawing.Point(714, 641);
            this.btn_export.Name = "btn_export";
            this.btn_export.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_export.Size = new System.Drawing.Size(64, 54);
            this.btn_export.TabIndex = 17;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Image = global::Etablissement.Properties.Resources.icons8_back_arrow;
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.Location = new System.Drawing.Point(931, 23);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Size = new System.Drawing.Size(64, 54);
            this.guna2ImageButton1.TabIndex = 14;
            this.guna2ImageButton1.UseTransparentBackground = true;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // Us_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.checkBox_modif);
            this.Controls.Add(this.dataGridView_Notes);
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "Us_Module";
            this.Size = new System.Drawing.Size(1080, 730);
            this.Load += new System.EventHandler(this.Us_Module_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Notes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView_Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cne;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_matiere;
        private Guna.UI2.WinForms.Guna2CheckBox checkBox_modif;
        private Guna.UI2.WinForms.Guna2ImageButton btn_export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
