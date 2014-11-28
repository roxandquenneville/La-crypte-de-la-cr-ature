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
using La_crypte_de_la_creature.UI.ViewModel;
using La_crypte_de_la_creature.VueModele;

namespace La_crypte_de_la_creature.Vue
{
    /// <summary>
    /// Logique d'interaction pour UCConnexion.xaml
    /// </summary>
    public partial class UCConnexion : UserControl
    {
        public CompteViewModel CompteViewModel { get { return (CompteViewModel)DataContext; } }
        IApplicationService mainVM = ServiceFactory.Instance.GetService<IApplicationService>();  
        //String NomUsager;

        public UCConnexion()
        {
            InitializeComponent();
            DataContext = new CompteViewModel();

            lblErreur.Visibility = Visibility.Hidden;
            Loaded += WindowsLoaded;
            CompteViewModel.HarvestPassword += (sender, args) =>
            args.Password = PasswordBox1.Password;    
        }
               
       private void WindowsLoaded(object sender, RoutedEventArgs e)
        {
            tbxNomUsager.Focus(); 
        }

        private void Btn_Quitter(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Btn_Connexion(object sender, RoutedEventArgs e)
        {
            
           if(CompteViewModel.ConnexionCommand())
           {    
                lblErreur.Visibility = Visibility.Visible;
                lblErreur.Content = "Erreur de connexion";
           }
            
        }

        private void Lbl_Click(object sender, RoutedEventArgs e)
        {
         
           mainVM.ChangeView<UCCreationCompte>(new UCCreationCompte());

        }
     
        private void GotFocus(object sender, RoutedEventArgs e)
        {
            lblErreur.Visibility = Visibility.Hidden; 
        }


    }
}
