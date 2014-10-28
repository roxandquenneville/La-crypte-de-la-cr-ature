using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cstj.MvvmToolkit;
using Cstj.MvvmToolkit.Services;
using La_crypte_de_la_creature.Logic.Modele.Args;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Services.Interfaces;
using La_crypte_de_la_creature.Logic.Services.NHibernate;

namespace La_crypte_de_la_creature.UI.ViewModel
{
    public class CompteViewModel : BaseViewModel
    {

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

        #endregion

        #region Command

        public void SauvegarderCommand()
        {
            Compte.MotDePasse = RetrieveArgs.motDePasse;
            Compte.NomUsager = RetrieveArgs.nomUsager;
            _CompteService.Create(Compte);
        }

        #endregion
    }
}
