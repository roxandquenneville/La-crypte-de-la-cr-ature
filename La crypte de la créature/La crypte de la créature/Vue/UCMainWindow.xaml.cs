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
        public UCMainWindow ViewModel { get { return (UCMainWindow)DataContext; } }
        public CompteViewModel CompteViewModel { get { return (CompteViewModel)DataContext; } }
        IApplicationService mainVM = ServiceFactory.Instance.GetService<IApplicationService>();            
        public UCMainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            lblErreur.Visibility = Visibility.Hidden;
        }

        private void Btn_Quitter(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Btn_Connecion(object sender, RoutedEventArgs e)
        {
            Compte CompteConnexion = new Compte();
            UtilisateurConnecte.nomUsager = null;
            UtilisateurConnecte.idCompte = null;

            CompteConnexion.MotDePasse = CompteViewModel.RetrieveArgs.motDePasse;
            CompteConnexion.NomUsager = CompteViewModel.RetrieveArgs.nomUsager;
                foreach( Compte C in  CompteViewModel.Comptes)
                {
                    if (CompteConnexion.NomUsager == C.NomUsager)
                    {
                        if (CompteConnexion.MotDePasse == C.MotDePasse)
                        {
                            //Utilisateur Confirme
                            UtilisateurConnecte.nomUsager = CompteConnexion.NomUsager;
                            UtilisateurConnecte.idCompte = C.idCompte;
                            mainVM.ChangeView<UCChoixPartie>(new UCChoixPartie());
                        }                     
                    }
                    //Nom utilsateur inexistant
                   
                }
                if (UtilisateurConnecte.nomUsager != null)
                {
                    lblErreur.Content = "Erreur lors de la connexion, veuillez réessayer.";
                    lblErreur.Visibility = Visibility.Visible;
                }
            
        }

        private void Lbl_Click(object sender, RoutedEventArgs e)
        {
         
           mainVM.ChangeView<UCCreationCompte>(new UCCreationCompte());

        }

    }
}
