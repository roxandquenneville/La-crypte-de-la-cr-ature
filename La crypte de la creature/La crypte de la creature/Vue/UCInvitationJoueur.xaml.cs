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
using La_crypte_de_la_creature.VueModele;


namespace La_crypte_de_la_creature.Vue
{
    /// <summary>
    /// Logique d'interaction pour UCInvitationJoueur.xaml
    /// </summary>
    /// 
    public partial class UCInvitationJoueur : UserControl
    {

        public CompteViewModel CompteViewModel { get { return (CompteViewModel)DataContext; } }
        public PartieViewModel PartieViewModel { get  { return (PartieViewModel)DataContext; } }
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
                if(UtilisateurConnecte.nomUsager != C.NomUsager)
                lbxDisponible.Items.Add(C.NomUsager);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.MinHeight = 600;
            Application.Current.MainWindow.MinWidth = 750;
            ObservableCollection<Compte> listCompteInvite = new ObservableCollection<Compte>();

            foreach(Compte C in CompteViewModel.Comptes)
            {
                foreach( ItemCollection IT in lbxInviter.Items )
                { 
                        if( IT.CurrentItem.ToString() == C.NomUsager )
                        {
                           listCompteInvite.Add(C);
                        }
                } 
            }

            PartieViewModel.ListJoueurInvite = listCompteInvite;
            mainVM.ChangeView<UCPlateau>(new UCPlateau());
        }

        private void btnAjouterJoueur(object sender, RoutedEventArgs e)
        {
            if (lbxDisponible.SelectedIndex != -1)
            {
                lbxInviter.Items.Add(lbxDisponible.Items[lbxDisponible.SelectedIndex]);
                lbxDisponible.Items.RemoveAt(lbxDisponible.SelectedIndex);
            }
            
        }
        private void btnEnleverJoueur(object sender, RoutedEventArgs e)
        {
            if (lbxInviter.SelectedIndex != -1)
            {
                lbxDisponible.Items.Add(lbxInviter.Items[lbxInviter.SelectedIndex]);
                lbxInviter.Items.RemoveAt(lbxInviter.SelectedIndex); 
            }
          
        }

        private void lbxDisponible_GotFocus(object sender, RoutedEventArgs e)
        {
            lbxInviter.SelectedIndex = -1;
        }

        private void lbxInviter_GotFocus(object sender, RoutedEventArgs e)
        {
            lbxDisponible.SelectedIndex = -1;
        }

      
    }
}
