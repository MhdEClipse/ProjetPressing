using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GestionPressing.Classes
{
    class Depos
    {
        private string numDep;
        private string clientDep;
        private DateTime dateDep;
        private DateTime dateDispo;

       
        private MySqlCommand Cmd;
        private MySqlDataAdapter dr;
        private string Requete;
        private int i;

        public Depos()
        {
            this.numDep = "";
            this.clientDep = "";
            this.dateDep = DateTime.Today;
            this.dateDispo = dateDep;
        }

        public Depos(string numDep,string clientDep,DateTime dateDep,DateTime datedispo)
        {
            this.numDep = numDep;
            this.clientDep = clientDep;
            this.dateDep = dateDep;
            this.dateDispo = datedispo;
        }

        public string NumDep
        {
            get {return this.numDep; }
            set { this.numDep = value; }
        }
        public string ClientDep
        {
            get { return this.clientDep; }
            set { this.clientDep = value; }
        }
        public DateTime DateDep
        {
            get { return this.dateDep; }
            set { this.dateDep = value; }
        }
        public DateTime DateDispo
        {
            get { return this.dateDispo; }
            set { this.dateDispo = value; }
        }
        public string AddDepos()
        {
            try {
                Requete = "INSERT INTO depos values(@num,@client,@dateJour,@dateRetrait);";
                Cmd = new MySqlCommand(Requete, Program.Con);
                Cmd.Parameters.AddWithValue("@num",NumDep);
                Cmd.Parameters.AddWithValue("@client", ClientDep);
                Cmd.Parameters.AddWithValue("@dateJour", DateDep);
                Cmd.Parameters.AddWithValue("@dateRetrait", dateDispo);
                return Convert.ToString(Cmd.ExecuteNonQuery());
            } catch
            {
                return null;
            }
           
        }

        public string UpdatedDepos()
        {
            try
            {
                Requete = "UPDATE Depos set dateDispo = @dateRetrait WHERE codeDep=@num";
                Cmd = new MySqlCommand(Requete, Program.Con);
                Cmd.Parameters.AddWithValue("@num", NumDep);
                Cmd.Parameters.AddWithValue("@dateRetrait", dateDispo);
                return Convert.ToString(Cmd.ExecuteNonQuery());
            }
            catch
            {
                return null;
            }

        }
      public string DeletedDepos()
        {
            try
            {
                Requete = "DELETE FROM Depos WHERE codeDep=@num";
                Cmd = new MySqlCommand(Requete, Program.Con);
                Cmd.Parameters.AddWithValue("@num", NumDep);
                return Convert.ToString(Cmd.ExecuteNonQuery());
            }
            catch
            {
                return null;
            }

        }
    }
}
