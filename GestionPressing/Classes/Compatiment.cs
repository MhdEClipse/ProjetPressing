using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GestionPressing.Classes
{
    class Compatiment
    {
        private string codeComp;
        private Boolean etatComp;
        private int capaciteComp;
        private int capaResteComp;

        private MySqlCommand Cmd;
        private MySqlDataAdapter dr;
        private string Requete;
        private int i;

        public Compatiment()
        {
            this.codeComp = "";
            this.etatComp = true;
            this.capaResteComp = 0;
            this.capaciteComp = 4;
        }

        public Compatiment(string codeComp,Boolean etetaComp,int capaciteResteComp,int capaciteComp)
        {
            this.codeComp = codeComp;
            this.etatComp = etetaComp;
            this.capaResteComp = capaciteResteComp;
            this.capaciteComp = capaciteComp;
        }

        public string CodeComp
        {
            get { return this.codeComp; }
            set { this.codeComp = value; }
        }
        public Boolean EtatComp
        {
            get { return this.etatComp; }
            set { this.etatComp = value; }
        }
        public int CapaciteComp
        {
            get { return this.capaciteComp; }
            set { this.capaciteComp = value; }
        }
        public int CapaciteRestComp
        {
            get { return this.capaResteComp; }
            set { this.capaResteComp = value; }
        }

        public string AddCompatiment()
        {
            try
            {
                Cmd.CommandText = "INSERT INTO compatiment VALUES(@code,@etat,@capa,@rest,@typecapa);";
                Cmd.Connection = Program.Con;
                Cmd.Parameters.AddWithValue("@code", this.codeComp);
                Cmd.Parameters.AddWithValue("@etat", this.etatComp);
                Cmd.Parameters.AddWithValue("@capa", this.capaciteComp);
                Cmd.Parameters.AddWithValue("@rest", this.capaResteComp);
                Cmd.Parameters.AddWithValue("@typecapa", DateTime.Today);
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

        public string ChangeCompatiment()
        {
             try
            {
                Cmd.CommandText = "UPDATE compatiment set etatComp=@etat,capaciteComp=@capa,,@rest,@typecapa WHERE codeComp=@code;";
                Cmd.Connection = Program.Con;
                Cmd.Parameters.AddWithValue("@code", this.codeComp);
                Cmd.Parameters.AddWithValue("@etat", this.etatComp);
                Cmd.Parameters.AddWithValue("@capa", this.capaciteComp);
                Cmd.Parameters.AddWithValue("@rest", this.capaResteComp);
                Cmd.Parameters.AddWithValue("@typecapa", DateTime.Today);
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

        public string DeleteCompatiment()
        {
            try
            {
                Cmd.CommandText = "DELETE FROM codeComp=@code;";
                Cmd.Connection = Program.Con;
                Cmd.Parameters.AddWithValue("@code", this.codeComp);
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
