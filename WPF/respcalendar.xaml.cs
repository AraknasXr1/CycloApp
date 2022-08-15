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
using System.Text.RegularExpressions;
using ProjectCyclistsWPF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjectCyclistsWPF
{
    /// <summary>
    /// Logique d'interaction pour globalcalendar.xaml
    /// </summary>
    public partial class respcalendar : Window
    {
        private int idresplocal;
        private int idclilocal;
        private Responsable resp; 
        private bool vttbool;
        private bool cyclobool;
        private int vttcheck;
        private int cyclocheck;
        private String strRegexNumb;
        private Regex regexrule;
        public respcalendar(int idresp, int idcli)
        {
            strRegexNumb = @"[0-9]";
            regexrule = new Regex(strRegexNumb);
            idresplocal = idresp;
            idclilocal = idcli;
            InitializeComponent();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow(idclilocal);
            dashboard.Show();
            this.Close();
        }

        private void WelcomeLabel_Initialized(object sender, EventArgs e)
        {
            ResponsableDAO RDAO = new ResponsableDAO();
            resp = RDAO.Findnamecat(idclilocal);
            WelcomeLabel.Content = $"Responsable for : {resp.nom}";
        }

        private void RideList_Initialized(object sender, EventArgs e)
        {
            List<Balade> balist = new List<Balade>();
            BaladeDAO BDAO = new BaladeDAO();
            balist = BDAO.FindListBalade(idclilocal, balist);
            string concats="";
            foreach (Balade b in balist)
            {
                concats += b.ToString() + "\n";

            }
            RideList.Content = concats.Substring(0,concats.Length-1);
        }

        private void RideDel_Click(object sender, RoutedEventArgs e)
        {
            if (!(DeleteRideId.Text == String.Empty))
            {
                Match matchdelete = regexrule.Match(DeleteRideId.Text);
                if (matchdelete.Success)
                {
                    Balade bl2 = new();
                    bl2.Num = int.Parse(DeleteRideId.Text);
                    BaladeDAO BDAO2 = new BaladeDAO();
                    BDAO2.Delete(bl2);
                }
                else
                {
                    MessageBox.Show("Pick a good Id");
                }
            }
        }

        private void AddRide_Click(object sender, RoutedEventArgs e)
        {
            if (isValid())
            {
                Balade bl2 = new(idclilocal, DepPlace.Text, DepDate.Text,int.Parse(RidePrices.Text), int.Parse(MaxClient.Text));
                MessageBox.Show(bl2.ToString() + "\n");
                BaladeDAO BDAO3 = new BaladeDAO();
                BDAO3.Create2(idclilocal, int.Parse(MaxClient.Text), int.Parse(RidePrices.Text), DepDate.Text, DepPlace.Text);
            }
        }

        private bool isValid()
        {
            Boolean tester;
            tester = false;

            if (DepPlace.Text == String.Empty)
            {
                MessageBox.Show("Please enter a Departure Place");
            }
            else
            {
                if (DepDate.Text == String.Empty)
                {
                    MessageBox.Show("Please enter a Departure Date");
                }
                else
                {

                    if (RidePrices.Text == String.Empty)
                    {
                        MessageBox.Show("Please enter the number of the Ride Category, even if it's 0");
                    }
                        else
                        {
                                tester = true;
                        }
                       
                    }
                }
            if (tester)
            {
                return true;
            }
            else
                return false;

        }
    }
}
