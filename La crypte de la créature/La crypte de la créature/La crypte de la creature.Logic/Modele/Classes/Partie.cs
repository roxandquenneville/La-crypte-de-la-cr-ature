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

        private int tourJoueur;

        public virtual int? idPartie { get; set; }
        public virtual Plateau Plateau{get; set;}
        public virtual Historique Historique { get; set; }
        public virtual List<Pointage> Pointage {get; set;}
        public virtual List<CartesMonstre> CartesMonstre { get;set;}
        public virtual List<Joueur> Joueur { get; set;}


        public virtual int TourJoueur
        {
            get { return tourJoueur; }
            set
            {
                //if(value >)
                tourJoueur = value;
            }
        }
        #endregion

       

        /// <summary>
        /// Constructeur de la classe Partie pour la bd
        /// </summary>
        public Partie()
        {
            Joueur = new List<Joueur>();
            Historique = new Historique();
            Plateau = new Plateau();
            Pointage = new List<Pointage>();
            CartesMonstre = new List<CartesMonstre>();
        }



        /// <summary>
        /// Constructeur de la classe partie
        /// </summary>
        /// <param name="nbrJoueur">Nombre de joueur</param>
        /// <param name="nbrPion">Nombre de pion par joueur</param>
        /// <param name="type">Passer un type de plateau</param>
        public Partie(int nbrJoueur,int nbrPion,TypePlateau type)
        {
            Pointage = new List<Pointage>();
            Joueur = new List<Joueur>();
            CartesMonstre = new List<CartesMonstre>();

            for(int i=0;i<nbrJoueur;i++)
            {
                Joueur.Add(new Joueur(nbrPion));
                Pointage.Add(new Pointage());
            }

            Historique = new Historique();
            Plateau = new Plateau(type);
           
            
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

            mouvement.Depart = Joueur[joueur-1].Pion[Pion-1].Emplacement;
            mouvement.Fin = Final;

            if (mouvement.Confirmation() == true)
            {
                Joueur[joueur-1].Pion[Pion-1].Emplacement = mouvement.Fin;
               // if (tour == 1)
                //{
               //     ListeDeJoueur[joueur-1].ListePion[Pion-1].EstSortie = false;
               // }
                if (mouvement.Fin.X == 0 && mouvement.Fin.Y == 0)
                {
                    Joueur[joueur-1].Pion[Pion-1].EstSortie = true;
                    Pointage[joueur-1].Point++;
                }
                 Joueur[joueur-1].Pion[Pion-1].TmpDeplacement--;
            }
            else
            {
                Joueur[joueur-1].Pion[Pion-1].Emplacement = mouvement.Depart;
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
