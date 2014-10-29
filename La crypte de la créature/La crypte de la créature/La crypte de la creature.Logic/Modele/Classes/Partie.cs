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
        public virtual void DeplacementDePion(List<Deplacement> ListeTmp, int joueur, int pion, Position Final)
        {
            //Pour supprimer le mouvement
            int index;
            Deplacement mouvement = new Deplacement();
            Position Depart = new Position();
            ListeTmp.Add(mouvement);
            index = ListeTmp.Count();

            mouvement.Depart = Joueur[joueur - 1].Pion[pion - 1].Position;
            mouvement.Fin = Final;

            //Pour mettre le pion sur le plateau
            if (Joueur[joueur - 1].Pion[pion - 1].Position == Depart && Joueur[joueur - 1].Pion[pion - 1].EstVivant == true)
            {
                Joueur[joueur - 1].Pion[pion - 1].EstSortie = false;
            }

            // vérifie le mouvement
            if (mouvement.Confirmation(Plateau, ListeTmp, Joueur[joueur - 1].Pion[pion - 1].TmpDeplacement) == true)
            {
                // change la position du pion
                Joueur[joueur - 1].Pion[pion - 1].Position = mouvement.Fin;

                // Vérifie si le pion est dans la sortie
                if (mouvement.Fin.X == 0 && mouvement.Fin.Y == 0)
                {
                    Joueur[joueur - 1].Pion[pion - 1].EstSortie = true;
                    Pointage[joueur - 1].Point++;
                }
                //Réduit de 1 les points de déplacement
                Joueur[joueur - 1].Pion[pion - 1].TmpDeplacement--;
            }
            //Le mouvement n'est pas valide
            else
            {
                Joueur[joueur - 1].Pion[pion - 1].Position = mouvement.Depart;
                ListeTmp.RemoveAt(index - 1);
            }
        }

        /// <summary>
        /// Lorsqu'on clique sur confirmer, ajoute la liste temporaire dans l'historique
        /// </summary>
        /// <param name="ListeTmp">Liste de déplacement</param>
        /// <param name="joueur">Le numéro de joueur</param>
        /// <param name="pion">Numéro du pion</param>
        /// <returns>Si retourne false le mouvement est illégal,reload les info de la bd
        /// sinon si il est true le mouvement est confirmer on peu ajouter à la bd</returns>
        public virtual bool ConfirmerDeplacementPion(List<Deplacement> ListeTmp, int joueur, int pion)
        {
            Position tmp = new Position();
            List<Piece> pTmp = null;

            tmp = Joueur[joueur-1].Pion[pion-1].Position ;


            pTmp=Plateau.RetournePiece(tmp);

            // si il y plus d'un piece sur la meme position
            if (pTmp.Count > 1)
            {
                int compteur=0;

                foreach(Piece item in pTmp)
                {
                    // Vérifie si il a deux pions
                   if(item.Get_Type() == ConstanteGlobale.PION)
                   {
                        compteur ++;
                   }
                }
                // Il y a deux pion
                if (compteur > 1) 
                { 
                    return false;
                }
                //Le pion est arrêter sur une case de sang
                else
                {
                    Historique.Deplacement.AddRange(ListeTmp);
                    Joueur[joueur - 1].Pion[pion - 1].CalculerFace();
                    return true;
                }
            }
            // Il y a seulement le pion à cette position
            else
            {
                Historique.Deplacement.AddRange(ListeTmp);
                Joueur[joueur-1].Pion[pion-1].CalculerFace();
                return true;
            }

        }

        /// <summary>
        /// Fait les mouvements du monstres
        /// </summary>
        public virtual void MouvementMonstre()
        {
            Monstre monstre= null;
            String sens;

            monstre=Plateau.RetourneMonstre();

            if(!(monstre == null))
            {
                switch(monstre.Orientation)
                {
                    case 1: 
                        sens = ConstanteGlobale.GAUCHE;
                        break;
                    case 2:
                        sens = ConstanteGlobale.MONTE;
                        break;
                    case 3:
                        sens = ConstanteGlobale.DROITE;
                        break;
                    case 4:
                        sens = ConstanteGlobale.DESCEND;
                        break;
                }

            }

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
