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
using La_crypte_de_la_creature.VueModele;

namespace La_crypte_de_la_creature.Vue
{
    /// <summary>
    /// Logique d'interaction pour UCPlateau.xaml
    /// </summary>
    public partial class UCPlateau : UserControl
    {

        public PartieViewModel PartieViewModel { get { return (PartieViewModel)DataContext; } }

        public UCPlateau()
        {
            InitializeComponent();
            DataContext = new PartieViewModel();
            Loaded += WindowsLoaded;

        }

        private void WindowsLoaded(Object o ,RoutedEventArgs e)
        {
             
        }
   

    }
}
