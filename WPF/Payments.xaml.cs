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
            if(numbcli== 5/* ==if trésorier*/)
            {
                /* Afficher la liste des membres et leur wallet avec pour chacun => checkbox choix unique
                   qui permet de sélectionner l'id du membre 
                   Une fois sélectionner 
                   on peut appeler - réclamer forfait 
                                 - lettre rappel 
                                 - payer conducteur (si solde négatif)
                 */
            }
            else if(numbcli>6) /*càd pas responsable ni trésorier*/
            {
                /* on peut seulement consulter son solde
                */
            }
            else
            {
                /*pas vraiment nécessaire car responsable et les responsables ont pas accès à payments*/
            }
        }
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow(numbcli);
            dashboard.Show();
            this.Close();
        }
    }
}
