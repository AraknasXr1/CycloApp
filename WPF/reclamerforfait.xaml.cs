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

namespace ProjectCyclistsWPF
{
    /// <summary>
    /// Logique d'interaction pour personalcalendar.xaml
    /// </summary>
    public partial class reclamerforfait : Window
    {
        private int numbcli;
        private bool vttbool;
        private bool cyclobool;
        private int vttcheck;
        private int cyclocheck;
        private String strRegexNumb;
        private Regex regexrule;
        public reclamerforfait(int idcli)
        {

        }
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            Payments dashboard = new Payments(numbcli);
            dashboard.Show();
            this.Close();
        }
    }
}
