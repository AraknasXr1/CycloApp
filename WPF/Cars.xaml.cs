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
        {//idcar , idcarclient , CarSeat , CarBike , CarBrand
            Vehicule bl2 = new(idmembre, int.Parse(CarSeat.Text), int.Parse(CarBikeSpace.Text), CarBrand.Text);
            //MessageBox.Show(bl2.ToString() + "\n");
            VehiculeDAO BDAO3 = new VehiculeDAO();
            BDAO3.Create2(idmembre, int.Parse(CarSeat.Text), int.Parse(CarBikeSpace.Text), CarBrand.Text);
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
            Vehicule vl2 = new();
            vl2.Idvoiture = int.Parse(DeleteCarNumber.Text);
            VehiculeDAO VDAO2 = new VehiculeDAO();
            VDAO2.Delete(vl2);
        }

        private void CarList_Initialized(object sender, EventArgs e)
        {
            List<Vehicule> vehiculeliste = new List<Vehicule>();
            VehiculeDAO VDAO = new VehiculeDAO();
            vehiculeliste = VDAO.FindListVehicule(idmembre);
            string concats = "";
            foreach (Vehicule b in vehiculeliste)
            {
                concats += b.ToString() + "\n";

            }
            CarList.Content=concats;
        }
    }
}
