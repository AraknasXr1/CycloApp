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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        private int numbcli;
        private String ClientName;
        private String LastName;
        private MembreDAO MembreDAOp;
        private TresorierDAO TresorierDAO;
        private ResponsableDAO ResponsableDAO;
        public Membre m;
        private Tresorier Tresorier;
        private Responsable Responsable;
        public MainWindow(int n)
        {
            MembreDAO md = new MembreDAO();
            m=md.Find(n);
            InitializeComponent();
        }

        private void btnCalendarLogin_Click_1(object sender, RoutedEventArgs e)
        {
            Calendar calendarwindow = new Calendar(numbcli);
            calendarwindow.Show();
            this.Close();
        }

        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            Cars carswindow = new Cars(numbcli);
            carswindow.Show();
            this.Close();
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            Payments paymentwindow = new Payments(numbcli);
            paymentwindow.Show();
            this.Close();
        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            Categories categorieswindow = new Categories(numbcli);
            categorieswindow.Show();
            this.Close();
        }

        private void btnUnlog_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginwindow = new LoginScreen();
            loginwindow.Show();
            this.Close();
        }

        private void btnAccountSettings_Click(object sender, RoutedEventArgs e)
        {
            AccountSettings accountwindow = new AccountSettings(numbcli);
            accountwindow.Show();
            this.Close();
        }

        private void WelcomeLabel_Initialized(object sender, EventArgs e)
        {
            WelcomeLabel.Content = $"Welcome {m.nom} {m.prenom}";
        }
    }
}
