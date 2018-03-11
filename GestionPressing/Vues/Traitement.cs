using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPressing.vues
{
    public partial class Traitement : Form
    {
        //j'instancie ma classe Traitement qui se trouve dans le package Classes
        Classes.Traitement Trait;

        public Traitement()
        {
            InitializeComponent();
            
        }

        //activer le buton ajouter
        private void button1_Click(object sender, EventArgs e)
        {
           
            //Trait = new Classes.Traitement("txtCode.text","txt........");
            Trait = new Classes.Traitement();
           MessageBox.Show( Trait.SuppTraitement());
        }
    }
}
