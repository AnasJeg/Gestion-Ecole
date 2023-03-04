using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.classes
{
    internal class ModuleC
    {
        private int id;
        private String nom;
        private int id_filiere;
        private int id_prof;
        private static int cnt = 0;
         
        public ModuleC() { }
        public ModuleC(int id, string nom, int id_filiere, int id_prof)
        {
            this.id = id;
            this.nom = nom;
            this.id_filiere = id_filiere;
            this.id_prof = id_prof;
        }

        public ModuleC(string nom, int id_filiere, int id_prof)
        {
            this.id = ++cnt;
            this.nom = nom;
            this.id_filiere = id_filiere;
            this.id_prof = id_prof;
        }


        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Id_filiere { get => id_filiere; set => id_filiere = value; }
        public int Id_prof { get => id_prof; set => id_prof = value; }

    }
}
