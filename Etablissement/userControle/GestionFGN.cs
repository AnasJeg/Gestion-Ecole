using Etablissement.classes;
using Etablissement.services;
using MySqlConnector;
using Org.BouncyCastle.Crypto;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Etablissement.userControle
{
    public partial class GestionFGN : UserControl
    {

        private MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1; DATABASE=gestion_ecole; UID=root; PASSWORD=");
        static int id_F=0;
        static int id_M = 0;
        static int id_G = 0;
        ProfService pf = new ProfService();
        FilierService filierServ = new FilierService();
        ModuleService modserv =new ModuleService();
        GroupeService groupeserv = new GroupeService();
        MatiereService matiereServ = new MatiereService();
        DataTable dataTable;
        String nom_Fil;
        Image img;

        public GestionFGN()
        {
            InitializeComponent();

           // Card1();
        }

        private void GestionFGN_Load(object sender, EventArgs e)
        {
          //  filiere.Hide();
          //  module.Hide();
            remplirlist_Filiere();
            remplirFilieresModule();
            remplirRespModule();
           // remplirGroupeF();
            remplirlist_Module();
            remplirlist_Groupe();
            remplirGroupe();
        }

        /*
        public void Card1()
        {
            labelFiliere.Text = "";
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand Command = new MySqlCommand("select count(*) from filiere",con);
            // MySqlDataReader reader = Command.ExecuteReader();
            Int32 rows_c = Convert.ToInt32(Command.ExecuteScalar());
            // categoriecombo.Items.Add(reader.GetString("libelle"));
            labelFiliere.Text = "" + rows_c.ToString();
            con.Close();
        }
        */


        //*******************************************
        public void remplirFilieresModule()
        {
           
            comb_FM_search.Items.Clear();
            comb_FiliereMD.Items.Clear();
            comGrFiliereSearch.Items.Clear();
            comGrFil.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("select nom from filiere", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comb_FM_search.Items.Add(reader[0]);
                comb_FiliereMD.Items.Add(reader[0]);
                comGrFiliereSearch.Items.Add(reader[0]);
                comGrFil.Items.Add(reader[0]);
            }

            con.Close();
        }

        public void remplirGroupe()
        {
            comboBox_gr.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("select nomG from groupes", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox_gr.Items.Add(reader[0]);
            }

            con.Close();
        }



        public void remplirRespModule()
        {

            comRSFD.Items.Clear();
            comb_ProfMD.Items.Clear(); 
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("select nom from prof", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               
                comRSFD.Items.Add(reader[0]);
                comb_ProfMD.Items.Add(reader[0]);
            }

            con.Close();
        }

       /* public void remplirGroupeF()
        {
            comboFGroupe.Items.Clear();
            if (con.State != ConnectionState.Open) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("select nomG from groupes", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboFGroupe.Items.Add(reader[0]);
            }

            con.Close();
        }
       */
       

        private void filiere_Click(object sender, EventArgs e)
        {

        }

        private void module_Click(object sender, EventArgs e)
        {

        }
        // FILIERE 

        public void refreshFiliere()
        {
            TnFD.Clear();
            //   comboFGroupe.ResetText();
            comRSFD.ResetText();
            numFD.ResetText();
            remplirlist_Filiere();
        }

        public void remplirlist_Filiere()
        {
            String rs = "responsable";
            if (con.State != ConnectionState.Open) { con.Open(); }
            //  String query = "Select f.nom,f.prenom,e.cin ,e.email,e.age,e.sexe,e.ville,e.telephone,e.adresse,e.image,e.salaire,f.nom'" + fili + "',e.niveau,e.groupe from prof e,filiere f where e.id_filiere = f.id";
            //  Select f.nom,e.nom '" + rs + "', f.nombre_module,g.nomG '" + gn + "' from filiere f,prof e ,groupes g
           String query = "Select f.nom,e.nom '" + rs + "', f.nombre_module  from filiere f,prof e WHERE f.id_resp=e.id;";
       
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            this.dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            InfoFiliere.DataSource = dataTable;
            con.Close();

        }
        // D

        private void addFD_Click(object sender, EventArgs e)
        {
            String nom = TnFD.Text.ToString();
            String nomP = comRSFD.SelectedItem.ToString();
            int id_prf = pf.getIdProfByCIN(pf.get_CIN_ProfBy_Nom(nomP));
            int nbr = int.Parse(numFD.Value.ToString());

          String nomGF = comboBox_gr.SelectedItem.ToString();
            int id_groupeF = groupeserv.get_idGroupe_byNom(nomGF);


            DialogResult dialogClose = MessageBox.Show("Ajouter ?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                filierServ.ajouter(new FiliereC(nom, id_prf, nbr,id_groupeF));
                MessageBox.Show("done ");
                refreshFiliere();
                

            }
        }
        private void upD_Click(object sender, EventArgs e)
        {
            String nom = TnFD.Text.ToString();
            String nomP = comRSFD.SelectedItem.ToString();
            int id_prf = pf.getIdProfByCIN(pf.get_CIN_ProfBy_Nom(nomP));
            int nbr = int.Parse(numFD.Value.ToString());
            String nomGF = comboBox_gr.SelectedItem.ToString();
            int id_groupeF = groupeserv.get_idGroupe_byNom(nomGF);


            DialogResult dialogClose = MessageBox.Show("Modifier ?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                filierServ.modifier(new FiliereC(id_F, nom, id_prf, nbr, id_groupeF));
                MessageBox.Show("done Update");
                refreshFiliere();
               
            }
        }

        private void DeleteD_Click(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Supprimer ?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                filierServ.supprimer(id_F);
                MessageBox.Show(" Delete done");
                refreshFiliere();
            }
        }
        // Datagrid Filiere
        private void InfoProf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            else
            {
                DataGridViewRow selectedRow = InfoFiliere.Rows[index];
                 {
                    TnFD.Text = selectedRow.Cells["nom"].Value.ToString();
                    comRSFD.Text = selectedRow.Cells["responsable"].Value.ToString();
                    numFD.Value = Decimal.Parse(selectedRow.Cells["nombre_module"].Value.ToString());

                    id_F = filierServ.getFilierbyNom(TnFD.Text);
                    MessageBox.Show("id >> " + id_F);
           
                    con.Close();
                }
            }
        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        // Module   

        public void refreshModule()
        {
            
            TnMD.Clear();
            comb_FiliereMD.ResetText();
            comb_ProfMD.ResetText();
            nbrheur.ResetText();
            remplirlist_Module();

        }
        public void remplirlist_Module()
        {
            String fil = "Filiere";
            String prf = "Professeur";
            if (con.State != ConnectionState.Open) { con.Open(); }
            //  String query = "Select f.nom,f.prenom,e.cin ,e.email,e.age,e.sexe,e.ville,e.telephone,e.adresse,e.image,e.salaire,f.nom'" + fili + "',e.niveau,e.groupe from prof e,filiere f where e.id_filiere = f.id";
            String query = "Select m.nomM,m.nbrHeures,f.nom '" + fil + "' ,p.nom '" + prf + "' from matiere m, filiere f,prof p where m.id_filiere=f.id AND m.id_prof=p.id";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            this.dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            InfoModule.DataSource = dataTable;
            con.Close();

        }

        private void InfoModule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            else
            {
                DataGridViewRow selectedRow = InfoModule.Rows[index];
                {
                    TnMD.Text = selectedRow.Cells["nomM"].Value.ToString();
                    comb_FiliereMD.Text = selectedRow.Cells["Filiere"].Value.ToString();
                    comb_ProfMD.Text = selectedRow.Cells["Professeur"].Value.ToString();
                    nbrheur.Value =int.Parse( selectedRow.Cells["nbrHeures"].Value.ToString());
                    id_M = matiereServ.getId_Mod_byNom(TnMD.Text);
                    MessageBox.Show("id Module => " + id_M);

                    con.Close();
                }
            }
        }

     
       
        private void AddMD_Click(object sender, EventArgs e)
        {
            String nom = TnMD.Text.ToString();
            String nomF = comb_FiliereMD.SelectedItem.ToString();
            int id_FM = filierServ.getFilierbyNom(nomF);
            String nomP = comb_ProfMD.SelectedItem.ToString();
            int id_prfM = pf.getId_ProfByNom(nomP);
            int nbrH = int.Parse(nbrheur.Value.ToString());
            System.Drawing.Image im = img;

            DialogResult dialogClose = MessageBox.Show("Ajouter Module ?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                //   modserv.ajouter(new ModuleC(nom, id_FM, id_prfM));
                matiereServ.ajouter(new Matiere(nom,nbrH,id_prfM,id_FM,im));
                MessageBox.Show("done Ajout Module");
                refreshModule();

            }
        }
        private void updateModuleD_Click(object sender, EventArgs e)
        {
            String nom = TnMD.Text.ToString();
            String nomF = comb_FiliereMD.SelectedItem.ToString();
            int id_FM = filierServ.getFilierbyNom(nomF);
            String nomP = comb_ProfMD.SelectedItem.ToString();
            int id_prfM = pf.getId_ProfByNom(nomP);
            int nbrH = int.Parse(nbrheur.Value.ToString());
            System.Drawing.Image im = img;


            DialogResult dialogClose = MessageBox.Show("Modifier Module D ?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                //  modserv.modifier(new ModuleC(id_M, nom, id_FM, id_prfM));
                matiereServ.modifier(new Matiere(id_M, nom, nbrH, id_prfM, id_FM, im));
                MessageBox.Show("done Update module D");
                refreshModule();

            }
        }

        private void DelModuleD_Click(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Supprimer Module D?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
              //  modserv.supprimer(id_M);
                matiereServ.supprimer(id_M);
                MessageBox.Show(" Delete module D done");
                refreshModule();
            }
        }

        private void searchModule_CheckedChanged(object sender, EventArgs e)
        {

            String NomFilierM;
            if (comb_FM_search.SelectedIndex < 0)
            {
                DialogResult dialogClose = MessageBox.Show(" index null !! ", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                refreshModule();
            }
            else

            {
                    String fil = "Filiere";
                    String prf = "Professeur";
                    String nomF = comb_FM_search.SelectedItem.ToString();
                    int id_FMS = filierServ.getFilierbyNom(nomF);

                    Console.WriteLine("nomfiliere :>>>> " + comb_FM_search.SelectedItem.ToString());
                    Console.WriteLine("id filiere module = " + id_FMS);
                String query = "Select m.nomM,m.nbrHeures,f.nom '" + fil + "' ,p.nom '" + prf + "' from matiere m, filiere f,prof p where m.id_filiere=f.id AND m.id_prof=p.id AND  m.id_filiere='"+ id_FMS + "'";

                if (con.State != ConnectionState.Open) { con.Open(); }
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    DataTable datatable = new DataTable();
                    MySqlDataAdapter oleDbData = new MySqlDataAdapter(cmd);
                    oleDbData.Fill(datatable);
                    con.Close();
                    InfoModule.DataSource = datatable;
              
              
            }
        }

        private void searchModule_Click(object sender, EventArgs e)
        {

            String NomFiliere;
            if (comb_FM_search.SelectedIndex < 0)
            {
                DialogResult dialogClose = MessageBox.Show(" index null !! ", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
            else

            {

                String fili = "Filiere";
                String nom = TnG.Text.ToString();
                int nbrEt = int.Parse(nbrEtud.Value.ToString());
                String nS = numS.Text.ToString();
                String nomF = comb_FM_search.SelectedItem.ToString();
                int id_fl = filierServ.getFilierbyNom(nomF);


                Console.WriteLine("nomfiliere :>>>> " + comb_FM_search.SelectedItem.ToString());
                String query = "Select g.nomG, g.nbrEtudiants , g.numSalle, f.nom '" + fili + "' FROM groupes g, filiere f WHERE id_fil=f.id AND f.nom='" + nomF + "'";
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable datatable = new DataTable();
                MySqlDataAdapter oleDbData = new MySqlDataAdapter(cmd);
                oleDbData.Fill(datatable);
                con.Close();
                InfoModule.DataSource = datatable;
            }
        }


        // Groupe 


        public void remplirlist_Groupe()
        {
            String fil = "Filiere";
            if (con.State != ConnectionState.Open) { con.Open(); }
            //  String query = "Select f.nom,f.prenom,e.cin ,e.email,e.age,e.sexe,e.ville,e.telephone,e.adresse,e.image,e.salaire,f.nom'" + fili + "',e.niveau,e.groupe from prof e,filiere f where e.id_filiere = f.id";
            String query = "Select g.nomG, g.nbrEtudiants , g.numSalle, f.nom '" + fil + "' FROM groupes g, filiere f WHERE id_fil=f.id;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            this.dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            InfoGroupe.DataSource = dataTable;
            con.Close();

        }

        public void RefreshGroupe()
        {
            TnG.Clear();
            nbrEtud.ResetText();
            numS.Clear();
            comGrFil.ResetText();
            remplirlist_Groupe();
        }
        private void InfoGroupe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            else

            //  id nomG  id nomG nbrEtudiants numSalle id_fil numSalle id_fil
            {
                DataGridViewRow selectedRow = InfoGroupe.Rows[index];
                {
                    TnG.Text = selectedRow.Cells["nomG"].Value.ToString();
                    nbrEtud.Value = Decimal.Parse(selectedRow.Cells["nbrEtudiants"].Value.ToString());
                    numS.Text = selectedRow.Cells["numSalle"].Value.ToString();
                    comGrFil.Text = selectedRow.Cells["Filiere"].Value.ToString();

                    id_G = groupeserv.get_idGroupe_byNom(TnG.Text);
                    MessageBox.Show("id Groupe => " + id_G);

                    con.Close();
                }
            }
        }

        private void addG_Click(object sender, EventArgs e)
        {
            String nom = TnG.Text.ToString();
            int nbrEt = int.Parse(nbrEtud.Value.ToString());
            String nS = numS.Text.ToString();
            String nomF = comGrFil.SelectedItem.ToString();
            int id_fl = filierServ.getFilierbyNom(nomF);



            DialogResult dialogClose = MessageBox.Show("Ajouter Groupe D ?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                groupeserv.ajouter(new GroupesC(nom, nbrEt, nS, id_fl));
                MessageBox.Show("done ajout Groupe D");
                RefreshGroupe();

            }
        }

        private void updateG_Click(object sender, EventArgs e)
        {
            
            String nom = TnG.Text.ToString();
           int nbrEt = int.Parse(nbrEtud.Value.ToString());
            String nS = numS.Text.ToString();
            String nomF = comGrFil.SelectedItem.ToString();
            int id_fl = filierServ.getFilierbyNom(nomF);
          


            DialogResult dialogClose = MessageBox.Show("Modifier Groupe D ?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                groupeserv.modifier(new GroupesC(id_G, nom, nbrEt, nS,id_fl));
                MessageBox.Show("done Update Groupe D");
                RefreshGroupe();

            }
        }

        private void DeleteG_Click(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Supprimer groupe D?!", "Info !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                groupeserv.supprimer(id_G);
                MessageBox.Show(" Delete groupe D done");
                RefreshGroupe();
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            String NomFiliere;
            if (comGrFiliereSearch.SelectedIndex < 0)
            {
                DialogResult dialogClose = MessageBox.Show(" index null !! ", "Attention!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
            else

            {

                String fili = "Filiere";
                String nom = TnG.Text.ToString();
                int nbrEt = int.Parse(nbrEtud.Value.ToString());
                String nS = numS.Text.ToString();
                String nomF = comGrFiliereSearch.SelectedItem.ToString();
                int id_fl = filierServ.getFilierbyNom(nomF);


                Console.WriteLine("nomfiliere :>>>> " + comGrFiliereSearch.SelectedItem.ToString());
                String query = "Select g.nomG, g.nbrEtudiants , g.numSalle, f.nom '" + fili + "' FROM groupes g, filiere f WHERE id_fil=f.id AND id_fil='" + id_fl + "'";
                if (con.State != ConnectionState.Open) { con.Open(); }
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable datatable = new DataTable();
                MySqlDataAdapter oleDbData = new MySqlDataAdapter(cmd);
                oleDbData.Fill(datatable);
                con.Close();
                InfoGroupe.DataSource = datatable;
            }
        }

        private void picEtud_Click(object sender, EventArgs e)
        {

        }

        private void upload_Click(object sender, EventArgs e)
        {
            Matiere mt = new Matiere();
            System.Drawing.Image ima;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All Files(*.jpg;*.png;*.gif;*.jpeg;*.pdf) | *.jpg;*.png;*.gif;*.jpeg;*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    picEtud.Image = System.Drawing.Image.FromFile(ofd.FileName);
                    ima = System.Drawing.Image.FromFile(ofd.FileName);
                    mt.Image = ima;
                    mt.Image.Tag = ofd.FileName;
                    img = ima;


                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

      
    }
}
