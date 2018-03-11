using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPressing.Vues
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public int i = 3;
        private void button7_Click(object sender, EventArgs e)
        {
            if(txtLogin.Text=="Admin" && txtPass.Text == "Admin")
            {
                i = 3;
                new Form1().Show();
            }
            else
            {
                i--;
                if (i != 0)
                {
                    MessageBox.Show("Parammetre de Connexion Incorrect, il vous reste " + i + " Essais");
                }
                else
                {
                    this.Close();
                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
