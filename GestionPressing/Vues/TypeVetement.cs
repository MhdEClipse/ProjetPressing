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
    public partial class TypeVetement : Form
    {

        private MySqlDataAdapter adp;
        private BindingSource bs;
        private DataTable data;

        private Classes.TypeVetement typeVet;
        private string operation="";
        public TypeVetement()
        {
            InitializeComponent();
            chargement();
            liaison();
        }
        private void liaison()
        {
            try {
                dgvTypeVet.DataSource = bs;
                txtCode.DataBindings.Add("Text", bs, "codeType");
                txtDescription.DataBindings.Add("Text", bs, "descType");
                txtPrix.DataBindings.Add("Text", bs, "prixType");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void vider()
        {
            txtCode.Text = "";
            txtDescription.Text = "";
            txtPrix.Text = "";
            operation = "";
        }

        private void chargement()
        {
            try {
                adp = new MySqlDataAdapter("SELECT * FROM typevetement ", Program.Con);
                data = new DataTable();
                bs = new BindingSource();
                adp.Fill(data);
                adp.FillSchema(data, SchemaType.Source);
                bs = new BindingSource();
                bs.DataSource = data;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TypeVetement_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            operation = "Ajouter";
            bs.AddNew();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            operation = "Modifier";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            operation = "Supprimer";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string result="";
            typeVet = new Classes.TypeVetement(txtCode.Text,txtDescription.Text,Convert.ToInt32(txtPrix.Text));
            switch (operation)
            {
                case "Ajouter":
                   result = typeVet.AddType();
                    break;
                case "Modifier":
                    result = typeVet.UpdateType();
                    break;
                case "Supprimer":
                    result = typeVet.DeleteType();
                    break;
                default:
                    MessageBox.Show("Veuillez selectioner une Opération !!! ");
                    break;
                   
            }

            if (result == "1")
            {
                vider();
                MessageBox.Show("Opération effectuée !!!");
            }

        }
    }
}
