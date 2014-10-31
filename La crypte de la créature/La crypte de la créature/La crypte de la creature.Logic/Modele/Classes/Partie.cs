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
        public virtual List<Joueur> Joueur { get;  set; }


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

            /*//prend la taille du tableau
            int tmp=ConstanteGlobale.VALEURDEPLACEMENTMONSTRE.Length;

            // Prend un nombre random
            Random RdmDeplacement = new Random();
            int[] tabDeplacement = new int[nbrPion];

            for (int i = 0; i < nbrPion; i++)
            {
                // prend une valeur aléatoire entre 0 et la taille du tableau
                tabDeplacement[i] = RdmDeplacement.Next(0,tmp);

                //vérifie s'il y a des double
                while()
                {
                
                }

                CartesMonstre.Add(new CartesMonstre(ConstanteGlobale.VALEURDEPLACEMENTMONSTRE[tabDeplacement[i]]));
            }*/


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

            mouvement.Depart.X = Joueur[joueur - 1].Pion[pion].Position.X;
            mouvement.Depart.Y = Joueur[joueur - 1].Pion[pion].Position.Y;
            mouvement.Fin = Final;

            //Pour mettre le pion sur le plateau
            if (Joueur[joueur - 1].Pion[pion].Position == Depart && Joueur[joueur - 1].Pion[pion].EstVivant == true)
            {
                Joueur[joueur - 1].Pion[pion].EstSortie = false;
            }

            // vérifie le mouvement
            if (mouvement.Confirmation(Plateau, ListeTmp, Joueur[joueur - 1].Pion[pion].TmpDeplacement) == true)
            {
                // change la position du pion
                Joueur[joueur - 1].Pion[pion].Position = mouvement.Fin;

                // Vérifie si le pion est dans la sortie
                if (mouvement.Fin.X == 0 && mouvement.Fin.Y == 0)
                {
                    Joueur[joueur - 1].Pion[pion].EstSortie = true;
                    Pointage[joueur - 1].Point++;
                }
                //Réduit de 1 les points de déplacement
                Joueur[joueur - 1].Pion[pion].TmpDeplacement--;
            }
            //Le mouvement n'est pas valide
            else
            {
                Joueur[joueur - 1].Pion[pion].Position = mouvement.Depart;
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
                    ListeTmp =null;
                    return false;
                }
                //Le pion est arrêter sur une case de sang
                else
                {
                    Historique.Deplacement.AddRange(ListeTmp);
                    Joueur[joueur - 1].Pion[pion - 1].CalculerFace();
                    TourJoueur++;
                    ListeTmp = null;
                    return true;
                }
            }
            // Il y a seulement le pion à cette position
            else
            {
                Historique.Deplacement.AddRange(ListeTmp);
                Joueur[joueur-1].Pion[pion-1].CalculerFace();
                TourJoueur++;
                ListeTmp = null;
                return true;
            }

        }

        /// <summary>
        /// Fait les mouvements du monstres
        /// </summary>
        public virtual void MouvementMonstre()
        {
            Monstre monstre=null;
            List<Pion> pion= null;
            String sens=null;
            Deplacement tmp = new Deplacement();

            Historique.Deplacement.Add(tmp);

            monstre=Plateau.RetourneMonstre();

            tmp.Depart = monstre.Position;
            tmp.Fin = tmp.Depart;
            

            if(!(monstre == null))
            {
                switch(monstre.Orientation)
                {
                    case 1: 
                        monstre.VisionMonstre(sens,Plateau);
                        tmp.Fin.ChangePosition(sens);
                        tmp.MonstreDeplacement(Plateau,sens);
                        monstre.Position = tmp.Fin;
                        break;
                    case 2:
                        monstre.VisionMonstre(sens, Plateau);
                        tmp.Fin.ChangePosition(sens);
                        tmp.MonstreDeplacement(Plateau,sens);
                        monstre.Position = tmp.Fin;
                        break;
                    case 3:
                        monstre.VisionMonstre(sens, Plateau);
                        tmp.Fin.ChangePosition(sens);
                        tmp.MonstreDeplacement(Plateau,sens);
                        monstre.Position = tmp.Fin;
                        break;
                    case 4:
                        monstre.VisionMonstre(sens, Plateau);
                        tmp.Fin.ChangePosition(sens);
                        tmp.MonstreDeplacement(Plateau,sens);
                        monstre.Position = tmp.Fin;
                        break;
                }

              
            }
            pion = Plateau.Retournepion();
            bool verification = false;
            foreach(Pion item in pion)
            {
               if(item.EstSortie==false && item.EstVivant== true)
               {
                    verification = true;
                    break;
               }
            }
            if(verification == false)
            {
                //les joueurs sont soient tous mort, tous sorti ou une combinaison des deux  
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
