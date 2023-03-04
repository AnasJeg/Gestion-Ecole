using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.classes
{
    internal class GroupesC
    {
        private int id;
        private string nomG;
        private int nbrEtudiants;
        private String numSalle;
        private int id_filiere;
        private static int cnt = 0;

        public GroupesC()
        {
        }

        public int Id { get => id; set => id = value; }
        public string NomG { get => nomG; set => nomG = value; }
        public int NbrEtudiants { get => nbrEtudiants; set => nbrEtudiants = value; }
        
        public int Id_filiere { get => id_filiere; set => id_filiere = value; }
        public string NumSalle { get => numSalle; set => numSalle = value; }

        public GroupesC(int id, string nomG, int nbrEtudiants, String numSalle, int id_filiere)
        {
            this.id = id;
            this.nomG = nomG;
            this.nbrEtudiants = nbrEtudiants;
            this.numSalle = numSalle;
            this.id_filiere = id_filiere;
        }

        public GroupesC(string nomG, int nbrEtudiants, String numSalle, int id_filiere)
        {
            this.id = ++cnt;
            this.nomG = nomG;
            this.nbrEtudiants = nbrEtudiants;
            this.numSalle = numSalle;
            this.id_filiere = id_filiere;
        }
    }
}
