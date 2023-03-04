using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.classes
{
    internal class SpecialiteC
    {
        private int id;
        private string nom;
        private static int cnt = 0;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }


        public SpecialiteC(string nom)
        {
            this.id = ++cnt;
            this.nom = nom;
        }
        public SpecialiteC(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }
    }
}
