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

        private void Checkcats()
        {
            vttbool = false;
            cyclobool = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
            {
                String queryretrieveinfo = $"SELECT * FROM LinkCat WHERE IdCliCat={numbcli}";
                SqlCommand sqlcmdretrieve = new SqlCommand(queryretrieveinfo, connection);
                connection.Open();
                using (SqlDataReader readclientcat = sqlcmdretrieve.ExecuteReader())
                {
                    while (readclientcat.Read())
                    {
                        if ((vttcheck = readclientcat.GetInt32(2)) == 1)
                        {
                            vttbool = true;
                        }
                        if ((cyclocheck = readclientcat.GetInt32(2)) == 2)
                        {
                            cyclobool = true;
                        }
                    }
                }
                connection.Close();
            }
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
            if (isValid())
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
        }

        private bool isValid()
        {
            Boolean tester;
            tester= false;

            if (AddCar.Text == String.Empty)
            {
                MessageBox.Show("Please enter an ID");
            }
            else
            {
                Match match = regexrule.Match(AddCar.Text);
                if (match.Success)
                {
                    if (Addid.Text == String.Empty)
                    {
                            MessageBox.Show("Please enter an ID");
                    }
                    else
                    {
                        Match match2 = regexrule.Match(Addid.Text);
                        if (match2.Success)
                        {
                            tester = true;
                        }
                        else
                            MessageBox.Show("Number between 0-9 only");
                    }
                }
                else
                {
                    MessageBox.Show("Number between 0-9 only");
                }
                
            }
            if(tester)
            {
                return true;
            }
            else
                return false;

        }
    }

    
}
