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
    /// Logique d'interaction pour Cars.xaml
    /// </summary>
    public partial class Cars : Window
    {
        private int idmembre;
        private String strRegexNumb;
        private Regex regexrule;
        public Cars(int idmemb)
        {
            idmembre = idmemb;
            InitializeComponent();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow(idmembre);
            dashboard.Show();
            this.Close();
        }
        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (isValid())
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
                {
                    String insertcar = $"INSERT INTO Car(IdCarClient,CarSeat,CarBike,CarBrand) VALUES ({numbcli},@seats,@bikes,@brand)";
                    SqlCommand sqlinsert = new SqlCommand(insertcar, connection);
                    sqlinsert.CommandType = CommandType.Text;
                    sqlinsert.Parameters.AddWithValue("@seats", CarSeat.Text);
                    sqlinsert.Parameters.AddWithValue("@bikes", CarBikeSpace.Text);
                    sqlinsert.Parameters.AddWithValue("@brand", CarBrand.Text);
                    connection.Open();
                    sqlinsert.ExecuteNonQuery();
                    connection.Close();
                    binddatagrid();
                }
            }*/
        }


        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CarList_Initialized(object sender, EventArgs e)
        {

        }
    }
}
