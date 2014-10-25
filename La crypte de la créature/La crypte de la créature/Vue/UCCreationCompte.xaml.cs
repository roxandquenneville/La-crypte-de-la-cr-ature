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

namespace La_crypte_de_la_creature.Vue
{
    /// <summary>
    /// Logique d'interaction pour UCCreationCompte.xaml
    /// </summary>
    public partial class UCCreationCompte : UserControl
    {
        public CompteViewModel ViewModel { get{return (CompteViewModel)DataContext;}}

        public UCCreationCompte()
        {
            InitializeComponent();
            DataContext = new CompteViewModel();
        }

        private void btn_Confirme(object sender, RoutedEventArgs e)
        {
            lblErreur.Content = "";

            if (tbxMotDePasse.Text == tbxMotDePasseConfirme.Text)
                try
                {
                    ViewModel.SauvegarderCommand();
                }
                catch(Exception exception)
                {
                    
                }
            else
            {
                lblErreur.Content = "Les mot de passe ne sont pas identique";
                lblErreur.Visibility = Visibility.Visible;
            }

        }

        private void btn_Annule(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
