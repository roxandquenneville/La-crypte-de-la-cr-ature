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
        private IPointageService _PointageService;
        private ICaseService _CaseService;
        private ICarteMonstreService _CarteMonstreService;
        private IPionService _PionService;
        private ICompteService _CompteService;
        #endregion
       
        public RetrievePartieArgs RetrievePartieArgs { get; set; }
        public RetrieveJoueurArgs RetrieveJoueurArgs { get; set; }
        public RetrievePlateauArgs RetrievePlateauArgs { get; set; }
        public RetrieveHistoriqueArgs RetrieveHistoriqueArgs { get; set; }
        public RetrievePointageArgs RetrievePointageArgs { get; set; }
        public RetrieveCompteArgs RetrieveCompteArgs { get; set; }

        public PartieViewModel()
        {
            
            _PartieService = ServiceFactory.Instance.GetService<IPartieService>();
            _PlateauService = ServiceFactory.Instance.GetService<IPlateauService>();
            _JoueurService = ServiceFactory.Instance.GetService<IJoueurService>();
            _HistoriqueService = ServiceFactory.Instance.GetService<IHistoriqueService>();
            _PointageService = ServiceFactory.Instance.GetService<IPointageService>();
            _CaseService = ServiceFactory.Instance.GetService<ICaseService>();
            _CarteMonstreService = ServiceFactory.Instance.GetService<ICarteMonstreService>();
            _PionService = ServiceFactory.Instance.GetService<IPionService>();
            _CompteService = ServiceFactory.Instance.GetService<ICompteService>();

            Parties = new ObservableCollection<Partie>(_PartieService.RetrieveAll());
        //    Joueurs = new ObservableCollection<Joueur>(_JoueurService.RetrieveAll());
            Pointages = new ObservableCollection<Pointage>(_PointageService.RetrieveAll());
            Historiques = new ObservableCollection<Historique>(_HistoriqueService.RetrieveAll());
            //   Joueur = _JoueurService.Retrieve(RetrieveJoueurArgs);

            
            RetrieveJoueurArgs = new RetrieveJoueurArgs();
            RetrievePartieArgs = new RetrievePartieArgs();
            RetrievePlateauArgs = new RetrievePlateauArgs();
            RetrieveHistoriqueArgs = new RetrieveHistoriqueArgs();
            RetrieveCompteArgs = new RetrieveCompteArgs();
            RetrievePlateauArgs.idPlateau = 1;
            RetrievePlateauArgs.type = "Normal";

            RetrievePointageArgs = new RetrievePointageArgs();
            Joueur = new Joueur(2);
            Pointage = new Pointage();
            //Joueur = new Joueur();
            Historique = new Historique();
            //Partie = new Partie();
            
            Cases = new ObservableCollection<Case>(_CaseService.RetrievePlateau(1));


        }

        #region Bindable


        private ObservableCollection<Compte> _ListJoueurInvite;
        public ObservableCollection<Compte> ListJoueurInvite
        {
            get
            {
                return _ListJoueurInvite;
            }
            set
            {
                if (_ListJoueurInvite == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _ListJoueurInvite = value;
                RaisePropertyChanged();
            } 
        }

        private ObservableCollection<Case> _Cases;
        public ObservableCollection<Case> Cases
        {
            get
            {
                return _Cases;
            }
            set
            {
                if (_Cases == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Cases = value;
                RaisePropertyChanged();
            }

        }

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


        private ObservableCollection<Pointage> _Pointages;
        public ObservableCollection<Pointage> Pointages
        {
            get
            {
                return _Pointages;
            }
            set
            {
                if (_Pointages == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Pointages = value;
                RaisePropertyChanged();
            }
        }



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
            Partie = new Partie((ListJoueurInvite.Count) + 1, 2, "Normal");

            /* la faut faire marcher les list*/
            Plateau = _PlateauService.Retrieve(RetrievePlateauArgs);
            Plateau.Case = Cases;
            //Créer l'historique
            _HistoriqueService.Create(Historique);

           
            
            //met les liens
            Partie.Historique = Historique;
            Partie.Plateau = Plateau;

            // Créer la partie
            _PartieService.Create(Partie);

            RetrieveCompteArgs.idCompte = UtilisateurConnecte.idCompte;

            Partie.Joueur[0].Compte = _CompteService.Retrieve(RetrieveCompteArgs);
            _JoueurService.Create(Joueur);

            for(int i =1; i < ListJoueurInvite.Count ; i++ )
            {
                Partie.Joueur[i].Partie.idPartie = Partie.idPartie;

                Partie.Joueur[i].Compte = _CompteService.Retrieve(RetrieveCompteArgs);

                _JoueurService.Create(Joueur);
            }
            
            

          

            

            Pointage.Partie = Partie;

            _PointageService.Create(Pointage);

            Partie.Joueur.Add(Joueur);

            Partie.Pointage.Add(Pointage);

            Partie.CartesMonstre.Add(new CartesMonstre(5));
            Partie.CartesMonstre.Add(new CartesMonstre(5));
            Partie.CartesMonstre.Add(new CartesMonstre(7));
            Partie.CartesMonstre.Add(new CartesMonstre(7));
            Partie.CartesMonstre.Add(new CartesMonstre(8));
            Partie.CartesMonstre.Add(new CartesMonstre(8));
            Partie.CartesMonstre.Add(new CartesMonstre(10));
            Partie.CartesMonstre.Add(new CartesMonstre(10));

            for (int i = 0; i < Partie.CartesMonstre.Count(); i++)
            {
                Partie.CartesMonstre[i].Partie = Partie;
                _CarteMonstreService.Create(Partie.CartesMonstre[i]);
            }
            Joueur.Pion[0].Joueur= Joueur;
            Joueur.Pion[0].Partie = Partie;
            Joueur.Pion[0].Position.idPosition = 175;

            _PionService.Create(Joueur.Pion[0]);
            _PionService.Create(Joueur.Pion[1]);

        }

        public void SauvegarderCommand()
        {
            _PartieService.Update(Partie);

        }

        #endregion


    }
}
