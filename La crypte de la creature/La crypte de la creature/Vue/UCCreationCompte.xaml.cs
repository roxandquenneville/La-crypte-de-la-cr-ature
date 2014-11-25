using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        bool invalid = false;

        public UCCreationCompte()
        {
            InitializeComponent();
            DataContext = new CompteViewModel();
            ViewModel.HarvestPassword +=(sender, args) =>
            args.Password = PasswordBox1.Password;
        }

        private void btn_Confirme(object sender, RoutedEventArgs e)
        {
            lblErreur.Content = String.Empty;
            bool utilisateurPresent = false;

            if (PasswordBox1.Password == PasswordBox2.Password && tbxEmail.Text == tbxEmailConfirme.Text /* && tbxMotDePasse.Text == null */ )
            {
                
                foreach(Compte C in ViewModel.Comptes )
                {
                    if(C.NomUsager == tbxNomUsager.Text)
                    { 
                        utilisateurPresent = true;
                    }
                }
                if(IsValidEmail(tbxEmailConfirme.Text))
                { 
                    if(utilisateurPresent !=true)
                    { 
                        try
                        {
                            ViewModel.SauvegarderCommand();
                            UtilisateurConnecte.nomUsager = tbxNomUsager.Text;                            
                            mainVM.ChangeView<UCChoixPartie>(new UCChoixPartie());
                            
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
                    lblErreur.Content = "Email non valide";
                    lblErreur.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (PasswordBox1.Password != PasswordBox2.Password && tbxEmail.Text != tbxEmailConfirme.Text)
                {
                    lblErreur.Content = "Les mot de passe et les E-mails ne sont pas identique";
                    lblErreur.Visibility = Visibility.Visible;
                }
                else if (PasswordBox1.Password != PasswordBox2.Password)
                {
                    lblErreur.Content = "Les mot de passe ne sont pas identique";
                    lblErreur.Visibility = Visibility.Visible;
                }
                else if (PasswordBox1.Password == null)
                {
                    lblErreur.Content = "Le mot de passe ne peut pas être vide";
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




        
        //Fonction du site MSDN pour la verification des Emails

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names. 
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format. 
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        //Fonction du site MSDN pour la verification des Emails
        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

    }
}
