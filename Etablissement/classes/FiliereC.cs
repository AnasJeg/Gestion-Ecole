using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.classes
{
    public class FiliereC
    {
        private int id;
        private string nom;
        private int id_resp;
        private int nombre_module;
        private int id_groupe;
        private static int cnt = 0;

        public FiliereC()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Id_resp { get => id_resp; set => id_resp = value; }
        public int Nombre_module { get => nombre_module; set => nombre_module = value; }
        public int Id_groupe { get => id_groupe; set => id_groupe = value; }

        public FiliereC( string nom, int id_resp, int nombre_module, int id_groupe)
        {
            this.id = ++cnt;
            this.nom = nom;
            this.id_resp = id_resp;
            this.nombre_module = nombre_module;
            this.id_groupe = id_groupe;
        }

        public FiliereC(int id, string nom, int id_resp, int nombre_module, int id_groupe)
        {
            this.id = id;
            this.nom = nom;
            this.id_resp = id_resp;
            this.nombre_module = nombre_module;
            this.id_groupe = id_groupe;
        }
    }
}
