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

namespace ProjectCyclistsWPF
{
    /// <summary>
    /// Logique d'interaction pour LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private string login="";
        private string password="";
        private int idclient;
        
        public LoginScreen()
        {
            InitializeComponent();
        }
        
        private void btnSubmitLogin_Click(object sender, RoutedEventArgs e)
        {
            MembreDAO membreDAO = new MembreDAO();
            login =txtUsername.Text;
            password = txtPassword.Password;
            if(login.Equals("") | password.Equals(""))
            {
                MessageBox.Show("Enter Data in both fields");
            }
            else
            {
                idclient = membreDAO.Login(login,password);
                if(idclient == 0)
                {
                    MessageBox.Show("Invalid credentials");
                }
                else
                {
                    MainWindow dashboard = new MainWindow(idclient);
                    dashboard.Show();
                    this.Close();
                }
            }
        }
    }
}
