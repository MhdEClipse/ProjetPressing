using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GestionPressing.Classes
{
    class TypeVetement
    {
        private string codeType;
        private string descrType;
        private int prixType;

        private MySqlCommand Cmd = new MySqlCommand();
        private MySqlDataAdapter dr;
        private string Requete;
        private int i;

        public TypeVetement()
        {
            this.codeType = "";
            this.descrType = "";
            this.prixType = 0;
        }
        public TypeVetement(string codeType,string description,int prix)
        {
            this.codeType = codeType;
            this.descrType = description;
            this.prixType = prix;
        }

        public string CodeType
        {
            get { return this.codeType; }
            set { this.codeType = value; }
        }
        public string DescType
        {
            get { return this.descrType; }
            set { this.descrType = value; }
        }
        public int PrixType
        {
            get { return this.prixType; }
            set { this.prixType = value; }
        }
        public string AddType()
        {
            try {
                Requete = "INSERT INTO typevetement VALUES(@code,@desc,@prix)";
                Cmd = new MySqlCommand(Requete,Program.Con);
                Cmd.Parameters.AddWithValue("@code", this.CodeType);
                Cmd.Parameters.AddWithValue("@desc", this.DescType);
                Cmd.Parameters.AddWithValue("@prix", this.PrixType);
                return Convert.ToString(Cmd.ExecuteNonQuery());
            } catch(MySqlException ex) {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateType()
        {
            try
            {
                Requete = "UPDATE typevetement set descType=@desc,prixType =@prix WHERE codeType=@code";
                Cmd = new MySqlCommand(Requete, Program.Con);
                Cmd.Parameters.AddWithValue("@code", this.CodeType);
                Cmd.Parameters.AddWithValue("@desc", this.DescType);
                Cmd.Parameters.AddWithValue("@prix", this.PrixType);
                return Convert.ToString(Cmd.ExecuteNonQuery());
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
        public string DeleteType()
        {
            try
            {
                Requete = "DELETE FROM typevetement  WHERE codeType=@code";
                Cmd = new MySqlCommand(Requete, Program.Con);
                Cmd.Parameters.AddWithValue("@code", this.CodeType);
                return Convert.ToString(Cmd.ExecuteNonQuery());
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
