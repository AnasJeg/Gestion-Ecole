using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.classes
{
    internal class NotesC
    {
        private int id;
        private int numM;
        private double note;
        private int num_Etud;
        private static int cnt = 0;

        public int NumM { get => numM; set => numM = value; }
        public double Note { get => note; set => note = value; }
        public int Num_Etud { get => num_Etud; set => num_Etud = value; }

        NotesC() { }   
        public NotesC(int numM, double note, int num_Etud)
        {
            this.id = ++ cnt;
            this.numM = numM;
            this.note = note;
            this.num_Etud = num_Etud;
        }

        
    }
}
