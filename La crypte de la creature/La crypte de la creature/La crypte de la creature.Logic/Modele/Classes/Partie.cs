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
        public virtual IList<Piece> Piece { get; set; }


        public virtual int TourJoueur
        {
            get { return tourJoueur; }
            set
            {
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
            Piece = new List<Piece>();

            //met liste pion dans plateau
            List<Piece> listeTmp = new List<Piece>();

            foreach (Joueur item in Joueur)
            {
                listeTmp.AddRange(item.Pion);
            }
            ((List<Piece>)Piece).AddRange(listeTmp);
        }

        /// <summary>
        /// Constructeur de la classe partie
        /// </summary>
        /// <param name="nbrJoueur">Nombre de joueur</param>
        /// <param name="nbrPion">Nombre de pion par joueur</param>
        /// <param name="type">Passer un type de plateau</param>
        public Partie(int nbrJoueur, int nbrPion, String type)
        {
            Pointage = new List<Pointage>();
            Joueur = new List<Joueur>();
            CartesMonstre = new List<CartesMonstre>();
            Piece = new List<Piece>();

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
            Plateau = new Plateau("Normal");

            //Selon la page 3 du manuel
            //Ajout des pierres
            Piece.Add(new Pierre(new Position(2, 2), true));
            Piece.Add(new Pierre(new Position(4, 7), true));
            Piece.Add(new Pierre(new Position(5, 9), true));
            Piece.Add(new Pierre(new Position(6, 6), true));
            Piece.Add(new Pierre(new Position(7, 4), true));
            Piece.Add(new Pierre(new Position(8, 5), true));
            Piece.Add(new Pierre(new Position(8, 9), true));
            Piece.Add(new Pierre(new Position(12, 3), true));
            Piece.Add(new Pierre(new Position(12, 7), true));
            Piece.Add(new Pierre(new Position(13, 5), true));
            Piece.Add(new Pierre(new Position(14, 8), true));

            //Ajout des cases de sang
            Piece.Add(new CaseDeSang(new Position(8, 2)));
            Piece.Add(new CaseDeSang(new Position(8, 3)));
            Piece.Add(new CaseDeSang(new Position(9, 2)));
            Piece.Add(new CaseDeSang(new Position(9, 3)));
            Piece.Add(new CaseDeSang(new Position(4, 8)));
            Piece.Add(new CaseDeSang(new Position(5, 8)));
            Piece.Add(new CaseDeSang(new Position(6, 8)));
            Piece.Add(new CaseDeSang(new Position(7, 8)));

            //Ajout du monstre
            Piece.Add(new Monstre(new Position(0, 0), 2));

            //met liste pion dans plateau
            List<Piece> listeTmp = new List<Piece>();

            foreach (Joueur item in Joueur)
            {
                listeTmp.AddRange(item.Pion);
            }
            ((List<Piece>)Piece).AddRange(listeTmp);
        }

        /// <summary>
        /// Déplacement d'un pion
        /// </summary>
        /// <param name="ListeTmp">Liste de déplacement temporaire</param>
        /// <param name="joueur">Numéro du joueur</param>
        /// <param name="Pion">Numéro du pion</param>
        /// <param name="Final">Position final</param>
        /// <returns>Retourne un mouvement</returns>
        public virtual void DeplacementDePion(List<Deplacement> ListeTmp, int joueur, int pion,string sens)
        {
           // if (Joueur[joueur].Pion[pion].TmpDeplacement <= 0)
            //{
               // return;
           // }

            //Pour supprimer le mouvement
            int index;
            Deplacement mouvement = new Deplacement();
            Position Depart = new Position();
            Pion pionDeplacer = Joueur[joueur].Pion[pion];

            ListeTmp.Add(mouvement);
            index = ListeTmp.Count();

            mouvement.Depart.X = pionDeplacer.Position.X;
            mouvement.Depart.Y = pionDeplacer.Position.Y;
            mouvement.Fin.X = mouvement.Depart.X;
            mouvement.Fin.Y = mouvement.Depart.Y;

            mouvement.Fin.ChangePosition(sens);

            //Pour mettre le pion sur le plateau
            if (pionDeplacer.Position == Depart && pionDeplacer.EstVivant == true)
            {
                pionDeplacer.EstSortie = false;
            }

            // vérifie le mouvement
            if (mouvement.Confirmation(this, ListeTmp, pionDeplacer.TmpDeplacement, sens) == true)
            {
                mouvement.Piece = pionDeplacer;
                // change la position du pion
                pionDeplacer.Position.X = mouvement.Fin.X;
                pionDeplacer.Position.Y = mouvement.Fin.Y;

                // Vérifie si le pion est dans la sortie
                if (mouvement.Fin.X == 0 && mouvement.Fin.Y == 0)
                {
                    pionDeplacer.EstSortie = true;
                    Pointage[joueur].Point++;
                }
                //Réduit de 1 les points de déplacement
                pionDeplacer.TmpDeplacement--;
            }
            //Le mouvement n'est pas valide
            else
            {
                pionDeplacer.Position.X = mouvement.Depart.X;
                pionDeplacer.Position.Y = mouvement.Depart.Y;
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

            tmp = Joueur[joueur-1].Pion[pion].Position ;


            pTmp=RetournePiece(tmp);

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
                    ListeTmp.Clear();
                    return false;
                }
                //Le pion est arrêter sur une case de sang
                else
                {
                    ((List<Deplacement>)Historique.Deplacement).AddRange(ListeTmp);
                    Joueur[joueur - 1].Pion[pion].CalculerFace();
                    TourJoueur++;
                    ListeTmp.Clear();
                    return true;
                }
            }
            // Il y a seulement le pion à cette position
            else
            {
                ((List<Deplacement>)Historique.Deplacement).AddRange(ListeTmp);
                Joueur[joueur-1].Pion[pion].CalculerFace();
                TourJoueur++;
                ListeTmp.Clear();
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

            monstre=RetourneMonstre();

            tmp.Depart.X = monstre.Position.X;
            tmp.Depart.Y = monstre.Position.Y;
            tmp.Fin.X = tmp.Depart.X;
            tmp.Fin.Y = tmp.Depart.Y;

            if(!(monstre == null))
            {
                //for(int i=0;i<5;i++)
               // { 
                    sens = monstre.VisionMonstre(this);
                    monstre.ChangeOrientation(sens);
                    tmp.MonstreDeplacement(this, sens);
                    monstre.Position.X = tmp.Fin.X;
                    monstre.Position.Y = tmp.Fin.Y;
               // }
              
            }

            //Fin de partie
            pion = Retournepion();
           
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


        /// <summary>
        /// Vérifie s'il y a une piece à la position passé
        /// </summary>
        /// <param name="pos">Position à vérifier</param>
        /// <returns>Retourne true si y a une piece, sinon retourne false</returns>
        protected virtual bool ConfirmationPiece(Position pos)
        {
            bool Present = false;
            //vérifier la case et si cest une pierre vérifier la case derriere
            //si c une mare de sang changer position de fin
            foreach (Piece item in Piece)
            {
                if (item.Position.X == pos.X && item.Position.Y == pos.Y)
                {
                    Present = true;
                }
            }
            return Present;
        }

        /// <summary>
        /// Retourne la piece 
        /// </summary>
        /// <param name="pos">Position à vérifier</param>
        /// <returns>Retourne la ou les piece, s'il n'en a pas retourne null</returns>
        public virtual List<Piece> RetournePiece(Position pos)
        {
            List<Piece> tmp = new List<Piece>();
            if (ConfirmationPiece(pos))
            {
                foreach (Piece item in Piece)
                {
                    if (item.Position.X == pos.X && item.Position.Y == pos.Y)
                    {
                        tmp.Add(item);
                    }
                }
            }
            return tmp;
        }

        /// <summary>
        /// Retourne la piece monstre
        /// </summary>
        /// <returns>Si il retourne null le monstre n'est pas dans le plateau</returns>
        public virtual Monstre RetourneMonstre()
        {
            foreach (Piece item in Piece)
            {
                if (item.Get_Type() == "Monstre")
                {
                    return (Monstre)item;
                }
            }
            return null;
        }

        public virtual List<Pion> Retournepion()
        {
            List<Pion> lPion = new List<Pion>();
            foreach (Piece item in Piece)
            {
                if (item.Get_Type() == "Pion")
                {
                    lPion.Add((Pion)item);
                }
            }
            return lPion;
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
