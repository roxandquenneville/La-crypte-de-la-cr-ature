using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Partie
    {
        #region attribut
        private List<Pointage> listeDePointage;
        private List<Joueur> listeDeJoueur;
        private List<CartesMonstre> listeDeCartes;
        private Historique historiquePartie;
        private Plateau plateauPartie;
 
        private int tourJoueur;

        public virtual int? idPlateau { get; set; }
        public virtual int? idHistorique { get; set; }
        public virtual int? idPointage { get; set; }
        public virtual int? idPartie { get; set; }
        public virtual int? idMouvementMonstre { get; set; }

        public virtual List<Joueur> ListeDeJoueur
        {
            get { return listeDeJoueur;}
            set 
            {   
                listeDeJoueur=value;
            }
        }

        public virtual Historique HistoriquePartie
        {
            get { return historiquePartie; }
            set
            {
                historiquePartie = value;
            }
        }
        public virtual Plateau PlateauPartie
        {
            get { return plateauPartie; }
            set
            {
                plateauPartie = value;
            }
        }


        public virtual List<Pointage> ListeDePointage
        {
            get { return listeDePointage; }
            set
            {
                listeDePointage = value;
            }
        }

        public virtual int TourJoueur
        {
            get { return tourJoueur; }
            set
            {
                tourJoueur = value;
            }
        }

        public virtual List<CartesMonstre> ListeDeCartes
        {
            get { return listeDeCartes; }
            set
            {
                listeDeCartes = value;
            }
        }
        #endregion

        /// <summary>
        /// Constructeur de la classe Partie pour la bd
        /// </summary>
        public Partie()
        {
            ListeDeJoueur = new List<Joueur>();
            HistoriquePartie = new Historique();
            PlateauPartie = new Plateau();
            ListeDePointage = new List<Pointage>();
            ListeDeCartes = new List<CartesMonstre>();
        }



        /// <summary>
        /// Constructeur de la classe partie
        /// </summary>
        /// <param name="nbrJoueur">Nombre de joueur</param>
        /// <param name="nbrPion">Nombre de pion par joueur</param>
        /// <param name="type">Passer un type de plateau</param>
        public Partie(int nbrJoueur,int nbrPion,TypePlateau type)
        {
            ListeDePointage = new List<Pointage>();
            ListeDeJoueur = new List<Joueur>();
            ListeDeCartes = new List<CartesMonstre>();

            for(int i=0;i<nbrJoueur;i++)
            {
                ListeDeJoueur.Add(new Joueur(nbrPion));
                ListeDePointage.Add(new Pointage());
            }

            HistoriquePartie = new Historique();
            PlateauPartie = new Plateau(type);
           
            
        }

        /// <summary>
        /// Déplacement d'un pion
        /// </summary>
        /// <param name="tour"></param>
        /// <param name="joueur">Numéro du joueur</param>
        /// <param name="Pion">Numéro du pion</param>
        /// <param name="Final">Position final</param>
        /// <returns>Retourne un mouvement</returns>
        public virtual void DeplacementDePion(int tour, int joueur, int Pion, Position Final)
        {
            Deplacement mouvement = new Deplacement();

            mouvement.Depart = ListeDeJoueur[joueur-1].ListePion[Pion-1].Emplacement;
            mouvement.Fin = Final;

            if (mouvement.Confirmation(PlateauPartie) == true)
            {
                ListeDeJoueur[joueur-1].ListePion[Pion-1].Emplacement = mouvement.Fin;
               // if (tour == 1)
                //{
               //     ListeDeJoueur[joueur-1].ListePion[Pion-1].EstSortie = false;
               // }
                if (mouvement.Fin.X == 0 && mouvement.Fin.Y == 0)
                {
                    ListeDeJoueur[joueur-1].ListePion[Pion-1].EstSortie = true;
                    ListeDePointage[joueur-1].Point++;
                }
                 ListeDeJoueur[joueur-1].ListePion[Pion-1].TmpDeplacement--;
            }
            else
            {
                ListeDeJoueur[joueur-1].ListePion[Pion-1].Emplacement = mouvement.Depart;
            }
        }


        /*/// <summary>
        /// trouve c'est le tour à qui
        /// </summary>
        /// <returns>Retourne le id du joueur</returns>
        public virtual int DetermineTour()
        {
            int NumJoueur=0;


            return NumJoueur;
        }*/
    }
}
