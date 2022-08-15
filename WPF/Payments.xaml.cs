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
    public partial class Payments : Window
    {
        private int numbcli;
        private int vttcheck;
        private int cyclocheck;
        private Boolean vttbool;
        private Boolean cyclobool;
        private int Counter;
        public Payments(int idcli)
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

        private void envoyerrappel_Click(object sender, RoutedEventArgs e)
        {
            rappel rappel = new rappel(numbcli);
            rappel.Show();
            this.Close();
        }

        private void payerconducteur_Click_1(object sender, RoutedEventArgs e)
        {
            payerconducteur payerconducteur = new payerconducteur(numbcli);
            payerconducteur.Show();
            this.Close();
        }

        private void reclamerforfait_Click_1(object sender, RoutedEventArgs e)
        {
            reclamerforfait reclamerforfait = new reclamerforfait(numbcli);
            reclamerforfait.Show();
            this.Close();
        }
    }
}
