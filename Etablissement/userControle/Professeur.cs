using Etablissement.classes;
using Etablissement.services;
using MySqlConnector;
using System;
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

namespace Etablissement.userControle
{
    public partial class Professeur : UserControl
    {
        ProfService st = new ProfService();
        FilierService filierServ = new FilierService();
        MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");
        byte[] img;
        DataTable dataTable;
        static int id=0;
        String nom_Fil;

        public Professeur()
        {
            InitializeComponent();
        }

        private void Professeur_Load(object sender, EventArgs e)
        {
            remplirFilieresModule();
            remplirVille();
            remplirlisteProf();
        }

        public String SexeCheck()
        {
            String s = "default";
            if (men.Checked)
                s = "homme";
            else if (women.Checked)
                s = "femme";

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

            DialogResult dialogClose = MessageBox.Show("nom : " + nom_Fil + "", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

         
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

        public void remplirlisteProf()
        {
            String fili = "filiere";
            if (con.State != ConnectionState.Open) { con.Open(); }
            String query = "Select e.nom,e.prenom,e.cin ,e.email,e.age,e.sexe,e.ville,e.telephone,e.adresse,e.image,e.salaire,f.nom'" + fili + "',e.login from prof e,filiere f where e.id_filiere = f.id";
           //  String query = "Select * from prof";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            this.dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            InfoProf.DataSource = dataTable;
            con.Close();


        }

        public void refresh()
        {
            remplirFilieresModule();
            Tn.Clear();
            Tp.Clear();
            NumAge.ResetText();
            Temail.Clear();
            Ttell.Clear();
            Tadresse.Clear();
            Tcin.Clear();
            Tsal.Clear();
            men.Checked = false;
            women.Checked = false;
            cinD.Clear();
            emailD.Clear();
            villeD.Clear();
            tellD.Clear();
            remplirlisteProf();
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
            String cin = Tcin.Text.ToString();
            String villeO = combVille.SelectedItem.ToString();
            byte[] image = img;
         //   int nv = int.Parse(NumAnne.Value.ToString());
            String nameF = comFilier.SelectedItem.ToString();
            int id_filiere = filierServ.getFilierbyNom(nameF);
          //  int num_gr = int.Parse(NumGroupe.Value.ToString());
            int salaire = int.Parse(Tsal.Text.ToString());
            String log = Tlogin.Text.ToString();
            DialogResult dialogClose = MessageBox.Show("Ajouter ?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                ProfC prof = new ProfC(nom, prenom, cin,email, age, sexe,villeO, tell, address, image,salaire, id_filiere, log);
                st.ajouter(prof);
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
            else
            {
                Temail.BorderColor = Color.Green;
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
            else
            {
                Temail.BorderColor = Color.Green;
            }

            String address = Tadresse.Text.ToString();
            String sexe = SexeCheck();
            String cin = Tcin.Text.ToString();
            String villeO = combVille.SelectedItem.ToString();
            byte[] image = img;
          //  int nv = int.Parse(NumAnne.Value.ToString());
            String nameF = comFilier.SelectedItem.ToString();
            int id_filiere = filierServ.getFilierbyNom(nameF);
        //    int num_gr = int.Parse(NumGroupe.Value.ToString());
            int salaire = int.Parse(Tsal.Text.ToString());
            String log = Tlogin.Text.ToString();
            DialogResult dialogClose = MessageBox.Show("Modifier ?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                ProfC prof = new ProfC(id,nom, prenom, cin, email, age, sexe, villeO, tell, address, image,salaire, id_filiere, log);
                st.modifier(prof);
                refresh();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Supprimer ?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                st.supprimer(id);
                refresh();
            }
        }

        private void upload_Click(object sender, EventArgs e)
        {
            System.Drawing.Image image;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                // ofd.Filter = "All Files |*.*|JPG|*.jpg|PNG|*.png";
                ofd.Filter = "All Files(*.jpg;*.png;*.gif;*.jpeg;*.pdf) | *.jpg;*.png;*.gif;*.jpeg;*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picEtud.Image = System.Drawing.Image.FromFile(ofd.FileName);
                    image = System.Drawing.Image.FromFile(ofd.FileName); ;
                    var ms = new MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] i = ms.ToArray();
                    img = i;
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

            }
        }

        private void InfoProf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            else
            {
                DataGridViewRow selectedRow = InfoProf.Rows[index];
                cinD.Text = selectedRow.Cells["cin"].Value.ToString();
                tellD.Text = selectedRow.Cells["telephone"].Value.ToString();
                emailD.Text = selectedRow.Cells["email"].Value.ToString();
                villeD.Text = selectedRow.Cells["ville"].Value.ToString();
                {
                    Tn.Text = selectedRow.Cells["nom"].Value.ToString();
                    Tp.Text = selectedRow.Cells["prenom"].Value.ToString();
                    Tcin.Text = selectedRow.Cells["cin"].Value.ToString();
                    String sexe = selectedRow.Cells["sexe"].Value.ToString();
                    if (sexe.Equals("men"))
                        men.Checked = true;
                    else
                        women.Checked = true;

                    Temail.Text = selectedRow.Cells["email"].Value.ToString();
                    Tadresse.Text = selectedRow.Cells["adresse"].Value.ToString();
                    NumAge.Value = Decimal.Parse(selectedRow.Cells["age"].Value.ToString());
               //     NumAnne.Value = Decimal.Parse(selectedRow.Cells["niveau"].Value.ToString());
                    Ttell.Text = selectedRow.Cells["telephone"].Value.ToString();
                    comFilier.Text = selectedRow.Cells["filiere"].Value.ToString();
                    combVille.Text = selectedRow.Cells["ville"].Value.ToString();
                    Tlogin.Text = selectedRow.Cells["login"].Value.ToString();
                    //   NumGroupe.Value = Decimal.Parse(selectedRow.Cells["groupe"].Value.ToString());
                    id = st.getIdProfByCIN(cinD.Text.ToString());
                    MessageBox.Show("id >> " + id);
                    byte[] c = null;
                    if (con.State != ConnectionState.Open) { con.Open(); }
                    String query = "select image from prof where cin='" + cinD.Text.ToString() + "'";
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

        private void searchButton_Click(object sender, EventArgs e)
        {

            String NomStudent;
            if (combFS.SelectedIndex < 0 )
            {
                DialogResult dialogClose = MessageBox.Show(" index null !! ", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
            else

            {

                String fili = "filiere";
                String nomF = combFS.SelectedItem.ToString();
                // int id_F = filierServ.getFilierbyNom(nomF);
              
                Console.WriteLine("nomfiliere :>>>> " + combFS.SelectedItem.ToString());
                String ir = "iir4";
                String query = "Select e.nom,e.prenom,e.cin ,e.email,e.age,e.sexe,e.ville,e.telephone,e.adresse,e.image,e.salaire,f.nom'" + fili + "',e.login from prof e,filiere f where e.id_filiere = f.id and f.nom='"+nomF+"'";
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable datatable = new DataTable();
                MySqlDataAdapter oleDbData = new MySqlDataAdapter(cmd);
                oleDbData.Fill(datatable);
                con.Close();
                InfoProf.DataSource = datatable;
            }
        }
    }
}
