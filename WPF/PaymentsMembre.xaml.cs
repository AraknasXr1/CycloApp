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
    /// Logique d'interaction pour Payments.xaml
    /// </summary>
    public partial class PaymentsMembre : Window
    {
        private int numbcli;
        private int vttcheck;
        private int cyclocheck;
        private Boolean vttbool;
        private Boolean cyclobool;
        private int Counter;
        private Membre mbr;
        int wallet = 0;
        public PaymentsMembre(int idcli)
        {
            MembreDAO MDAO = new MembreDAO();
            mbr = MDAO.Find(numbcli);
            wallet = mbr.Solde;
            PayDay.Text = $"{wallet}";
        }
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow(numbcli);
            dashboard.Show();
            this.Close();
        }
    }
}
