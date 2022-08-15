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
            idresplocal = idresp;
            idclilocal = idcli;
            List<Balade> balist = new List<Balade>();
            BaladeDAO BDAO = new BaladeDAO();
            balist= BDAO.FindListBalade(idcli,balist);
            foreach(Balade b in balist)
            {
                MessageBox.Show(b.ToString());
            }
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

        
    }
}
