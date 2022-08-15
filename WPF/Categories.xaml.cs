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
            //"SELECT cli.IdClient, Catname, IdCategory from Clients as cli left join LinkCat on Cli.IdClient = LinkCat.IdClient inner join Category on Category.IdCat = LinkCat.IdCategory where cli.IdClient = 6"
            MembreDAO BDAO = new MembreDAO();
            List<string> list = new List<string>();
            list = BDAO.Findcat(numbcli);
            string concats = "";
            foreach (string b in list)
            {
                concats += b.ToString() + "\n";

            }
            CatList.Content = concats;
        }

        private void CatFullList_Initialized(object sender, EventArgs e)
        {
            MembreDAO BDAO = new MembreDAO();
            List<string> list = new List<string>();
            list = BDAO.Findallcat();
            string concats = "";
            foreach (string b in list)
            {
                concats += b.ToString() + "\n";

            }
            CatFullList.Content = concats;
        }

        private void DeleteCat_Click(object sender, RoutedEventArgs e)
        {
            MembreDAO MDAO = new();
            MDAO.delcat(numbcli, int.Parse(DeleteCat.Text));
        }

        private void AddCay_Click(object sender, RoutedEventArgs e)
        {
            MembreDAO MDAO = new();
            MDAO.addcat(numbcli, int.Parse(AddCatNumber.Text));
        }
    }
}
