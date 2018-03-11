using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace GestionPressing.Vues
{
    public partial class Vetement : Form
    {
        public Vetement()
        {
            InitializeComponent();
            Foreign();
           // chargement();
        }
        private string codeType;
        private string descrType;
        private int prixType;
        private MySqlDataAdapter adp;
        private BindingSource bs;
        private DataTable data;
        private MySqlDataReader dr;
        private MySqlCommand Cmd = new MySqlCommand();
        private string Requete;
        private int i;
       private void chargement()
        {
            adp = new MySqlDataAdapter("SELECT * FROM vetement",Program.Con);
            adp.Fill(data);
            adp.FillSchema(data,SchemaType.Source);
            bs.DataSource = data;
            dgvVet.DataSource = bs;
            txtCode.DataBindings.Add("Text",bs, "codeVet");
            txtCode.DataBindings.Add("Text", bs, "couleurVet");
        }
        private void Foreign()
        {
            try
            {

                Requete = "SELECT codeType,descType FROM typevetement order by descType desc;";
                Cmd = new MySqlCommand(Requete, Program.Con);
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboType.Items.Add(dr.GetString(1) + "---" + dr.GetString(0));
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Vetement_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
