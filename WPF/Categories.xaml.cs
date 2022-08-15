using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Collections.Specialized;

namespace ProjectCyclistsWPF
{
    /// <summary>
    /// Logique d'interaction pour Categories.xaml
    /// </summary>
    public partial class Categories : Window
    {
        private int numbcli;
        private int vttcheck;
        private int cyclocheck;
        private int CatCount;
        private Boolean vttbool;
        private Boolean cyclobool;
        public Categories(int idcli)
        {
            numbcli = idcli;
            InitializeComponent();
        }
        

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {

                MainWindow dashboard = new MainWindow(numbcli);
                dashboard.Show();
                this.Close();
            
        }

        private void CatList_Initialized(object sender, EventArgs e)
        {
            List<Balade> balist = new List<Balade>();
            BaladeDAO BDAO = new BaladeDAO();
            balist = BDAO.FindListBalade(idclilocal, balist);
            string concats = "";
            foreach (Balade b in balist)
            {
                concats += b.ToString() + "\n";

            }
            CatList.Content = concats.Substring(0, concats.Length - 1);
        }
    }
}
