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
using Cstj.MvvmToolkit.Services;
using Cstj.MvvmToolkit.Services.Definitions;
using La_crypte_de_la_creature.UI.ViewModel;
using La_crypte_de_la_creature.UI.VueModele;
using La_crypte_de_la_creature.Logic.Modele.Classes;

namespace La_crypte_de_la_creature.Vue
{
    /// <summary>
    /// Logique d'interaction pour UCMainWindow.xaml
    /// </summary>
    public partial class UCMainWindow : UserControl
    {
        public MainViewModel ViewModel { get { return (MainViewModel)DataContext; } }
        IApplicationService mainVM = ServiceFactory.Instance.GetService<IApplicationService>();
        public UCMainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            Loaded += MyWindow_Loaded;
            
        }




        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            mainVM.ChangeView<UCConnexion>(new UCConnexion());
        }


    }
}
