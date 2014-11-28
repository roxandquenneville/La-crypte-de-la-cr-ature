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
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.VueModele;

namespace La_crypte_de_la_creature.Vue
{
    /// <summary>
    /// Logique d'interaction pour UCChoixPartie.xaml
    /// </summary>
    public partial class UCChoixPartie : UserControl
    {

        public PartieViewModel PartieViewModel { get { return (PartieViewModel)DataContext; } }
        IApplicationService mainVM = ServiceFactory.Instance.GetService<IApplicationService>();  
        public UCChoixPartie()
        {
            InitializeComponent();
            DataContext = new PartieViewModel();
            Loaded += WindowLoaded;

        }

        private void WindowLoaded(Object o, RoutedEventArgs e)
        {
             StringBuilder MessageBienvenue = new StringBuilder().Append("Bienvenue, ").Append(UtilisateurConnecte.nomUsager);
             tbxUsagerConnecte.Content = MessageBienvenue;
        }

        private void Btn_Deconnexion(object sender, RoutedEventArgs e)
        {
            this.Content = new UCMainWindow();
        }

        private void Btn_NouvellePartie(object sender, RoutedEventArgs e)
        {
               
            Application.Current.MainWindow.Background = Brushes.White;
            mainVM.ChangeView<UCInvitationJoueur>( new UCInvitationJoueur());
            

        }

        private void Button_reprendrePartie(object sender, RoutedEventArgs e)
        {
            string r = "a";
            mainVM.ChangeView<UCPlateau>(new UCPlateau(r));
        }

        

    }
}
