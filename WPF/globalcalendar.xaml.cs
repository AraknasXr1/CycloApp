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
    /// Logique d'interaction pour globalcalendar.xaml
    /// </summary>
    public partial class globalcalendar : Window
    {
        private int numbcli;
        private bool vttbool;
        private bool cyclobool;
        private int vttcheck;
        private int cyclocheck;
        private String strRegexNumb;
        private Regex regexrule;
        public globalcalendar(int idcli)
        {
            numbcli = idcli;
            strRegexNumb = @"[0-9]";
            regexrule = new Regex(strRegexNumb);
            InitializeComponent();
        }



        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            Calendar dashboard = new Calendar(numbcli);
            dashboard.Show();
            this.Close();
        }



        //select * from Ride left join Category on Ride.IdCatRide = Category.IdCat inner join LinkCat on LinkCat.IdCategory = Category.IdCat where IdClient = @idclient


        private void AddPersonalRide_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
            {
                String insert = $"INSERT INTO LinkRide(IdCliRide,IdRide) VALUES ({numbcli},@idRide)";
                SqlCommand sqlinsert = new SqlCommand(insert, connection);
                connection.Open();
                sqlinsert.Parameters.AddWithValue("@idRide", AddPersonalRideId.Text);
                sqlinsert.ExecuteNonQuery();
                MessageBox.Show("The Ride was added");
                connection.Close();
            }
        }

        private void RideList_Initialized(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            BaladeDAO BDAO = new BaladeDAO();
            list = BDAO.FindSpecificBaladeList(numbcli);
            string concats = "";
            foreach (string b in list)
            {
                concats += b+ "\n";

            }
            RideList.Content = concats;
        }
    }
}
