using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GestionPressing.Classes
{
    class Reglement
    {
        private string numReg;
        private string typeReg;
        private string numFac;
        private int montant;
        private DateTime dateReg;

        private MySqlCommand Cmd;
        private MySqlDataAdapter dr;
        private string Requete;
        private int i;

        public Reglement(){
            this.numReg = "";
            this.numFac = "";
            this.typeReg = "";
            this.montant = 0;
            this.dateReg = DateTime.Today;
        }
        public Reglement(string numReg,string typeReg,int montant, DateTime dateReg,string numFac)
        {
            this.numReg = numReg;
            this.numFac = numFac;
            this.typeReg = typeReg;
            this.montant = montant;
            this.dateReg = DateTime.Today;
        }
        public string NumRge
        {
            get { return this.numReg; }
            set { this.numReg = value; }
        }
        public string TypeReg
        {
            get { return this.numReg; }
            set { this.numReg = value; }
        }
        public string NumFac
        {
            get { return this.numFac; }
            set { this.numFac = value; }
        }
        public int Montant
        {
            get { return this.montant; }
            set { this.montant = value; }
        }
        public DateTime DateReg
        {
            get { return this.dateReg; }
            set { this.dateReg = value; }
        }
    }
}
