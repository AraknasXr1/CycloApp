using System;
using System.Collections.Generic;
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

namespace ProjectCyclistsWPF
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Calendar : Window
    {
        public int idresplocal = 0;
        private int numbcli;
        public Calendar(int idcli)
        {
            numbcli = idcli;
            InitializeComponent();
        }

        public Calendar(int idresp,Membre m)
        {
            idresplocal = idresp;
            numbcli = m.id;
            InitializeComponent();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow(numbcli);
            dashboard.Show();
            this.Close();
        }

        private void seePersonalCalendar_Click(object sender, RoutedEventArgs e)
        {
            if(idresplocal>0)
            {
                MessageBox.Show("Button Disabled for Responsables");
            }
            else
            {
                personalcalendar personalcalendar = new personalcalendar(numbcli);
                personalcalendar.Show();
                this.Close();
            }
            
        }

        private void seeGlobalCalendar_Click(object sender, RoutedEventArgs e)
        {
            globalcalendar globalcalendar = new globalcalendar(numbcli);
            globalcalendar.Show();
            this.Close();
        }
    }
}
