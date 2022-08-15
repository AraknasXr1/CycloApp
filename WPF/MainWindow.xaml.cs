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
using CycloApp.WPF;

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
            btnBike.Visibility = Visibility.Collapsed;
            btnCars.Visibility = Visibility.Collapsed;
            btnCategories.Visibility = Visibility.Collapsed;
            btnAccountSettings.Visibility = Visibility.Collapsed;
        }
        private void btnCalendarLogin_Click_1(object sender, RoutedEventArgs e)
        {
            //envoyer l'objet et l'id du responsable
            //si il est un responsable on envois l'objet complet et l'id 
            //sinon on ouvre juste avec l'id
            if(flag==2)
                {
                //lorsq'uil est responsable on prends l'id du membre et l'id de sa responsabilité
                respcalendar respcalendar = new respcalendar(t.id,m.id);
                respcalendar.Show();
                this.Close();
            }
            else
            {
                //c'est un membre simple si le flag est different de 2 (pas d'acces pour le tresorier)
                Calendar calendarwindow = new Calendar(m.id);
                calendarwindow.Show();
                this.Close();

            }
            
        }


        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            Cars carswindow = new Cars(m.id);
            carswindow.Show();
            this.Close();
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            if (flag == 1)
            {
                //lorsq'uil est responsable on prends l'id du membre et l'id du tresorier
                Payments paymentwindow = new Payments(m.id);
                paymentwindow.Show();
                this.Close();
            }
            else
            {
                //c'est un membre simple si le flag est 1(acces pour le tresorier)
                PaymentsMembre paymentwindow = new PaymentsMembre(m.id);
                paymentwindow.Show();
                this.Close();
            }

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
                int notif = m.Notification;
                if(notif==1)
                {
                    MessageBox.Show("Attention ! Le trésorier a réclamé ton forfait !");
                    MembreDAO MDAO = new MembreDAO();
                    Membre mbr = new Membre();
                    //mbr = MDAO.Find(m);
                    //mbr.Set.Notification = 0;
                }
                else if (notif == 2)
                {
                    MessageBox.Show("RAPPEL ! Le trésorier a réclamé ton forfait !");
                    MembreDAO MDAO = new MembreDAO();
                    Membre mbr = new Membre();
                    //mbr = MDAO.Find(m);
                    //mbr.Set.Notification = 0;
                }
                else
                {
                    MessageBox.Show("En ordre de paiement");
                }
                title = "Welcome";
            }
            WelcomeLabel.Content = $"{title} {m.nom} {m.prenom}";
        }

        private void btnBike_Click(object sender, RoutedEventArgs e)
        {
            Bike bike = new(m.id);
            bike.Show();
            this.Close();
        }
    }
}
