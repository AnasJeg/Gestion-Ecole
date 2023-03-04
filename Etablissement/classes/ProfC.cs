using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etablissement.classes
{
    public class ProfC
    {
        private int id;
        private String nom;
        private String prenom;
        private String cin;
        private String email;
        private int age;
        private String sexe;
        private String ville;
        private String telephone;
        private String adresse;
        private Byte[] image;
        private double salaire;
        private int id_filiere;
        private string login;
        private static int cnt = 0;

        public ProfC() { }

        public ProfC(string nom, string prenom, string cin, string email, int age, string sexe, string ville, string telephone, string adresse, byte[] image, double salaire, int id_filiere)
        {
            this.id = ++cnt;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.email = email;
            this.age = age;
            this.sexe = sexe;
            this.ville = ville;
            this.telephone = telephone;
            this.adresse = adresse;
            this.image = image;
            this.salaire = salaire;
            this.id_filiere = id_filiere;
        }

        public ProfC(int id, string nom, string prenom, string cin, string email, int age, string sexe, string ville, string telephone, string adresse, byte[] image, double salaire, int id_filiere)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.email = email;
            this.age = age;
            this.sexe = sexe;
            this.ville = ville;
            this.telephone = telephone;
            this.adresse = adresse;
            this.image = image;
            this.salaire = salaire;
            this.id_filiere = id_filiere;
        }

        public ProfC(string nom, string prenom, string cin, string email, int age, string sexe, string ville, string telephone, string adresse, byte[] image, double salaire, int id_filiere, string login)
        {
            this.id = ++cnt;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.email = email;
            this.age = age;
            this.sexe = sexe;
            this.ville = ville;
            this.telephone = telephone;
            this.adresse = adresse;
            this.image = image;
            this.salaire = salaire;
            this.id_filiere = id_filiere;
            this.login = login;
        }

        public ProfC(int id, string nom, string prenom, string cin, string email, int age, string sexe, string ville, string telephone, string adresse, byte[] image, double salaire, int id_filiere, string login)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.email = email;
            this.age = age;
            this.sexe = sexe;
            this.ville = ville;
            this.telephone = telephone;
            this.adresse = adresse;
            this.image = image;
            this.salaire = salaire;
            this.id_filiere = id_filiere;
            this.login = login;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Cin { get => cin; set => cin = value; }
        public string Email { get => email; set => email = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public string Ville { get => ville; set => ville = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public byte[] Image { get => image; set => image = value; }
        public int Id_filiere { get => id_filiere; set => id_filiere = value; }
        public int Age { get => age; set => age = value; }
        public double Salaire { get => salaire; set => salaire = value; }
        public string Login { get => login; set => login = value; }
    }
}
