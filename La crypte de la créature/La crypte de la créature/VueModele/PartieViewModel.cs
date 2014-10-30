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

namespace La_crypte_de_la_creature.VueModele
{
    public class PartieViewModel : BaseViewModel
    {

        #region Service
        private IPartieService _PartieService;
        private IPlateauService _PlateauService;
        private IJoueurService _JoueurService;
        private 
        #endregion

               RetrievePartieArgs RetrievePartieArgs { get; set; }
        public RetrieveJoueurArgs RetrieveJoueurArgs { get; set; }
        public RetrievePlateauArgs RetrievePlateauArgs { get; set; }

        public PartieViewModel()
        {
            _PartieService = ServiceFactory.Instance.GetService<IPartieService>();
            _PlateauService = ServiceFactory.Instance.GetService<IPlateauService>();
            _JoueurService = ServiceFactory.Instance.GetService<IJoueurService>();


            Parties = new ObservableCollection<Partie>(_PartieService.RetrieveAll());
       //     Joueurs = new ObservableCollection<Joueur>(_JoueurService.RetrieveAll());
            

            RetrieveJoueurArgs = new RetrieveJoueurArgs();
            RetrievePartieArgs = new RetrievePartieArgs();
            RetrievePlateauArgs = new RetrievePlateauArgs();


            Plateau = new Plateau();
            Partie = new Partie(1,2,new TypePlateau ("Normal"));
            

        }

        #region Bindables

        private ObservableCollection<Joueur> _Joueurs;

        public ObservableCollection<Joueur> Joueurs
        {
            get
            {
                return _Joueurs;
            }
            set
            {
                if (_Joueurs == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Joueurs = value;
                RaisePropertyChanged();
            } 
        }


        private Plateau _Plateau;

        public Plateau Plateau
        {
            get
            {
                return _Plateau;
            }
            set
            {
                if (_Plateau == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Plateau = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<Partie> _Parties = new ObservableCollection<Partie>();

        public ObservableCollection<Partie> Parties
        {
            get
            {
                return _Parties;
            }

            set
            {
                if (_Parties == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Parties = value;
                RaisePropertyChanged();
            }
        }

        private Partie _Partie;
        public Partie Partie
        {
            get
            {

                return _Partie;
            }

            set
            {
                if (_Partie == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Partie = value;
                RaisePropertyChanged();
            }

        }

        #endregion

        #region command

        public void CreerPartieCommand()
        {
        // Mapping a corriger 
    //        _PartieService.Create(Partie);
        }

        public void SauvegarderCommand()
        {            
            _PartieService.Update(Partie);
            
        }

        #endregion

      
    }
}
