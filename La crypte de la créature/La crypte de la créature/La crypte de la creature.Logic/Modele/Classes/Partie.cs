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
        public virtual Plateau Plateau { get; set; }
        public virtual Historique Historique { get; set; }
        public virtual List<Pointage> Pointage { get; set; }
        public virtual List<CartesMonstre> CartesMonstre { get; set; }
        public virtual List<Joueur> Joueur { get; set; }


        public virtual int TourJoueur
        {
            get { return tourJoueur; }
            set
            {
                if (value == Joueur.Count() * Joueur[0].Pion.Count())
                {
                    MouvementMonstre();
                    tourJoueur = 0;
                }
                else
                {
                    tourJoueur = value;
                }
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

            //met liste pion dans plateau
            List<Piece> listeTmp = new List<Piece>();

            foreach (Joueur item in Joueur)
            {
                listeTmp.AddRange(item.Pion);
            }
            Plateau.Piece.AddRange(listeTmp);
        }

        /// <summary>
        /// Constructeur de la classe partie
        /// </summary>
        /// <param name="nbrJoueur">Nombre de joueur</param>
        /// <param name="nbrPion">Nombre de pion par joueur</param>
        /// <param name="type">Passer un type de plateau</param>
        public Partie(int nbrJoueur, int nbrPion, TypePlateau type)
        {
            Pointage = new List<Pointage>();
            Joueur = new List<Joueur>();
            CartesMonstre = new List<CartesMonstre>();

            for (int i = 0; i < nbrJoueur; i++)
            {
                Joueur.Add(new Joueur(nbrPion));
                Pointage.Add(new Pointage());
            }

            Historique = new Historique();
            Plateau = new Plateau(type);

            //met liste pion dans plateau
            List<Piece> listeTmp = new List<Piece>();

            foreach (Joueur item in Joueur)
            {
                listeTmp.AddRange(item.Pion);
            }
            Plateau.Piece.AddRange(listeTmp);

        }

        /// <summary>
        /// Déplacement d'un pion
        /// </summary>
        /// <param name="ListeTmp">Liste de déplacement temporaire</param>
        /// <param name="joueur">Numéro du joueur</param>
        /// <param name="Pion">Numéro du pion</param>
        /// <param name="Final">Position final</param>
        /// <returns>Retourne un mouvement</returns>
        public virtual void DeplacementDePion(List<Deplacement> ListeTmp, int joueur, int Pion, Position Final)
        {
            //Pour supprimer le mouvement
            int index;
            Deplacement mouvement = new Deplacement();
            Position Depart = new Position();
            ListeTmp.Add(mouvement);
            index = ListeTmp.Count();

            mouvement.Depart = Joueur[joueur - 1].Pion[Pion - 1].Position;
            mouvement.Fin = Final;

            if (Joueur[joueur - 1].Pion[Pion - 1].Position == Depart && Joueur[joueur - 1].Pion[Pion - 1].EstVivant == true)
            {
                Joueur[joueur - 1].Pion[Pion - 1].EstSortie = false;
            }

            if (mouvement.Confirmation(Plateau, ListeTmp, Joueur[joueur - 1].Pion[Pion - 1].TmpDeplacement) == true)
            {
                Joueur[joueur - 1].Pion[Pion - 1].Position = mouvement.Fin;

                if (mouvement.Fin.X == 0 && mouvement.Fin.Y == 0)
                {
                    Joueur[joueur - 1].Pion[Pion - 1].EstSortie = true;
                    Pointage[joueur - 1].Point++;
                }
                Joueur[joueur - 1].Pion[Pion - 1].TmpDeplacement--;
            }
            else
            {
                Joueur[joueur - 1].Pion[Pion - 1].Position = mouvement.Depart;
                ListeTmp.RemoveAt(index - 1);
            }
        }

        /// <summary>
        /// fait les mouvements du monstres
        /// </summary>
        public virtual void MouvementMonstre()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Partie p = obj as Partie;

            if (p == null)
            {
                return false;
            }

            return this.idPartie == p.idPartie;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
