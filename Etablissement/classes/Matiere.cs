using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.classes
{
    public class Matiere
    {
        private int id;
        private string nomM;
        private int nbrheures;
        private int num_Ens;
        private int id_filiere;
        private Image image;
        private static int cnt = 0;

        public int Id { get => id; set => id = value; }
        public string NomM { get => nomM; set => nomM = value; }
        public int Nbrheures { get => nbrheures; set => nbrheures = value; }
        public int Num_Ens { get => num_Ens; set => num_Ens = value; }
        public Image Image { get => image; set => image = value; }
        public int Id_filiere { get => id_filiere; set => id_filiere = value; }

        public Matiere()
        {
        }

        public Matiere(string nomM, int nbrheures, int num_Ens, int id_filiere, Image image)
        {
            this.id = ++cnt;
            this.nomM = nomM;
            this.nbrheures = nbrheures;
            this.num_Ens = num_Ens;
            this.id_filiere = id_filiere;
            this.image = image;
        }

        public Matiere(int id, string nomM, int nbrheures, int num_Ens, int id_filiere, Image image)
        {
            this.id = id;
            this.nomM = nomM;
            this.nbrheures = nbrheures;
            this.num_Ens = num_Ens;
            this.id_filiere = id_filiere;
            this.image = image;
        }
    }
}
