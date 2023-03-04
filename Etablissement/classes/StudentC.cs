using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.classes
{
    public class StudentC
    {
        private int id;
        private String nom;
        private String prenom;
        private String cin;
        private String cne;
        private String email;
        private int age;
        private String sexe;
        private DateTime date_N;
        private String ville;
        private String telephone;
        private String address;
        private Image image;
        private int filiere;
        private int niveau;
        private int groupe;
        private static int cnt = 0;

        public StudentC() { }  

        public StudentC(string nom, string prenom, string cin, string cne, string email, int age, string sexe, DateTime date_N, string ville, string telephone, string address, Image image, int filiere, int niveau, int groupe)
        {
            this.id = ++cnt;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.cne = cne;
            this.email = email;
            this.age = age;
            this.sexe = sexe;
            this.date_N = date_N;
            this.ville = ville;
            this.telephone = telephone;
            this.address = address;
            this.image = image;
            this.filiere = filiere;
            this.niveau = niveau;
            this.groupe = groupe;
        }

        public StudentC(int id, string nom, string prenom, string cin, string cne, string email, int age, string sexe, DateTime date_N, string ville, string telephone, string address, Image image, int filiere, int niveau, int groupe)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.cne = cne;
            this.email = email;
            this.age = age;
            this.sexe = sexe;
            this.date_N = date_N;
            this.ville = ville;
            this.telephone = telephone;
            this.address = address;
            this.image = image;
            this.filiere = filiere;
            this.niveau = niveau;
            this.groupe = groupe;
        }
        public StudentC(int id, string nom, string prenom, string cin, string cne, string email, int age, string sexe, DateTime date_N, string ville, string telephone, string address,int filiere, int niveau, int groupe)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.cne = cne;
            this.email = email;
            this.age = age;
            this.sexe = sexe;
            this.date_N = date_N;
            this.ville = ville;
            this.telephone = telephone;
            this.address = address;
            this.filiere = filiere;
            this.niveau = niveau;
            this.groupe = groupe;
        }
        //  DateTime dateNais = dateN.Value.Date;




        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Cin { get => cin; set => cin = value; }
        public string Cne { get => cne; set => cne = value; }
        public string Email { get => email; set => email = value; }
        public int Age { get => age; set => age = value; }
        public string Sexe { get => sexe; set => sexe = value; }
       
        public string Ville { get => ville; set => ville = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Address { get => address; set => address = value; }
        public Image Image { get => image; set => image = value; }
        public int Filiere { get => filiere; set => filiere = value; }
        public int Niveau { get => niveau; set => niveau = value; }
        public int Groupe { get => groupe; set => groupe = value; }
        public DateTime Date_N { get => date_N; set => date_N = value; }
    }
}
