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
using La_crypte_de_la_creature.UI.ViewModel;
using La_crypte_de_la_creature.UI.VueModele;

namespace La_crypte_de_la_creature.Vue
{
    /// <summary>
    /// Logique d'interaction pour UCMainWindow.xaml
    /// </summary>
    public partial class UCMainWindow : UserControl
    {
        public UCMainWindow ViewModel { get { return (UCMainWindow)DataContext; } }
        public UCMainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Btn_Quitter(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Btn_Connecion(object sender, RoutedEventArgs e)
        {
            ;

        }

        private void Lbl_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new UCCreationCompte();

        }

    }
}
