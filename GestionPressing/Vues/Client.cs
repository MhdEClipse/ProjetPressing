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
    public partial class Client : Form
    {
        public static string CodeDepos="";
        private Classes.Client client;
        private Classes.Depos depos;
        private Classes.Retrait retrait;

        private MySqlDataAdapter adp,adpdepos;
        private BindingSource bs,bsDepos;
        private DataTable data,data1;

        private string operationcli = "";
        public Client()
        {
            InitializeComponent();
            radioConsulter.Checked = true;
            chargement();
            lienDate();
        }

        private void lienDate()
        {
            //liaison du dgv  a notre formulaire
            try {
                dgvClient.DataSource = bs;

                dgvDepos.DataSource = bsDepos;
                txtnumDep.DataBindings.Add("Text",bsDepos, "codeDep");

                txtCode.DataBindings.Add("Text", bs,"codeCli");
                txtNom.DataBindings.Add("Text", bs, "nomCli");
                txtQuartier.DataBindings.Add("Text", bs, "quartier");
                txtTel.DataBindings.Add("Text", bs, "tel");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void viderClient()
        {
            //vider les hamps du formulaire client
            txtCode.Text = "";
            txtNom.Text = "";
            txtTel.Text = "";
            txtQuartier.Text = "";
            sazie();

        }

        private void chargement()
        {

            //chargement du datagridview du client
            try
            {
                data = new DataTable();
                data1 = new DataTable();

                adp = new MySqlDataAdapter("SELECT * FROM client1",Program.Con);
                adpdepos = new MySqlDataAdapter("SELECT * FROM depos order by dateJourDep desc", Program.Con);

                adp.Fill(data);
                adpdepos.Fill(data1);

                adpdepos.FillSchema(data1,SchemaType.Source);
                adp.FillSchema(data, SchemaType.Source);

                bs = new BindingSource();
                bsDepos = new BindingSource();
                bsDepos.DataSource = data1;
                bs.DataSource = data;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {
            txtCode.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            //enregistrer, modifier, ou supprimer un client
            string a = "";
            try {
                client = new Classes.Client(txtCode.Text, txtNom.Text, txtQuartier.Text, Convert.ToInt32(txtTel.Text));
                switch (operationcli)
                {
                    case "Ajouter":
                      a= client.addClient();
                        break;
                    case "Modifier":
                       a = client.UpadateClient();
                        break;
                    case "Supprimer":
                        a = client.DeleteClient();
                        break;
                    default:
                        MessageBox.Show("Veuillez Selectionner une Opération !!!");
                        break;
                }

                if (a== "1")
                {
                    viderClient();
                    MessageBox.Show("Opérqtion effectuée !!!");
                }else
                {
                    MessageBox.Show(a);
                }
                
               
            } catch(Exception ex)
            {
                MessageBox.Show("Erreur: "+ex.Message);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {

            //enregistrer un depos
            try
            {
                if (radioDepos.Checked ==true && txtCode.Text != "")
                {
                    depos = new Classes.Depos(txtnumDep.Text, txtCode.Text, Convert.ToDateTime(dtpJoure.Value), Convert.ToDateTime(dtpRetrait.Value));
                    if (depos.AddDepos() == "1")
                    {
                        CodeDepos = txtnumDep.Text;
                        txtnumDep.Text = "";
                        new Vetement().Show();
                    }
                }else
                {
                    MessageBox.Show(" Veuillez Cochez le bouton new Depos !!!");
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Erreur:"+ ex.Message) ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCode.Enabled = true;
            bs.AddNew();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //desactivation du champs de texte du code de client et ......
            txtCode.Enabled = true;
            btModifier.Enabled = false;
            btSuppromer.Enabled = false;
            operationcli = "Ajouter";
            bs.AddNew();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtCode.Enabled = false;
            btAjouter.Enabled = false;
            btSuppromer.Enabled = false;
            operationcli = "Modifier";
        }
        private void sazie()
        {
            operationcli = "";
            btModifier.Enabled = true;
            btAjouter.Enabled = true;
            btSuppromer.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            txtCode.Enabled = true;
            btAjouter.Enabled = false;
            btModifier.Enabled = false;
            operationcli = "Supprimer";
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
             //update depos
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            viderClient();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //enregistrer un retrait
            try
            {
                if (radioRetrait.Checked && txtCode.Text != "")
                {
                    retrait = new Classes.Retrait(txtCodeRet.Text, txtnumDep.Text, Convert.ToDateTime(dtpJourRet.Value));
                    if (retrait.AddRetrait() == "1")
                    {
                        txtCodeRet.Text = "";
                        MessageBox.Show("Opérqtion effectuée !!!");
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Erreur: "+ex.Message);
            }
        }

        private void dtpJourRet_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Vetement().Show();
        }
    }
}
