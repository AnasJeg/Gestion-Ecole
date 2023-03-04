using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.classes
{
    public class Filiere
    {
        public int numF { get; set; }
        public string nomF { get; set; }
        public int nbrMatiere { get; set; }
        public int numC { get; set; }

        public Filiere(int numF, string nomF, int nbrMatiere, int numC)
        {
            this.numF = numF;
            this.nomF = nomF;
            this.nbrMatiere = nbrMatiere;
            this.numC = numC;
        }

        public Filiere()
        {
        }
    }
}
