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
        private IHistoriqueService _HistoriqueService;
        //private ITypePlateauService _TypePlateauService;
        //    private IPointageService _PointageService;
        #endregion
        public RetrieveTypePlateauArgs RetrieveTypePlateauArgs { get; set; }
        public RetrievePartieArgs RetrievePartieArgs { get; set; }
        public RetrieveJoueurArgs RetrieveJoueurArgs { get; set; }
        public RetrievePlateauArgs RetrievePlateauArgs { get; set; }
        public RetrieveHistoriqueArgs RetrieveHistoriqueArgs { get; set; }
        //  public RetrievePointageArgs RetrievePointageArgs { get; set;}
        public PartieViewModel()
        {
            //_TypePlateauService = ServiceFactory.Instance.GetService<ITypePlateauService>();
            _PartieService = ServiceFactory.Instance.GetService<IPartieService>();
            _PlateauService = ServiceFactory.Instance.GetService<IPlateauService>();
            _JoueurService = ServiceFactory.Instance.GetService<IJoueurService>();
            _HistoriqueService = ServiceFactory.Instance.GetService<IHistoriqueService>();
            //  _PointageService = ServiceFactory.Instance.GetService<IPointageService>();

            Parties = new ObservableCollection<Partie>(_PartieService.RetrieveAll());
            Joueurs = new ObservableCollection<Joueur>(_JoueurService.RetrieveAll());
            //   Pointages = new ObservableCollection<Pointage>(_PointageService.RetrieveAll());
            Historiques = new ObservableCollection<Historique>(_HistoriqueService.RetrieveAll());
            //   Joueur = _JoueurService.Retrieve(RetrieveJoueurArgs);

            RetrieveTypePlateauArgs = new RetrieveTypePlateauArgs();
            RetrieveJoueurArgs = new RetrieveJoueurArgs();
            RetrievePartieArgs = new RetrievePartieArgs();
            RetrievePlateauArgs = new RetrievePlateauArgs();
            RetrieveHistoriqueArgs = new RetrieveHistoriqueArgs();
            //    RetrievePointageArgs = new RetrievePointageArgs();
            Joueur = new Joueur(2);
            Historique = new Historique();
            Plateau = new Plateau("Normal");
            Partie = new Partie(1, 2, "Normal");



        }

        #region Bindable



        private Joueur _Joueur;

        public Joueur Joueur
        {
            get
            {
                return _Joueur;
            }
            set
            {
                if (_Joueur == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Joueur = value;
                RaisePropertyChanged();
            }
        }




        private Historique _Historique;

        public Historique Historique
        {
            get
            {
                return _Historique;
            }
            set
            {
                if (_Historique == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Historique = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<Historique> _Historiques;

        public ObservableCollection<Historique> Historiques
        {
            get
            {
                return _Historiques;
            }
            set
            {
                if (_Historiques == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Historiques = value;
                RaisePropertyChanged();
            }
        }



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


        //private ObservableCollection<Pointage> _Pointages;
        //public ObservableCollection<Pointage> Pointages
        //{
        //    get
        //    {
        //        return _Pointages;
        //    }
        //    set
        //    {
        //        if (_Pointages == value)
        //        {
        //            return;
        //        }
        //        RaisePropertyChanging();
        //        _Pointages = value;
        //        RaisePropertyChanged();
        //    }
        //}



        private Pointage _Pointage;

        public Pointage Pointage
        {
            get
            {
                return _Pointage;
            }
            set
            {
                if (_Pointage == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Pointage = value;
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
            //Plateau.TypePlateau = _TypePlateauService.RetrieveAll().FirstOrDefault();
            //Plateau.Cases = Partie.Plateau.Cases;
            //Plateau.Pieces = Partie.Plateau.Pieces;   
            //_HistoriqueService.Create(Historique);
            //_PlateauService.Create(Plateau);
            //_PartieService.Create(Partie);
        }

        public void SauvegarderCommand()
        {
            _PartieService.Update(Partie);

        }

        #endregion


    }
}
