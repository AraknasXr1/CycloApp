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
            strRegexNumb = @"[0-9]";
            regexrule = new Regex(strRegexNumb);
            InitializeComponent();
            numbcli = idcli;
        }
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            Payments dashboard = new Payments(numbcli);
            dashboard.Show();
            this.Close();
        }
        private void MembreList_Initialized(object sender, EventArgs e)
        {
            List<Membre> mbrlist = new List<Membre>();
            MembreDAO MDAO = new MembreDAO();
            mbrlist = MDAO.FindListMembre(numbcli, mbrlist);
            string concats = "";
            foreach (Membre m in mbrlist)
            {
                concats += m.ToString() + "\n";
            }
            MembreList.Content = concats.Substring(0, concats.Length - 1);
        }

        private void Reclamer_Click(object sender, RoutedEventArgs e)
        {
            if (!(ReclamerId.Text == String.Empty))
            {
                Match matchreclamer = regexrule.Match(ReclamerId.Text);
                if (matchreclamer.Success)
                {
                    int value = int.Parse(ReclamerId.Text);
                    MembreDAO MDAO = new MembreDAO();
                    Membre mbr = new Membre();
                    mbr=MDAO.Find(value);
                    //mbr.Set.Notification = 1;
                    MessageBox.Show("Réclamation envoyée");
                }
                else
                {
                    MessageBox.Show("Pick a good Id");
                }
            }
        }
    }
}
