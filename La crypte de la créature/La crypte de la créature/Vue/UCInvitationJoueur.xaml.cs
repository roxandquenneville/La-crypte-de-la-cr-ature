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

namespace La_crypte_de_la_créature.Vue
{

    /// <summary>
    /// Logique d'interaction pour UCInvitationJoueur.xaml
    /// </summary>
    /// 
    public partial class UCInvitationJoueur : UserControl
    {
        public UCInvitationJoueur()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.MinHeight = 600;
            Application.Current.MainWindow.MinWidth = 750;
            this.Content = new UCPlateau();
        }
    }
}
