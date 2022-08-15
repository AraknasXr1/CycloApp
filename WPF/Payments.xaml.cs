﻿using System;
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

namespace ProjectCyclistsWPF
{
    /// <summary>
    /// Logique d'interaction pour Payments.xaml
    /// </summary>
    public partial class Payments : Window
    {
        private int numbcli;
        private int vttcheck;
        private int cyclocheck;
        private Boolean vttbool;
        private Boolean cyclobool;
        private int Counter;
        public Payments(int idcli)
        {
            numbcli = idcli;
            InitializeComponent();
        }
        private void ReclamerForfait_click(object sender, RoutedEventArgs e)
        {
            /*reclamerforfait reclamerforfait = new ReclamerForfait(numbcli);
            ReclamerForfait.Show();
            this.Close();*/
        }

        private void PayerConducteur_click(object sender, RoutedEventArgs e)
        {
            /*PayerConducteur PayerConducteur = new PayerConducteur(numbcli);
            PayerConducteur.Show();
            this.Close();*/
        }

        private void Rappel_click(object sender, RoutedEventArgs e)
        {
            /*Rappel Rappel = new Rappel(numbcli);
            rappel.Show();
            this.Close();*/
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow(numbcli);
            dashboard.Show();
            this.Close();
        }
    }
}
