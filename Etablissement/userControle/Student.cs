using Etablissement.classes;
using Etablissement.services;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace Etablissement.userControle
{
    public partial class Student : UserControl
    {
        EtudService st = new EtudService();
        FilierService filierServ= new FilierService();
        GroupeService groupSer = new GroupeService();
        MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");
        byte[] img;
        DataTable dataTable;
        static int id;
        String nomfiliere;
        String fil;
        String nom_Fil;
        String cinE;
        System.Drawing.Image imgEt;
        
        public Student()
        {
            InitializeComponent();
       //     remplirlisteEtudiant();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            remplirFilieresModule();
            remplirVille();
          //  remplirGroupe();
            remplirlisteEtudiant();

        }

        public String SexeCheck()
        {
            String s="default";
            if (men.Checked)
                s="homme";
           else if (women.Checked)
                s="femme";
            
            return s;
        }

        public void remplirFilieresModule()
        {
            comFilier.Items.Clear();
            combFS.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("select nom from filiere", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comFilier.Items.Add(reader[0]);
                combFS.Items.Add(reader[0]);

            }
           
            con.Close();
        }

        

        private void combFS_SelectedIndexChanged(object sender, EventArgs e)
        {
            nom_Fil = combFS.SelectedItem.ToString();

         //   DialogResult dialogClose = MessageBox.Show("nom : "+nom_Fil+"", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
          
         //   remplirNiveau(nom_Fil);
           remplirGroupeFill(nom_Fil);

        }

        public void remplirGroupe(String n)
        {
          //  comboBox_gr.Items.Clear();
            combGS.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }
        //    MySqlCommand cmd = new MySqlCommand("select nomG from groupes ", con);
            MySqlCommand cmd = new MySqlCommand(" SELECT g.nomG from groupes g,filiere f where g.id_fil=f.id AND f.nom='" + n + "'", con);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
             //   comboBox_gr.Items.Add(reader[0]);
                combGS.Items.Add(reader[0]);
            }

            con.Close();
        }

        public void remplirGroupeET(String nn)
        {
            comboBox_gr.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }

            MySqlCommand cmd = new MySqlCommand(" SELECT g.nomG from groupes g,filiere f where g.id_fil=f.id AND f.nom='" + nn + "'", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("combFS >>>>>  " + comboBox_gr.ToString());
            while (reader.Read())
            {
                comboBox_gr.Items.Add(reader[0]);
            }

            con.Close();

        }

        private void comFilier_SelectedIndexChanged(object sender, EventArgs e)
        {
            String nff= comFilier.SelectedItem.ToString();
            remplirGroupeET(nff);
        }

        /*
        public void remplirNiveau(String nn)
        {
            combNS.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }
           MySqlCommand cmd = new MySqlCommand("SELECT nomG from groupes WHERE id_fil = (SELECT id from filiere where nom='" + nn + "')", con);
            MySqlDataReader reader = cmd.ExecuteReader(); 

            while (reader.Read())
            {
                combNS.Items.Add(reader[0]);
            }

            con.Close();

        }
        */
        public void remplirGroupeFill(String nn)
        {
            combGS.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }
           
            MySqlCommand cmd = new MySqlCommand(" SELECT g.nomG from groupes g,filiere f where g.id_fil=f.id AND f.nom='" + nn + "'", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("combFS >>>>>  " + combFS.ToString());
            while (reader.Read())
            {
                combGS.Items.Add(reader[0]);
            }

            con.Close();

        }
        
        public void remplirVille()
        {
            combVille.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("select ville from ville", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                combVille.Items.Add(reader[0]);

            }
            con.Close();
        }

        public void remplirlisteEtudiant()
        {
            String fili = "filiere";
            if (con.State != ConnectionState.Open) { con.Open(); }
            String query = "Select e.nom,e.prenom,e.cin,e.cne,e.email,e.age,e.sexe,e.date_naissance,e.ville,e.telephone,e.adresse,e.image,f.nom'" + fili + "',e.niveau,e.groupe from etudiants e,filiere f where e.id_filiere = f.id";
          // String query = "Select * from etudiants";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            this.dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            InfoEtud.DataSource = dataTable;
           con.Close();


        }

       public void refresh()
        {
            remplirFilieresModule();
        //    remplirGroupe();
            Tn.Clear();
            Tp.Clear();
            NumAge.ResetText();
            Temail.Clear();
            Ttell.Clear();
            Tadresse.Clear();
            Tcin.Clear();
            Tcne.Clear();
            dateN.ResetText();
            NumAnne.ResetText();
            comboBox_gr.ResetText();
            men.Checked = false;
            women.Checked = false;
            cinD.Clear();
            cneD.Clear();
            emailD.Clear();
            villeD.Clear();
            tellD.Clear();
            remplirlisteEtudiant();
        }

        private void upload_Click(object sender, EventArgs e)
        {
            StudentC stuC = new StudentC();
            System.Drawing.Image ima;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                // ofd.Filter = "All Files |*.*|JPG|*.jpg|PNG|*.png";
                ofd.Filter = "All Files(*.jpg;*.png;*.gif;*.jpeg;*.pdf) | *.jpg;*.png;*.gif;*.jpeg;*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    /*
                    picEtud.Image = System.Drawing.Image.FromFile(ofd.FileName);
                    image = System.Drawing.Image.FromFile(ofd.FileName); 
                    var ms = new MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] i = ms.ToArray();
                    img = i;

                  */
                    picEtud.Image = System.Drawing.Image.FromFile(ofd.FileName);
                    ima= System.Drawing.Image.FromFile(ofd.FileName);
                    stuC.Image = ima;
                    stuC.Image.Tag = ofd.FileName;
                    imgEt = ima;


                }
                else
                {

                }

            }
            catch (Exception ex)
            {

            }
        }

     
        private void InfoEtud_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void combFilier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            String NomStudent;
            if (combFS.SelectedIndex < 0 || combGS.SelectedIndex < 0 || combNS.SelectedIndex < 0)
            {
                DialogResult dialogClose = MessageBox.Show(" index null !! ", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
            else

            {

                String fili = "nomfiliere";
                String nomF = combFS.SelectedItem.ToString();
                // int id_F = filierServ.getFilierbyNom(nomF);
                String nomgrp = combGS.SelectedItem.ToString();
                int gS = groupSer.get_idGroupe_byNom(nomgrp);
                int nS=int.Parse(combNS.SelectedItem.ToString());

                Console.WriteLine("nomfiliere :>>>> " + combFS.SelectedItem.ToString());
                String ir = "iir4";
                String query = "Select e.nom,e.prenom,e.cin,e.cne,e.email,e.age,e.sexe,e.date_naissance,e.ville,e.telephone,e.adresse,e.image,f.nom'" + fili + "',e.niveau,e.groupe from etudiants e,filiere f where e.id_filiere = f.id AND f.nom ='" + nomF + "' AND e.niveau='" + nS + "' AND e.groupe='" + gS + "'";
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable datatable = new DataTable();
                MySqlDataAdapter oleDbData = new MySqlDataAdapter(cmd);
                oleDbData.Fill(datatable);
                con.Close();
                InfoEtud.DataSource = datatable;
            }
        }

     

        private void Tn_TextChanged(object sender, EventArgs e)
        {

        }

        private void print_Click_1(object sender, EventArgs e)
        {
            
            if (InfoEtud.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Name.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Unable to wride data in disk" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(InfoEtud.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            List<DataGridViewColumn> listVisible = new List<DataGridViewColumn>();
                      
                            foreach (DataGridViewColumn col in InfoEtud.Columns)
                            {
                                if (col.Visible) { 
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                                    listVisible.Add(col);

                                }
                            }

                          
                            foreach (DataGridViewRow viewRow in InfoEtud.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    //    DataGridViewRow selectedRow = InfoEtud.Rows[index];
                                    // listVisible[j].Name
                                    pTable.AddCell(dcell.Value.ToString());

                                }
                            }
                            

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.AddTitle("PDF creation using iTextSharp");
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Data Export Successfully", "info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while exporting Data" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found", "Info");
            }
            
            /*
           
          */
        }

        private void printTest_Click(object sender, EventArgs e)
        {
            List<DataGridViewColumn> listVisible = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in InfoEtud.Columns)
            {
                if (col.Visible)
                    listVisible.Add(col);
            }
            PdfPTable pdfTable = new PdfPTable(listVisible.Count);
            pdfTable.DefaultCell.Padding = 2;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            //Adding Header row
            for (int i = 0; i < listVisible.Count; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(listVisible[i].HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            for (int i = 0; i < InfoEtud.Rows.Count - 1; i++)
            {
                for (int j = 0; j < listVisible.Count; j++)
                {
                    try
                    {
                        pdfTable.AddCell(InfoEtud.Rows[i].Cells[listVisible[j].Name].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.HelpLink);
                    }
                }
            }
            SaveFileDialog svg = new SaveFileDialog();
            svg.ShowDialog();

            using (FileStream stream = new FileStream(svg.FileName + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
                MessageBox.Show("PDF Created Successfully");
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            String email = Temail.Text.ToString();
            if (email == "" || !(email.Contains("@")))
            {
                Temail.BorderColor = Color.Red;
                return;
            }

            String nom = Tn.Text.ToString();
            String prenom = Tp.Text.ToString();
            int age = int.Parse(NumAge.Value.ToString());

            string pattern = "^[0-9]{10}$";
            Regex reg = new Regex(pattern);

            String tell = Ttell.Text.ToString();
            if (tell == "" || !reg.IsMatch(tell))
            {
                Ttell.BorderColor = Color.Red;
                return;

            }
            String address = Tadresse.Text.ToString();
            String sexe = SexeCheck();
            String cne = Tcne.Text.ToString();
            String cin = Tcin.Text.ToString();
            DateTime dateNais = dateN.Value.Date;
            String villeO = combVille.SelectedItem.ToString();
            System.Drawing.Image im = imgEt;
            int nv = int.Parse(NumAnne.Value.ToString());
            String nameF = comFilier.SelectedItem.ToString();
            int id_filiere = filierServ.getFilierbyNom(nameF);
            String nomG = comboBox_gr.SelectedItem.ToString();
            int num_gr = groupSer.get_idGroupe_byNom(nomG);

            DialogResult dialogClose = MessageBox.Show("Ajouter ?", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                StudentC stud = new StudentC(nom, prenom, cin, cne, email, age, sexe, dateNais, villeO, tell, address, im, id_filiere, nv, num_gr);
                st.ajouter(stud);
                refresh();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {

            String email = Temail.Text.ToString();
            if (email == "" || !(email.Contains("@")))
            {
                Temail.BorderColor = Color.Red;
                return;
            }

            String nom = Tn.Text.ToString();
            String prenom = Tp.Text.ToString();
            int age = int.Parse(NumAge.Value.ToString());

            string pattern = "^[0-9]{10}$";
            Regex reg = new Regex(pattern);

            String tell = Ttell.Text.ToString();
            if (tell == "" || !reg.IsMatch(tell))
            {
                Ttell.BorderColor = Color.Red;
                return;

            }
            String address = Tadresse.Text.ToString();
            String sexe = SexeCheck();
            String cne = Tcne.Text.ToString();
            String cin = Tcin.Text.ToString();
            DateTime dateNais =  dateN.Value.Date;
            String villeO = combVille.SelectedItem.ToString();
          
            int nv = int.Parse(NumAnne.Value.ToString());
            String nameF = comFilier.SelectedItem.ToString();
            int id_filiere = filierServ.getFilierbyNom(nameF);
            String nomG = comboBox_gr.SelectedItem.ToString();
            int num_gr = groupSer.get_idGroupe_byNom(nomG);

            DialogResult dialogClose = MessageBox.Show("Modifier ?", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                StudentC stud = new StudentC(id, nom, prenom, cin, cne, email, age, sexe, dateNais, villeO, tell, address, id_filiere, nv, num_gr);
                st.modifier(stud);
                refresh();
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
           
            DialogResult dialogClose = MessageBox.Show("Supprimer ?", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                 st.supprimer(id);
                refresh();
            }

        }

        private void InfoEtud_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            else
            {
                DataGridViewRow selectedRow = InfoEtud.Rows[index];
                cneD.Text = selectedRow.Cells["cne"].Value.ToString();
                cinD.Text = selectedRow.Cells["cin"].Value.ToString();
                tellD.Text = selectedRow.Cells["telephone"].Value.ToString();
                emailD.Text = selectedRow.Cells["email"].Value.ToString();
                villeD.Text = selectedRow.Cells["ville"].Value.ToString();
                {
                    Tn.Text = selectedRow.Cells["nom"].Value.ToString();
                    Tp.Text = selectedRow.Cells["prenom"].Value.ToString();
                    Tcne.Text = selectedRow.Cells["cne"].Value.ToString();
                    Tcin.Text = selectedRow.Cells["cin"].Value.ToString();
                    String sexe = selectedRow.Cells["sexe"].Value.ToString();
                    if (sexe.Equals("men"))
                        men.Checked = true;
                    else
                        women.Checked = true;

                    Temail.Text = selectedRow.Cells["email"].Value.ToString();
                    Tadresse.Text = selectedRow.Cells["adresse"].Value.ToString();
                    NumAge.Value = Decimal.Parse(selectedRow.Cells["age"].Value.ToString());
                    NumAnne.Value = Decimal.Parse(selectedRow.Cells["niveau"].Value.ToString());
                    Ttell.Text = selectedRow.Cells["telephone"].Value.ToString();
                    comFilier.Text = selectedRow.Cells["filiere"].Value.ToString();
                    combVille.Text = selectedRow.Cells["ville"].Value.ToString();
                    //  NumGroupe.Value = Decimal.Parse(selectedRow.Cells["groupe"].Value.ToString());
                    String mG = groupSer.get_NomGroupe_byId(int.Parse(selectedRow.Cells["groupe"].Value.ToString()));
                    comboBox_gr.Text = mG;
                    dateN.Value = DateTime.Parse( selectedRow.Cells["date_naissance"].Value.ToString());
                    id = st.getIdEtudiantByCIN(cinD.Text.ToString());
                    MessageBox.Show("id >> " + id);
                    byte[] c = null;
                    if (con.State != ConnectionState.Open) { con.Open(); }
                    String query = "select image from etudiants where cin='" + cinD.Text.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    byte[] imgg = (byte[])table.Rows[0][0];
                    MemoryStream ms = new MemoryStream(imgg);
                    picEtud.Image = System.Drawing.Image.FromStream(ms);
                    picEtud2.Image = System.Drawing.Image.FromStream(ms);

                    con.Close();
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void combFS_MouseEnter(object sender, EventArgs e)
        {
            combGS.ResetText();
            combNS.ResetText();
        }

       
    }
}
