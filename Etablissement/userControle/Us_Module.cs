using Etablissement.classes;
using Etablissement.DAO;
using Etablissement.services;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etablissement.userControle
{
    public partial class Us_Module : UserControl
    {
        ModuleC module = new ModuleC();
        private static string oldValue = "--";
        private List<StudentC> listeEtudiants = new List<StudentC>();
        EtudService etudS = new EtudService();
        NoteService noteS = new NoteService();
        private static Matiere matiere;
        private static ProfC _Enseignant;
        public static FiliereC filiere;

        public Us_Module()
        {
            InitializeComponent();
            _Enseignant = Dashboard._Enseignant;

        }
        public Us_Module(Matiere m,FiliereC f)
        {
            InitializeComponent();
            _Enseignant = Dashboard._Enseignant;
            matiere = m;
            filiere = f;

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

        private void Us_Module_Load(object sender, EventArgs e)
        {
            //l_nomClasse.Text = "\""+matiere.nomM+"\"";
            //fill_ListView_Notes();

            dataGridView_Notes.Columns[3].HeaderText = module.Nom;
            dataGridView_Notes.Columns[0].ReadOnly = true;
            dataGridView_Notes.Columns[1].ReadOnly = true;
            dataGridView_Notes.Columns[2].ReadOnly = true;
            dataGridView_Notes.Columns[3].ReadOnly = true;
            listeEtudiants = etudS.getListEtudiantsBy_Class(filiere.Id);  // here id_filiere
            foreach (StudentC ee in listeEtudiants)
            {
                double note = etudS.getNoteByEtudiantMatiere(ee,matiere);
                if (note >= 0 && note <= 20)
                    dataGridView_Notes.Rows.Add(ee.Cne, ee.Nom, ee.Prenom, note.ToString().Replace(',', '.'));
                else
                    dataGridView_Notes.Rows.Add(ee.Cne, ee.Nom, ee.Prenom, "-");
            }

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_modif.Checked)
                dataGridView_Notes.Columns[3].ReadOnly = false;
            else
                dataGridView_Notes.Columns[3].ReadOnly = true;
        }

        private void dataGridView_Notes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                try
                {
                    oldValue = dataGridView_Notes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                catch (NullReferenceException ex) { }

            }
        }

        private void dataGridView_Notes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0 && checkBox_modif.Checked == true)
            {
                try
                {
                    if (dataGridView_Notes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        if (oldValue == "-")
                        {
                            dataGridView_Notes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldValue;
                            return;
                        }
                        DialogResult res = MessageBox.Show("Etes-vous sûr de laisser la note vide ?", "Question",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            String CNE = dataGridView_Notes.Rows[e.RowIndex].Cells[0].Value.ToString();
                            StudentC etudiant = listeEtudiants.FirstOrDefault(eee => eee.Cne == CNE);
                            
                            if (etudiant != null)
                            {
                            // etudiant.Id = 8;
                             //       mt.numM = 2;
                                if (!noteS.editNoteByEtudiantMatiere(etudiant, matiere, null))
                                {
                                    MessageBox.Show("La note ne peut être changée.", "ERREUR",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dataGridView_Notes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldValue;
                                }
                                else
                                    dataGridView_Notes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-";
                            }
                            else
                            {
                                MessageBox.Show("Cet étudiant n'existe pas.");
                                dataGridView_Notes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldValue;
                            }
                        }
                        else
                            dataGridView_Notes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldValue;
                    }
                    else
                    {
                        string strNote = dataGridView_Notes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();//.Replace(',','.');
                        double newNote = -1;
                        if (!double.TryParse(strNote, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out newNote) &&
                        !double.TryParse(strNote, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out newNote) &&
                        !double.TryParse(strNote, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out newNote))
                        {
                            newNote = -1;
                            throw new Exception();
                        }

                        if (newNote < 0 || newNote > 20)
                            throw new Exception();
                        else if (newNote.ToString() != oldValue)
                        {
                            String CNE = dataGridView_Notes.Rows[e.RowIndex].Cells[0].Value.ToString();
                            StudentC etudiant = listeEtudiants.FirstOrDefault(eee => eee.Cne == CNE);
                            if (etudiant != null)
                            {
                                if (!noteS.editNoteByEtudiantMatiere(etudiant, matiere, newNote))
                                {
                                    MessageBox.Show("La note ne peut être changée !.", "ERREUR",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dataGridView_Notes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldValue;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cet étudiant n'existe pas.");
                                dataGridView_Notes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldValue;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    dataGridView_Notes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldValue;
                    MessageBox.Show("Essayez de saisir une note valable !\n\n\nExemple : 12.75 ou 18,50 \n\n Note >= 0 ou Note <= 20.", "ATTENTION !!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                dataGridView_Notes.EndEdit();
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            createPdf();
        }


        public void createPdf()
        {
            try
            {
                /* Création du document */
                Document document = new Document(PageSize.A4);
                document.SetMargins(50, 50, 0, 40);

                /* Choisir l'emplacement */
                   saveFileDialog1.FileName = "Notes " + matiere.NomM + " Filière " + filiere.Nom;
               // saveFileDialog1.FileName = "Notes " + "sdf" + " Filière " +"iir4";
                saveFileDialog1.Filter = "Text file(*.pdf)|*.pdf";
                saveFileDialog1.FilterIndex = 1;
                DialogResult resDialog = saveFileDialog1.ShowDialog();
                if (resDialog == DialogResult.Cancel) { return; }
                string path = saveFileDialog1.FileName;

                /* Création du fichier */
                var output = new FileStream(path, FileMode.Create);
                var writer = PdfWriter.GetInstance(document, output);
              
                /* METADATA */
                document.AddTitle("Notes " + matiere.NomM  + " Filière " + filiere.Nom);
                document.AddAuthor("Gestion des notes [Anas Jegoual]");
                document.AddSubject("Notes " + matiere.NomM  + " Filière " + filiere.Nom);
                document.AddKeywords("notes, pdf, " + matiere.NomM );
                document.AddCreator("Gestion des notes [Anas Jegoual]");
                document.Open();

                /* Image logo ENSA & UIZ */
                iTextSharp.text.Image imgLOGOs = iTextSharp.text.Image.GetInstance((System.Drawing.Image)Properties.Resources.logo, System.Drawing.Imaging.ImageFormat.Jpeg);
                imgLOGOs.Alignment = iTextSharp.text.Image.ALIGN_TOP;
                imgLOGOs.ScaleAbsolute(PageSize.A4.Width - document.LeftMargin * 2, 78);
                document.Add(imgLOGOs);
                document.SetMargins(50, 50, 40, 40);
                /* les informations des notes */
                iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                Paragraph para = new Paragraph(16, "\n\n\n\n\n\n" +
                                                   "Notes de la matière    :  " + matiere.NomM  + "\n" +
                                                //   "Professeur                  :  " + _Enseignant.Nom + " " + _Enseignant.Prenom + "\n" +
                                                      "Professeur                  :  " + _Enseignant.Prenom + " " + _Enseignant.Nom + "\n" +
                                                   "Année universitaire   :  " + "2022/2023\n" +
                                                   "Filière                        :  " + filiere.Nom + "\n", font);
                para.Alignment = Element.ALIGN_LEFT;
                document.Add(para);


                /* Le tableau des notes */

                //create a table of 2 columns
                PdfPTable table = new PdfPTable(5);
                //set spacing before and after the table
                table.SpacingAfter = 5;
                table.SpacingBefore = 30;
                //set width of the table
                table.TotalWidth = PageSize.A4.Width - document.LeftMargin * 2;
                table.LockedWidth = true;
                //les largeurs des 'cell'
                table.SetWidths(new int[] { 1, 4, 4, 4, 4 });
                //Alignement du text dans le header du tableau
                table.HorizontalAlignment = Element.ALIGN_CENTER;

                /* Le header du tableau */
                PdfPCell cellNo = new PdfPCell(new Phrase(" "));
                cellNo.HorizontalAlignment = Element.ALIGN_CENTER;
                cellNo.BackgroundColor = BaseColor.LIGHT_GRAY;
                cellNo.Padding = 5;
                PdfPCell cellCNE = new PdfPCell(new Phrase(new Chunk("CNE", FontFactory.GetFont("Century Gothic", 11))));
                cellCNE.HorizontalAlignment = Element.ALIGN_CENTER;
                cellCNE.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cellNom = new PdfPCell(new Phrase(new Chunk("NOM", FontFactory.GetFont("Century Gothic", 11))));
                cellNom.HorizontalAlignment = Element.ALIGN_CENTER;
                cellNom.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cellPrenom = new PdfPCell(new Phrase(new Chunk("PRENOM", FontFactory.GetFont("Century Gothic", 11))));
                cellPrenom.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPrenom.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cellNote = new PdfPCell(new Phrase(new Chunk(matiere.NomM  + "", FontFactory.GetFont("Century Gothic", 11))));
                cellNote.HorizontalAlignment = Element.ALIGN_CENTER;
                cellNote.BackgroundColor = BaseColor.LIGHT_GRAY;
                //add cells to the tables
                table.AddCell(cellNo);
                table.AddCell(cellCNE);
                table.AddCell(cellNom);
                table.AddCell(cellPrenom);
                table.AddCell(cellNote);

                /* Les enregistrements */
                listeEtudiants = etudS.getListEtudiantsBy_Class(filiere.Id_groupe);
                int No = 1;
                foreach (StudentC ee in listeEtudiants)
                {
                    double note = etudS.getNoteByEtudiantMatiere(ee, matiere);

                    cellNo = new PdfPCell(new Phrase(new Chunk(No + "", FontFactory.GetFont("Century Gothic", 9)))); No++;
                    cellNo.Padding = 3;
                    cellCNE = new PdfPCell(new Phrase(new Chunk(ee.Cne + "", FontFactory.GetFont("Century Gothic", 9))));
                    cellCNE.Padding = 3;
                    //cellNom = new PdfPCell(new Phrase(new Chunk("CHAOUI", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, 0))));
                    cellNom = new PdfPCell(new Phrase(new Chunk(ee.Nom + "", FontFactory.GetFont("Century Gothic", 9))));
                    cellNom.Padding = 3;
                    cellPrenom = new PdfPCell(new Phrase(new Chunk(ee.Prenom + "", FontFactory.GetFont("Century Gothic", 9))));
                    cellPrenom.Padding = 3;
                    if (note >= 0 && note <= 20)
                        cellNote = new PdfPCell(new Phrase(new Chunk(note.ToString().Replace(',', '.') + "", FontFactory.GetFont("Century Gothic", 9))));
                    else
                        cellNote = new PdfPCell(new Phrase(new Chunk(" ", FontFactory.GetFont("Century Gothic", 9))));
                    cellNote.Padding = 3;

                    table.AddCell(cellNo);
                    table.AddCell(cellCNE);
                    table.AddCell(cellNom);
                    table.AddCell(cellPrenom);
                    table.AddCell(cellNote);
                }


                document.Add(table);

                //document.Add(Chunk.NEXTPAGE);
                //document.Add(new Paragraph("This page will be followed by a blank page!"));
                //document.NewPage();

                document.Close();

                /* Ouvrir le fichier crée ou pas ? */
                DialogResult res = MessageBox.Show("Voulez-vous ouvrir le nouveau fichier PDF ?", "Nouveau fichier",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);

            }
            catch (IOException ex)
            {
                MessageBox.Show("Fermer l'ancien fichier pour le remplacer ou bien changer le du nouveau fichier PDF.", "INFORMATION",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
