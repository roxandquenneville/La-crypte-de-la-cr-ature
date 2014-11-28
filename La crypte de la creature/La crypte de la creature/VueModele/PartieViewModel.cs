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
using La_crypte_de_la_creature.UI.ViewModel;

namespace La_crypte_de_la_creature.VueModele
{
    public class PartieViewModel : BaseViewModel
    {

        #region Service
        private IPartieService _PartieService;
        private IPartieService _PartieService2;
        private IPlateauService _PlateauService;
        private IJoueurService _JoueurService;
        private IHistoriqueService _HistoriqueService;
        private IPointageService _PointageService;
        private ICaseService _CaseService;
        private ICarteMonstreService _CarteMonstreService;
        private IPionService _PionService;
        private ICompteService _CompteService;
        private IPositionService _PositionService;
        private IPierreService _PierreService;
        private IMonstreService _MonstreService;
        private ICaseSangService _CaseSangService;
        private IDeplacementService _DeplacementService;
        #endregion


        public RetrievePartieArgs RetrievePartieArgs { get; set; }
        public RetrieveJoueurArgs RetrieveJoueurArgs { get; set; }
        public RetrievePlateauArgs RetrievePlateauArgs { get; set; }
        public RetrieveHistoriqueArgs RetrieveHistoriqueArgs { get; set; }
        public RetrievePointageArgs RetrievePointageArgs { get; set; }
        public RetrieveCompteArgs RetrieveCompteArgs { get; set; }
        public RetrievePositionArgs RetrievePositionArgs { get; set; }
        public RetrieveCarteMonstreArgs RetrieveCarteMonstreArgs {get; set;}
        public RetrieveMonstreArgs RetrieveMonstreArgs { get; set; }
        public RetrievePionArgs RetrievePionArgs {get; set; }
        public RetrievePierreArgs RetrievePierreArgs { get; set; }
        public RetrieveCaseSangArgs RetrieveCaseSangArgs { get; set;}
        public static int compteHistorique=1;

        public PartieViewModel()
        {
           
            _PartieService = ServiceFactory.Instance.GetService<IPartieService>();
            _PartieService2 = ServiceFactory.Instance.GetService<IPartieService>();
            _PlateauService = ServiceFactory.Instance.GetService<IPlateauService>();
            _JoueurService = ServiceFactory.Instance.GetService<IJoueurService>();
            _HistoriqueService = ServiceFactory.Instance.GetService<IHistoriqueService>();
            _PointageService = ServiceFactory.Instance.GetService<IPointageService>();
            _CaseService = ServiceFactory.Instance.GetService<ICaseService>();
            _CarteMonstreService = ServiceFactory.Instance.GetService<ICarteMonstreService>();
            _PionService = ServiceFactory.Instance.GetService<IPionService>();
            _CompteService = ServiceFactory.Instance.GetService<ICompteService>();
            _PositionService = ServiceFactory.Instance.GetService<IPositionService>();
            _PierreService = ServiceFactory.Instance.GetService<IPierreService>();
            _MonstreService = ServiceFactory.Instance.GetService<IMonstreService>();
            _CaseSangService = ServiceFactory.Instance.GetService<ICaseSangService>();
            _DeplacementService = ServiceFactory.Instance.GetService<IDeplacementService>();

            Parties = new ObservableCollection<Partie>(_PartieService.RetrieveAll());
            Joueurs = new ObservableCollection<Joueur>(_JoueurService.RetrieveAll());
            Pointages = new ObservableCollection<Pointage>(_PointageService.RetrieveAll());
            Historiques = new ObservableCollection<Historique>(_HistoriqueService.RetrieveAll());
            Deplacements = new ObservableCollection<Deplacement>(_DeplacementService.RetrieveAll());
            Pions = new ObservableCollection<Pion>(_PionService.RetrieveAll());
            Pierres = new ObservableCollection<Pierre>(_PierreService.RetrieveAll());
            CasesDeSang = new ObservableCollection<CaseDeSang>(_CaseSangService.RetrieveAll());
            Monstres = new ObservableCollection<Monstre>(_MonstreService.RetrieveAll());
            //   Joueur = _JoueurService.Retrieve(RetrieveJoueurArgs);


            RetrieveJoueurArgs = new RetrieveJoueurArgs();
            RetrievePartieArgs = new RetrievePartieArgs();
            RetrievePlateauArgs = new RetrievePlateauArgs();
            RetrieveHistoriqueArgs = new RetrieveHistoriqueArgs();
            RetrieveCompteArgs = new RetrieveCompteArgs();
            RetrievePositionArgs = new RetrievePositionArgs();
            RetrieveCarteMonstreArgs = new RetrieveCarteMonstreArgs();
            RetrieveMonstreArgs = new RetrieveMonstreArgs();
            RetrievePionArgs = new RetrievePionArgs();
            RetrievePierreArgs = new RetrievePierreArgs();
            RetrieveCaseSangArgs = new RetrieveCaseSangArgs();
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

        private ObservableCollection<Deplacement> _Deplacements;

        public ObservableCollection<Deplacement> Deplacements
        {
            get
            {
                return _Deplacements;
            }
            set
            {
                if (_Deplacements == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Deplacements = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Pion> _Pions;

        public ObservableCollection<Pion> Pions
        {
            get
            {
                return _Pions;
            }
            set
            {
                if (_Pions == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Pions = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<Pierre> _Pierres;

        public ObservableCollection<Pierre> Pierres
        {
            get
            {
                return _Pierres;
            }
            set
            {
                if (_Pierres == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Pierres = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<CaseDeSang> _CasesDeSang;

        public ObservableCollection<CaseDeSang> CasesDeSang
        {
            get
            {
                return _CasesDeSang;
            }
            set
            {
                if (_CasesDeSang == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _CasesDeSang = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<Monstre> _Monstres;

        public ObservableCollection<Monstre> Monstres
        {
            get
            {
                return _Monstres;
            }
            set
            {
                if (_Monstres == value)
                {
                    return;
                }
                RaisePropertyChanging();
                _Monstres = value;
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
            Position pTmp = new Position();
            ListJoueurInvite = CompteInvite.ComptesInvite;

            Partie = new Partie(((ListJoueurInvite.Count) + 1), 2, "Normal");

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

            RetrieveCompteArgs.nomUsager = UtilisateurConnecte.nomUsager;

            Partie.Joueur[0].Compte = _CompteService.Retrieve(RetrieveCompteArgs);
            Partie.Joueur[0].Partie.idPartie = Partie.idPartie;
            _JoueurService.Create(Partie.Joueur[0]);

            Partie.Pointage[0].Partie.idPartie = Partie.idPartie;

            _PointageService.Create(Partie.Pointage[0]);
            
            for(int i =1; i <= ListJoueurInvite.Count; i++ )

            {
                Partie.Joueur[i].Partie.idPartie = Partie.idPartie;

                RetrieveCompteArgs.nomUsager = _ListJoueurInvite[i-1].NomUsager;
                Partie.Joueur[i].Compte = _CompteService.Retrieve(RetrieveCompteArgs);

                _JoueurService.Create(Partie.Joueur[i]);

                Partie.Pointage[i].Partie.idPartie = Partie.idPartie;

                _PointageService.Create(Partie.Pointage[i]);
            }   

            //_CarteMonstreService.RetrieveCartePartie(Partie,RetrieveCarteMonstreArgs);
            //ObservableCollection<CartesMonstre> listCarte = new ObservableCollection<CartesMonstre>();
           // listCarte.Shuffle();
           /* for (int i = 0; i < listCarte.Count(); i++)
            {
                Partie.CartesMonstre.Add(listCarte[i]);
            }*/
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

           for(int i=0;i<Partie.Joueur.Count;i++)
           {
                for(int x=0;x<Partie.Joueur[0].Pion.Count;x++)
                {
                    Partie.Joueur[i].Pion[x].Partie.idPartie = Partie.idPartie;
                    Partie.Joueur[i].Pion[x].Joueur = Partie.Joueur[i];
                    RetrievePositionArgs.X = Partie.Joueur[i].Pion[x].Position.X;
                    RetrievePositionArgs.Y = Partie.Joueur[i].Pion[x].Position.Y;
                    pTmp=_PositionService.Retrieve(RetrievePositionArgs);
                    Partie.Joueur[i].Pion[x].Position.idPosition = pTmp.idPosition;
                    Partie.Joueur[i].Pion[x].Position.X = pTmp.X;
                    Partie.Joueur[i].Pion[x].Position.Y = pTmp.Y;
                    _PionService.Create((Pion)Partie.Joueur[i].Pion[x]);
                }
           }

           for(int i=0;i<Partie.Piece.Count;i++)
           {
                Partie.Piece[i].Partie = Partie;
                RetrievePositionArgs.X = Partie.Piece[i].Position.X;
                RetrievePositionArgs.Y = Partie.Piece[i].Position.Y;
                pTmp = _PositionService.Retrieve(RetrievePositionArgs);
                Partie.Piece[i].Position.idPosition = pTmp.idPosition;
                Partie.Piece[i].Position.X = pTmp.X;
                Partie.Piece[i].Position.Y = pTmp.Y;
               

                switch (Partie.Piece[i].Get_Type())
                {
                    case ConstanteGlobale.PIERRE :
                            _PierreService.Create((Pierre)Partie.Piece[i]);
                            break;
                    case ConstanteGlobale.MONSTRE :
                            _MonstreService.Create((Monstre)Partie.Piece[i]);
                            break;
                     case ConstanteGlobale.CASEDESANG :
                            _CaseSangService.Create((CaseDeSang)Partie.Piece[i]);
                            break;
                }
           }
        }



        
        public void SauvegarderCommand()
        {
            Position pTmp = new Position();
            for (int i = 0; i < Partie.Piece.Count; i++)
            {
                RetrievePositionArgs.X = Partie.Piece[i].Position.X;
                RetrievePositionArgs.Y = Partie.Piece[i].Position.Y;
                pTmp = _PositionService.Retrieve(RetrievePositionArgs);

                 if(pTmp.idPosition != Partie.Piece[i].Position.idPosition)
                 {
                    Partie.Piece[i].Position.idPosition = pTmp.idPosition;

                  switch (Partie.Piece[i].Get_Type())
                    {
                        case ConstanteGlobale.MONSTRE:
                                  
                                 _MonstreService.Update((Monstre)Partie.Piece[i]);
                             
                            break;
                        case ConstanteGlobale.PION:
                        
                                _PionService.Update((Pion)Partie.Piece[i]);
                            
                            break;
                        case ConstanteGlobale.PIERRE:
                          
                                
                                _PierreService.Update((Pierre)Partie.Piece[i]);
                             
                            break;
                    }
                  }

            }

            for(int i=0;i<Partie.Pointage.Count;i++)
            {
                _PointageService.Update(Partie.Pointage[i]);
            }
            for(int i=0;i<Partie.CartesMonstre.Count;i++)
            {
                _CarteMonstreService.Update(Partie.CartesMonstre[i]);
            }
            
            for(int i=compteHistorique-1;i<Partie.Historique.Deplacement.Count;i++)
            {
                
                RetrievePositionArgs.X = Partie.Historique.Deplacement[i].Depart.X;
                RetrievePositionArgs.Y = Partie.Historique.Deplacement[i].Depart.Y;
                pTmp = _PositionService.Retrieve(RetrievePositionArgs);
                Partie.Historique.Deplacement[i].Depart.idPosition = pTmp.idPosition;
                Partie.Historique.Deplacement[i].Depart.X = pTmp.X;
                Partie.Historique.Deplacement[i].Depart.Y = pTmp.Y;

                RetrievePositionArgs.X = Partie.Historique.Deplacement[i].Fin.X;
                RetrievePositionArgs.Y = Partie.Historique.Deplacement[i].Fin.Y;
                pTmp = _PositionService.Retrieve(RetrievePositionArgs);
                Partie.Historique.Deplacement[i].Fin.idPosition = pTmp.idPosition;
                Partie.Historique.Deplacement[i].Fin.X = pTmp.X;
                Partie.Historique.Deplacement[i].Fin.Y = pTmp.Y;

                Partie.Historique.Deplacement[i].Historique.idHistorique=Partie.Historique.idHistorique;


                _DeplacementService.Create(Partie.Historique.Deplacement[i]);
            }
        }

       
        #endregion
        public void reprendrePartieCommand()
        {
            Position pTmp = new Position();
           
            

            //Partie Partie2 = _PartieService2.RetrieveLast(RetrievePartieArgs);

            ///* la faut faire marcher les list*/
            //Plateau = _PlateauService.Retrieve(RetrievePlateauArgs);
            //Plateau.Case = Cases;
            ////Créer l'historique
            //Historique Historique2 = _HistoriqueService.RetrieveLast(RetrieveHistoriqueArgs);


            ////met les liens
            //Partie2.Historique = Historique2;
            //Partie2.Plateau = Plateau;

            

            //RetrieveCompteArgs.nomUsager = UtilisateurConnecte.nomUsager;

            //Partie.Joueur[0].Compte = _CompteService.Retrieve(RetrieveCompteArgs);
            //Partie.Joueur[0].Partie.idPartie = Partie.idPartie;
            //_JoueurService.Create(Partie.Joueur[0]);

            //Partie.Pointage[0].Partie.idPartie = Partie.idPartie;

            //_PointageService.Create(Partie.Pointage[0]);

            //for (int i = 1; i < ListJoueurInvite.Count; i++)
            //{
            //    Partie.Joueur[i].Partie.idPartie = Partie.idPartie;

            //    RetrieveCompteArgs.nomUsager = _ListJoueurInvite[i - 1].NomUsager;
            //    Partie.Joueur[i].Compte = _CompteService.Retrieve(RetrieveCompteArgs);

            //    _JoueurService.Create(Partie.Joueur[i]);

            //    Partie.Pointage[i].Partie.idPartie = Partie.idPartie;

            //    _PointageService.Create(Partie.Pointage[i]);
            //}

            //_CarteMonstreService.RetrieveCartePartie(Partie,RetrieveCarteMonstreArgs);
            //ObservableCollection<CartesMonstre> listCarte = new ObservableCollection<CartesMonstre>();
            // for (int i = 0; i < listCarte.Count(); i++)
            // {
            //     Partie.CartesMonstre.Add(listCarte[i]);
            // }
            
           

            //for (int i = 0; i < Partie.CartesMonstre.Count(); i++)
            //{
            //    Partie.CartesMonstre[i].Partie = Partie;
            //    _CarteMonstreService.Create(Partie.CartesMonstre[i]);
            //}

            //for (int i = 0; i < Partie.Joueur.Count; i++)
            //{
            //    for (int x = 0; x < Partie.Joueur[0].Pion.Count; x++)
            //    {
            //        Partie.Joueur[i].Pion[x].Partie.idPartie = Partie.idPartie;
            //        Partie.Joueur[i].Pion[x].Joueur = Partie.Joueur[i];
            //        RetrievePositionArgs.X = Partie.Joueur[i].Pion[x].Position.X;
            //        RetrievePositionArgs.Y = Partie.Joueur[i].Pion[x].Position.Y;
            //        pTmp = _PositionService.Retrieve(RetrievePositionArgs);
            //        Partie.Joueur[i].Pion[x].Position.idPosition = pTmp.idPosition;
            //        Partie.Joueur[i].Pion[x].Position.X = pTmp.X;
            //        Partie.Joueur[i].Pion[x].Position.Y = pTmp.Y;
            //        _PionService.Retrieve(RetrievePionArgs);
            //    }
            //}

            //for (int i = 0; i < Partie.Piece.Count; i++)
            //{
            //    Partie.Piece[i].Partie = Partie;
            //    RetrievePositionArgs.X = Partie.Piece[i].Position.X;
            //    RetrievePositionArgs.Y = Partie.Piece[i].Position.Y;
            //    pTmp = _PositionService.Retrieve(RetrievePositionArgs);
            //    Partie.Piece[i].Position.idPosition = pTmp.idPosition;
            //    Partie.Piece[i].Position.X = pTmp.X;
            //    Partie.Piece[i].Position.Y = pTmp.Y;


            //    switch (Partie.Piece[i].Get_Type())
            //    {
            //        case ConstanteGlobale.PIERRE:
            //            _PierreService.Retrieve(RetrievePierreArgs);
            //            break;
            //        case ConstanteGlobale.MONSTRE:
            //            _MonstreService.Retrieve(RetrieveMonstreArgs);
            //            break;
            //        case ConstanteGlobale.CASEDESANG:
            //            _CaseSangService.Retrieve(RetrieveCaseSangArgs);
            //            break;
            //    }
            //}
        }

    }
}
