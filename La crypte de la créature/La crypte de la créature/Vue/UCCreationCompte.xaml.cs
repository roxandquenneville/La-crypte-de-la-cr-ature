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
    /// Logique d'interaction pour UCCreationCompte.xaml
    /// </summary>
    public partial class UCCreationCompte : UserControl
    {
        public CompteViewModel ViewModel { get{return (CompteViewModel)DataContext;}}
        IApplicationService mainVM = ServiceFactory.Instance.GetService<IApplicationService>();
        public UCCreationCompte()
        {
            InitializeComponent();
            DataContext = new CompteViewModel();
        }

        private void btn_Confirme(object sender, RoutedEventArgs e)
        {
            lblErreur.Content = String.Empty;
            bool utilisateurPresent = false;
           
            if (tbxMotDePasse.Text == tbxMotDePasseConfirme.Text && tbxEmail.Text == tbxEmailConfirme.Text  )
            {
                
                foreach(Compte C in ViewModel.Comptes )
                {
                    if(C.NomUsager == tbxNomUsager.Text)
                    { 
                        utilisateurPresent = true;
                    }
                }
                if(utilisateurPresent !=true)
                { 
                    try
                    {
                        ViewModel.SauvegarderCommand();
                        mainVM.ChangeView<UCConnexion>(new UCConnexion());
                    }
                    catch(Exception exception)
                    {
                    
                    }
                }
                else
                {
                    lblErreur.Content = "Nom d'utilisateur déja utilisé";
                    lblErreur.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if(tbxMotDePasse.Text != tbxMotDePasseConfirme.Text && tbxEmail.Text != tbxEmailConfirme.Text)
                { 
                    lblErreur.Content = "Les mot de passe et les E-mails ne sont pas identique";
                    lblErreur.Visibility = Visibility.Visible;
                }
                else if (tbxMotDePasse.Text != tbxMotDePasseConfirme.Text)
                {
                    lblErreur.Content = "Les mot de passe ne sont pas identique";
                    lblErreur.Visibility = Visibility.Visible;
                }
                else
                {
                    lblErreur.Content = "Les E-mails ne sont pas identique";
                    lblErreur.Visibility = Visibility.Visible;
                }
              }
        }

        private void btn_Annule(object sender, RoutedEventArgs e)
        {
            mainVM.ChangeView<UCConnexion>(new UCConnexion());
        }

        private void GotFocus(object sender, RoutedEventArgs e)
        {
            lblErreur.Visibility = Visibility.Hidden;
        }


    }
}
