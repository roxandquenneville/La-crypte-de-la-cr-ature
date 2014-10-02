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
    /// Logique d'interaction pour UCCreationCompte.xaml
    /// </summary>
    public partial class UCCreationCompte : UserControl
    {
        public UCCreationCompte()
        {
            InitializeComponent();
        }

        private void btn_Confirme(object sender, RoutedEventArgs e)
        {
            this.Content = new UCChoixPartie();
        }

        private void btn_Annule(object sender, RoutedEventArgs e)
        {
            this.Content = new UCMainWindow();
        }

    }
}
