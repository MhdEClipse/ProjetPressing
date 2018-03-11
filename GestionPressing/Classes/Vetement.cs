using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GestionPressing.Classes
{
    class Vetement
    {
        private string idVet;
        private string etatVet;
        private string couleurVet;
        private string deposVet;
        private int compatimentVet;
        private MySqlCommand Cmd;
        private MySqlDataAdapter dr;
        private string Requete;
        private int i;
        // private string traitementVet;
        private string employeVet;

        public Vetement( string idVet,string etatVet,string deposVet,string couleurVet,int compatimentVet,string traitementVet,string employeVet)
        {
            this.idVet = idVet;
            this.etatVet =etatVet;
            this.deposVet = deposVet;
            this.couleurVet = couleurVet;
            this.compatimentVet = compatimentVet;
          //  this.traitementVet =traitementVet;
            this.employeVet = employeVet;
        }
        public Vetement()
        {
            this.idVet = "";
            this.etatVet = "";
            this.couleurVet = "";
            this.deposVet = "";
            this.compatimentVet = 1;
           // this.traitementVet = "";
            this.employeVet = "";
        }
        public string CouleurVet
        {
            get { return this.couleurVet; }
            set { this.couleurVet = value; }
        }
        public string IDVet {
            get {return this.idVet; }
            set {this.idVet= value; }
        }
        public string EtatDVet
        {
            get { return this.etatVet; }
            set { this.etatVet= value; }
        }
        public string DeposDVet
        {
            get { return this.deposVet; }
            set { this.deposVet= value; }
        }
        public int CompatimentDVet
        {
            get { return this.compatimentVet; }
            set { this.compatimentVet= value; }
        }
       /* public string TraitementDVet
        {
            get { return this.traitementVet; }
            set { this.traitementVet= value; }
        }*/
        public string EmployeDVet
        {
            get { return this.employeVet; }
            set { this.employeVet= value; }
        }
    }
}
