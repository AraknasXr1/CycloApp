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
        private Tresorier t;
        private Responsable r;
        private int flag = 0;
        public MainWindow(int n)
        {
            //flag = 0 (membre simple) , flag = 1 (tresorier) , flag = 2 (responsable)
            MembreDAO md = new MembreDAO();
            TresorierDAO tre = new TresorierDAO();
            ResponsableDAO resp = new ResponsableDAO();
            m=md.Find(n);
            t= tre.Find(n);
            r= resp.Find(n);
            if(t.id>0)
            {
                //tresorier
                flag = 1;
            }
            if(r.id>0)
            {
                //responsable
                flag = 2;
            }
            InitializeComponent();
            if(flag==2)
            {
                btnPayment.Visibility = Visibility.Collapsed;
                notmember();
            }
            if(flag==1)
            {
                btnCalendar.Visibility = Visibility.Collapsed;
                notmember();
            }
            
        }
        private void notmember()
        {
            btnCars.Visibility = Visibility.Collapsed;
            btnCategories.Visibility = Visibility.Collapsed;
            btnAccountSettings.Visibility = Visibility.Collapsed;
        }
        private void btnCalendarLogin_Click_1(object sender, RoutedEventArgs e)
        {
            Calendar calendarwindow = new Calendar(m.id);
            calendarwindow.Show();
            this.Close();
        }

        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            Cars carswindow = new Cars(m.id);
            carswindow.Show();
            this.Close();
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            Payments paymentwindow = new Payments(m.id);
            paymentwindow.Show();
            this.Close();
        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            Categories categorieswindow = new Categories(m.id);
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
            AccountSettings accountwindow = new AccountSettings(m.id);
            accountwindow.Show();
            this.Close();
        }

        private void WelcomeLabel_Initialized(object sender, EventArgs e)
        {
            string title="";
            if(flag==1)
            {
                title="Tresorier";
            }
            if(flag==2)
            {
                title = "Responsable";
            }
            if(flag==0)
            {
                title = "Welcome";
            }
            WelcomeLabel.Content = $"{title} {m.nom} {m.prenom}";
        }
    }
}
