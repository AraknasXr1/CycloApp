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
    public partial class personalcalendar : Window
    {
        private int numbcli;
        private bool vttbool;
        private bool cyclobool;
        private int vttcheck;
        private int cyclocheck;
        private String strRegexNumb;
        private Regex regexrule;
        public personalcalendar(int idcli)
        {
            strRegexNumb = @"[0-9]";
            numbcli = idcli;
            regexrule = new Regex(strRegexNumb);
            InitializeComponent();

        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            Calendar dashboard = new Calendar(numbcli);
            dashboard.Show();
            this.Close();
        }

        private void DeleteRide_Click(object sender, RoutedEventArgs e)
        {
            if (!(DeleteRideNumber.Text == String.Empty))
            {
                Match matchdelete = regexrule.Match(DeleteRideNumber.Text);
                if (matchdelete.Success)
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
                    {
                        String deleteride = $"DELETE FROM LinkRide WHERE IdCliRide={numbcli} AND IdRide=@idride";
                        SqlCommand sqldelete = new SqlCommand(deleteride, connection);
                        connection.Open();
                        sqldelete.Parameters.AddWithValue("@idride", DeleteRideNumber.Text);
                        sqldelete.ExecuteNonQuery();
                        MessageBox.Show("Deleted your Ride with id number " + DeleteRideNumber.Text);
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Pick a good Id");
                }
            }
        }

        private void AddCarBtn_Click(object sender, RoutedEventArgs e)
        {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
                {
                    String insertcar = $"INSERT INTO LinkCarToRide(IdCar,IdLinkRide) VALUES (@linkCar,@linkride)";
                    SqlCommand sqlinsert = new SqlCommand(insertcar, connection);
                    sqlinsert.CommandType = CommandType.Text;
                    sqlinsert.Parameters.AddWithValue("@linkcar", AddCar.Text);
                    sqlinsert.Parameters.AddWithValue("@linkride", Addid.Text);
                    connection.Open();
                    sqlinsert.ExecuteNonQuery();
                    MessageBox.Show("Car added to the ride");
                    connection.Close();
                }
        }


        private void RideList_Initialized(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            BaladeDAO BDAO = new BaladeDAO();
            list = BDAO.FindListByCatAndIdMember(numbcli);
            string concats = "";
            foreach (string b in list)
            {
                concats += b + "\n";

            }
            RideList.Content = concats;
        }

        private void CarList_Initialized(object sender, EventArgs e)
        {
            List<Vehicule> vehiculeliste = new List<Vehicule>();
            VehiculeDAO VDAO = new VehiculeDAO();
            vehiculeliste = VDAO.FindListVehicule(numbcli);
            string concats = "";
            foreach (Vehicule b in vehiculeliste)
            {
                concats += b.ToString() + "\n";

            }
            CarList.Content = concats;
        }

        private void BikeList_Initialized(object sender, EventArgs e)
        {
            List<Velo> veloliste = new List<Velo>();
            VeloDAO VDAO = new VeloDAO();
            veloliste = VDAO.FindListVelo(numbcli);
            string concats = "";
            foreach (Velo b in veloliste)
            {
                concats += b.ToString() + "\n";

            }
            BikeList.Content = concats;
        }

        private void AddBikebtn_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
            {
                String insertcar = $"INSERT INTO LinkVeloInscr(idvelo,idinscr) VALUES (@linkBike,@linkride)";
                SqlCommand sqlinsert = new SqlCommand(insertcar, connection);
                sqlinsert.CommandType = CommandType.Text;
                sqlinsert.Parameters.AddWithValue("@linkBike", AddBike.Text);
                sqlinsert.Parameters.AddWithValue("@linkride", AddbikeId.Text);
                connection.Open();
                sqlinsert.ExecuteNonQuery();
                MessageBox.Show("Bike added to the ride");
                connection.Close();
            }
        }
    }

    
}
