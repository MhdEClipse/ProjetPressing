using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GestionPressing.Classes
{
    class Retrait
    {
        private string idRet;
        private string deposRet;
        private DateTime dateRet;

        private MySqlCommand Cmd;
        private MySqlDataAdapter dr;
        private string Requete;
        private int i;

        public Retrait()
        {
            this.idRet = "";
            this.deposRet = "";
            this.dateRet = DateTime.Today;
        }
        public Retrait(string idRet,string deposRet,DateTime dateRet )
        {
            this.idRet = idRet;
            this.deposRet = deposRet;
            this.dateRet = dateRet;
        }
        public string IdRet
        {
            get { return this.idRet; }
            set { this.idRet = value; }
        }
        public string DeposRet
        {
            get { return this.deposRet; }
            set { this.deposRet = value; }
        }
        public DateTime DateRet
        {
            get { return this.dateRet; }
            set { this.dateRet = value; }
        }

        public string AddRetrait()
        {
            try {
                Requete = "INSERT INTO retrait VALUES(@codeRet,@codeDep,@dateJour)";
                Cmd = new MySqlCommand(Requete,Program.Con);
                Cmd.Parameters.AddWithValue("@codeRet", IdRet);
                Cmd.Parameters.AddWithValue("@codeDep", DeposRet);
                Cmd.Parameters.AddWithValue("@dateJour", DateRet);
                return Convert.ToString(Cmd.ExecuteNonQuery());
            } catch {
                return null;
            }
           
        }
        public string UpdateRetrait()
        {
            try
            {
                Requete = "UPDATE retrait set codeDep=@codeDep,dateJourRet=@dateJour WHERE codeRet=@codeRet";
                Cmd = new MySqlCommand(Requete, Program.Con);
                Cmd.Parameters.AddWithValue("@codeRet", IdRet);
                Cmd.Parameters.AddWithValue("@codeDep", DeposRet);
                Cmd.Parameters.AddWithValue("@dateJour", DateRet);
                return Convert.ToString(Cmd.ExecuteNonQuery());
            }
            catch
            {
                return null;
            }

        }

        public string DeleteRetrait()
        {
            try
            {
                Requete = "DELETE FROM retrait  WHERE codeRet=@codeRet";
                Cmd = new MySqlCommand(Requete, Program.Con);
                Cmd.Parameters.AddWithValue("@codeRet", IdRet);
                return Convert.ToString(Cmd.ExecuteNonQuery());
            }
            catch
            {
                return null;
            }

        }
    }
}
