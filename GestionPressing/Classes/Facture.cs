using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GestionPressing.Classes
{
    class Facture
    {
        private string numFac;
        private string depos_num;
        private int restMontant;
        private DateTime dateFac;
        private string typeFac;

        private MySqlCommand Cmd;
        private MySqlDataAdapter dr;
        private string Requete;
        private int i;

        public Facture(string numFac,string depos_num,string typeFac,int restMontant,DateTime dateFac)
        {
            this.numFac = numFac;
            this.depos_num = depos_num;
            this.typeFac = typeFac;
            this.restMontant = restMontant;
            this.dateFac = dateFac;
        }
        public Facture()
        {
            this.numFac = "";
            this.depos_num = "";
            this.typeFac = "";
            this.restMontant = 0;
            this.dateFac = DateTime.Today;
        }
        public string TypeFac
        {
            get { return this.typeFac; }
            set { this.typeFac = value; }
        }
        public string NumFac
        {
            get { return this.numFac; }
            set { this.numFac = value; }
        }
        public string Depos_num
        {
            get { return this.depos_num; }
            set { this.depos_num = value; }
        }
        public int RestMontant
        {
            get { return this.restMontant; }
            set { this.restMontant = value; }
        }
        public DateTime DateFac {
            get { return dateFac; }
            set { this.dateFac = value; }
        }
            
    }
}
