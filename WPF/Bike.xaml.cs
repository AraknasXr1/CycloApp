using Microsoft.VisualBasic;
using ProjectCyclistsWPF;
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

namespace CycloApp.WPF
{
    /// <summary>
    /// Logique d'interaction pour Bike.xaml
    /// </summary>
    public partial class Bike : Window
    {
        private int idmembre;
        public Bike(int idmemb)
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

        private void AddBike_Click(object sender, RoutedEventArgs e)
        {
            Velo bl2 = new(idmembre, BikeType.Text, int.Parse(BikeWeight.Text), int.Parse(BikeLength.Text));
            //MessageBox.Show(bl2.ToString() + "\n");
            VeloDAO BDAO3 = new VeloDAO();
            BDAO3.Create2(idmembre, int.Parse(BikeWeight.Text), BikeType.Text, int.Parse(BikeLength.Text));
        }

        private void DeleteBike_Click(object sender, RoutedEventArgs e)
        {
            Velo vl2 = new();
            vl2.Id = int.Parse(DeleteBikeNumber.Text);
            VeloDAO VDAO2 = new VeloDAO();
            VDAO2.Delete(vl2);
        }

        private void BikeList_Initialized(object sender, EventArgs e)
        {
            List<Velo> veloliste = new List<Velo>();
            VeloDAO VDAO = new VeloDAO();
            veloliste = VDAO.FindListVelo(idmembre);
            string concats = "";
            foreach (Velo b in veloliste)
            {
                concats += b.ToString() + "\n";

            }
            BikeList.Content = concats;
        }
    }
}
