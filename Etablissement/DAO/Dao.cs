using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.DAO
{
    internal interface Dao<T>
    {
         void ajouter(T c);
        void modifier(T c);
        void supprimer(int id);

        void afficher(T c);
        void searchById(int id);
    }
}
