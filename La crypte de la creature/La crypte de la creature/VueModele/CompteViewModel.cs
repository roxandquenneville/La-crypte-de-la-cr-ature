using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cstj.MvvmToolkit;
using Cstj.MvvmToolkit.Services;
using Cstj.MvvmToolkit.Services.Definitions;
using La_crypte_de_la_creature.Logic.Modele.Args;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Services.Interfaces;
using La_crypte_de_la_creature.Logic.Services.NHibernate;
using La_crypte_de_la_creature.Vue;
using La_crypte_de_la_creature.VueModele;

namespace La_crypte_de_la_creature.UI.ViewModel
{
    public class CompteViewModel : BaseViewModel    
    {
        public event EventHandler<HarvestPasswordEventArgs> HarvestPassword;
        IApplicationService mainVM = ServiceFactory.Instance.GetService<IApplicationService>(); 

        #region Service
        private ICompteService _CompteService; 
        #endregion        
            

        public RetrieveCompteArgs RetrieveArgs { get; set; }

        public CompteViewModel()
        {
            _CompteService = ServiceFactory.Instance.GetService<ICompteService>();
            Comptes =  new ObservableCollection<Compte>(_CompteService.RetrieveAll());
            RetrieveArgs = new RetrieveCompteArgs();
            Compte = new Compte();

        }

        #region Bindable
        private Compte _compte;
        
        public Compte Compte
        { 
            get
            {
                
                return _compte;
            }

            set
            {
                if (_compte == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _compte = value;
                RaisePropertyChanged();
            }

        }

        private ObservableCollection<Compte> _comptes = new ObservableCollection<Compte>();

        public ObservableCollection<Compte> Comptes
        {
            get
            {
                return _comptes;
            }

            set
            {
                if (_comptes == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _comptes = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Compte> _comptesInvite = new ObservableCollection<Compte>();

        public ObservableCollection<Compte> ComptesInvite
        {
            get
            {
                return _comptesInvite;
            }

            set
            {
                if (_comptesInvite == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _comptesInvite = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region Command

        public void SauvegarderCommand()
        {          

            var pwargs = new HarvestPasswordEventArgs();
            HarvestPassword(this, pwargs);

            Compte.MotDePasse = pwargs.Password;    
            Compte.NomUsager = RetrieveArgs.nomUsager;
            Compte.Email = RetrieveArgs.email;
            _CompteService.Create(Compte);
        }

        public void ConnexionCommand()
        {
            Compte CompteConnexion = new Compte();
            UtilisateurConnecte.nomUsager = null;
            UtilisateurConnecte.idCompte = null;



            var pwargs = new HarvestPasswordEventArgs();
            HarvestPassword(this, pwargs);

            CompteConnexion.MotDePasse = pwargs.Password;
            CompteConnexion.NomUsager = this.RetrieveArgs.nomUsager;
            foreach (Compte C in this.Comptes)
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
      
        }

        #endregion
    }
}
