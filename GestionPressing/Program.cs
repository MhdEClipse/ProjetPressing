using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace GestionPressing
{
    static class Program
    {
        public static string Chaine = "database=GestionPressing;datasource=localhost;userid=root;password=";
        public static MySqlConnection Con=new MySqlConnection(Chaine);

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                Con.Open();
            Application.Run(new Vues.Login());
        }
    }
}
