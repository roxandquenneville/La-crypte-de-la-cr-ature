using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.UI.ViewModel;


namespace La_crypte_de_la_creature.Vue
{
    /// <summary>
    /// Logique d'interaction pour UCInvitationJoueur.xaml
    /// </summary>
    /// 
    public partial class UCInvitationJoueur : UserControl
    {

        public CompteViewModel CompteViewModel { get { return (CompteViewModel)DataContext; } }
        IApplicationService mainVM = ServiceFactory.Instance.GetService<IApplicationService>();  
          

        public UCInvitationJoueur()
        {
            InitializeComponent();
            DataContext = new CompteViewModel();
            Loaded += WindowsLoaded;
        }

        private void WindowsLoaded(object o, RoutedEventArgs e)
        {   
            foreach(Compte C in CompteViewModel.Comptes)
            {
                lbxDisponible.Items.Add(C.NomUsager);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.MinHeight = 600;
            Application.Current.MainWindow.MinWidth = 750;
            mainVM.ChangeView<UCPlateau>(new UCPlateau());
        }
    }
}
