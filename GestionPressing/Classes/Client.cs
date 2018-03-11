using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GestionPressing.Classes
{
    class Client
    {
        private string codeCli;
        private string nomCli;
        private string quartierCli;
        private int telCli;
        private DateTime dateCli;

        private MySqlCommand Cmd=new MySqlCommand();
        private MySqlDataAdapter dr;
        private string Requete;
        private int i;

        public Client()
        {
            this.codeCli = "";
            this.nomCli = "";
            this.quartierCli = "";
            this.telCli = 0;
            this.dateCli = DateTime.Today;
        }

        public Client( string codeCli,string nomCli,string quartierCli, int telCli)
        {
            this.codeCli = codeCli;
            this.nomCli = nomCli;
            this.quartierCli = quartierCli;
            this.telCli = telCli;
        }

        public DateTime DateCli
        {
            get { return this.dateCli; }
            set { this.dateCli = value; }
        }
        public string CodeCli {
            get { return this.codeCli; }
            set { this.codeCli = value; }
        }
        public string NomCli
        {
            get { return this.nomCli; }
            set { this.nomCli = value; }
        }
        public string Quartier
        {
            get { return this.quartierCli; }
            set { this.quartierCli = value; }
        }
        public int TelCli
        {
            get { return this.telCli; }
            set { this.telCli = value; }
        }

        public string addClient()
        {
            try {
                Cmd.CommandText= "INSERT INTO client1 VALUES(@code,@nom,@quartier,@tel,@datos);";
                Cmd.Connection = Program.Con;
                Cmd.Parameters.AddWithValue("@code", this.codeCli);
                Cmd.Parameters.AddWithValue("@nom",this.nomCli);
                Cmd.Parameters.AddWithValue("@quartier",this.quartierCli);
                Cmd.Parameters.AddWithValue("@tel",this.telCli);
                Cmd.Parameters.AddWithValue("@datos", DateTime.Today);
                return Convert.ToString(Cmd.ExecuteNonQuery()); ;
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string UpadateClient()
        {
            try
            {
                Cmd.CommandText = "UPDATE client1 SET nomCli=@nom,quartier=@quartier,tel=@tel WHERE codeCli=@code;";
                Cmd.Connection = Program.Con;
                Cmd.Parameters.AddWithValue("@code", this.codeCli);
                Cmd.Parameters.AddWithValue("@nom", this.nomCli);
                Cmd.Parameters.AddWithValue("@quartier", this.quartierCli);
                Cmd.Parameters.AddWithValue("@tel", this.telCli);
                return Convert.ToString(Cmd.ExecuteNonQuery()); ;
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteClient()
        {
            try
            {
                Requete = "DELETE FROM client1 WHERE codeCli=@code";
                Cmd = new MySqlCommand(Requete,Program.Con);
                Cmd.Parameters.AddWithValue("@code", this.codeCli);
                return Convert.ToString(Cmd.ExecuteNonQuery()); ;
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
