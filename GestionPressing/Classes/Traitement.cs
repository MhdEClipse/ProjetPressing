using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GestionPressing.Classes
{
    class Traitement
    {
        //variable pour communication avec la base de donnees
        MySqlConnection Con = new MySqlConnection();
        MySqlCommand Cmd = new MySqlCommand();
        string Requete = "";

        //declaration des propriétes(variables) de classes
        private string codeTrait;
        private string typeLav;
        private DateTime dateTrait;
        private string typeTrait;
        private string traiteur;
        private string vetemt;

        //creation des constructeurs
        public Traitement() {
            //initialialisation des proprétés de classes
            this.codeTrait = "";
            this.typeLav="";
            this.dateTrait = DateTime.Now;
            this.typeTrait = "";
            this.traiteur = "";
            this.vetemt = "";

        }

        //private void mmm() {
        //    CodeTrait = "valeur";
        //}
        //surgarger le constructeur
        public Traitement( string code, string typeL, string typeT, string vet, string traiter, DateTime datos) {
            this.codeTrait = code;
            this.dateTrait = datos;
            this.typeLav = typeL;
            this.vetemt = vet;
            this.traiteur = traiter;
           
        }
            
        public string CodeTrait
        {
            get { return this.codeTrait; }
            set { this.codeTrait = value; }
        }
       public string TypeLav
        {
            get { return this.typeLav; }
            set { this.typeLav = value; }
        }
        public string TypeTrait
        {
            get { return this.typeTrait; }
            set { this.typeTrait = value; }
        }
        public string Vetemt
        {
            get { return this.vetemt; }
            set { this.vetemt = value; }
        }
        public string Traiteur
        {
            get { return this.traiteur; }
            set { this.traiteur = value; }
        }
        public DateTime DateTrait
        {
            get { return this.dateTrait; }
            set { this.dateTrait = value; }
        }


        public int AddTraitement() {
            int  rep = 0;
            try {
                Requete = "INSERT INTO traitement VALUES(@code, @typetraitement,@datos,@vetem,@traiteur1,@typlave..........);";
                Cmd.CommandText = Requete;
                Cmd.Connection = Con;
                Cmd.Parameters.AddWithValue("@code", this.codeTrait);
                Cmd.Parameters.AddWithValue("@typetraitement", this.typeTrait);
                Cmd.Parameters.AddWithValue("@datos", this.dateTrait);
                Cmd.Parameters.AddWithValue("@vetem", this.Vetemt);
                Cmd.Parameters.AddWithValue("@traiteur1", this.Vetemt);
                Cmd.Parameters.AddWithValue("@vetem", this.Vetemt);

                //...........
                rep = Convert.ToInt16(Cmd.ExecuteNonQuery());
            } catch { }
            return rep;
        }

        public string SuppTraitement()
        {
            return " MHD";
        }
       

    }
}
