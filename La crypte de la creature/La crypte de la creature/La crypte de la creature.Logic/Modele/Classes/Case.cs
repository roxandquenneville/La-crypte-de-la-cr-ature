using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Case
    {
        #region attribut
        private Position coordonnee;

        public virtual int? idCase { get; set; }
        public virtual string Url {get; set;}
        public virtual Plateau Plateau { get; set;}
        public virtual bool Interne { get; set;}



        public virtual Position Coordonnee 
        { 
            get{return coordonnee;}
            set
            {
                coordonnee=value;
                
                DetermineImage();
            }
        }
        #endregion

        /// <summary>
        /// Constructeur de la classe Case pour la bd
        /// </summary>
        public Case()
        {
            Coordonnee = new Position();
        }


        /// <summary>
        /// Constructeur de la classe Case
        /// Instancier une position et la passer dans le constructeur
        /// </summary>
        /// <param name="posXY">on passe une position</param>
        /// <param name="bExterne">faux si elle est en dehors du plateau sinon vrai</param>
        public Case(Position posXY)
        {
            Coordonnee = posXY;
            DetermineImage();
           
        }

        /// <summary>
        /// Determine si c'est une pierre,monstre,case,pion,case de sang à afficher. Rentre la valeur dans Url;
        /// </summary>
        /// <param name="pos">Prends la position</param>
        /// <param name="interieur">ici on utilise le bool Interne</param>
        public virtual void DetermineImage()
        {
            estInterne();
            if (Coordonnee.X == 0 && Coordonnee.Y == 0)
            {
                Url = "pack://application:,,,/Images/CaseSortie.png";
                return;
            }
            else if (Coordonnee.X == 15 && Coordonnee.Y == 10)
            {
                Url = "pack://application:,,,/Images/CaseEntree.png";
                return;
            }

            else if (Interne)
            {
                Url = "pack://application:,,,/Images/CaseNormale.png";
                return;
            }
            else
            {
                Url = "pack://application:,,,/Images/CaseGazon.png";
                return;
            }
        }

        /// <summary>
        /// Permet de savoir si la case est dans le jeu ou non
        /// </summary>
        /// <param name="x">Emplacement en x</param>
        /// <param name="y">Emplacement en x</param>
        /// <param name="type">type de plateau</param>
        /// <returns></returns>
        private void estInterne()
        {
                /* x;y
                 *bas a gauche x 0-3 y 7-10
                 0;7 | 0;8 | 1;8 | 0;9 | 1;9 | 2;9 | 0;10 | 1;10 | 2;10 | 3;10
             
                 * haut a droite x 12 -15 y 0-3
                  12;0 | 13;0 | 14;0 | 15;0 | 13;1 | 14;1 | 15;1 | 14;2 | 15;2 | 15;3
                 */

            if ((Coordonnee.X > -1 && Coordonnee.X < 4) && (Coordonnee.Y > 6 && Coordonnee.Y < 11))
                {
                    // x 0 1 2 3
                    // y 7 8 9 10


                    if ((Coordonnee.Y == 7 && Coordonnee.X > 0) || (Coordonnee.X == 3 && Coordonnee.Y < 10) 
                    || (Coordonnee.X == 2 && Coordonnee.Y == 8))
                    {
                        // 1;7 | 2;7 | 3;7 | 2;8 |3;8 | 3;9
                        // case interne
                        Interne= true;
                    }
                    else
                    {
                        // 0;7 | 0;8 | 1;8 | 0;9 | 1;9 | 2;9 | 0;10 | 1;10 | 2;10 | 3;10
                        //case externe
                        Interne = false;
                    }
                }
            else if ((Coordonnee.Y > -1 && Coordonnee.Y < 4) && (Coordonnee.X > 11 && Coordonnee.X < 16))
                {
                    // x 12 13 14 15
                    // y 0 1 2 3

                    if ((Coordonnee.X == 12 && Coordonnee.Y > 0) || (Coordonnee.X == 13 && Coordonnee.Y > 1) 
                    || (Coordonnee.X == 14 && Coordonnee.Y == 3))
                    {
                        // 12;1 | 12;2 | 12;3 | 13;2 | 13;3 | 14;3 
                        //case interne
                        Interne = true;
                    }
                    else
                    {
                        // 12;0 | 13;0 | 14;0 | 15;0 | 13;1 | 14;1 | 15;1 | 14;2 | 15;2 | 15;3
                        //case externe
                        Interne = false;
                    }

                }
                else
                {
                    Interne = true;
                }

            
          
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Case c = obj as Case;

            if (c == null)
            {
                return false;
            }

            return this.idCase == c.idCase;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
