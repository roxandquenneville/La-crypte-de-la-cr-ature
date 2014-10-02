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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace La_crypte_de_la_creature.Vue
{
    /// <summary>
    /// Logique d'interaction pour UCChoixPartie.xaml
    /// </summary>
    public partial class UCChoixPartie : UserControl
    {
        public UCChoixPartie()
        {
            InitializeComponent();
        }

        private void Btn_Deconnexion(object sender, RoutedEventArgs e)
        {
            this.Content = new UCMainWindow();
        }

        private void Btn_NouvellePartie(object sender, RoutedEventArgs e)
        {
       
            Application.Current.MainWindow.Background = Brushes.White;
            this.Content = new UCInvitationJoueur();
        }

    }
}
