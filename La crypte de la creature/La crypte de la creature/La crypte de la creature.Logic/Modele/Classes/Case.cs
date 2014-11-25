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
        public virtual bool Interne {get; set;}

        public virtual Position Coordonnee 
        { 
            get{return coordonnee;}
            set
            {
                coordonnee=value;
                estInterne(coordonnee.X,coordonnee.Y);
                DetermineImage(coordonnee, Interne);
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
            DetermineImage(Coordonnee, Interne);
           
        }

        /// <summary>
        /// Determine si c'est une pierre,monstre,case,pion,case de sang à afficher. Rentre la valeur dans Url;
        /// </summary>
        /// <param name="pos">Prends la position</param>
        /// <param name="interieur">ici on utilise le bool Interne</param>
        private void DetermineImage(Position pos,bool interieur)
        {
            if (pos.X == 0 && pos.Y == 0)
            {
                Url = "pack://application:,,,/Images/CaseSortie.png";
                return;
            }
            else if (pos.X == 15 && pos.Y == 10)
            {
                Url = "pack://application:,,,/Images/CaseEntree.png";
                return;
            }

            else if (interieur)
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
        public virtual bool estInterne(int x, int y)
        {
                /* x;y
                 *bas a gauche x 0-3 y 7-10
                 0;7 | 0;8 | 1;8 | 0;9 | 1;9 | 2;9 | 0;10 | 1;10 | 2;10 | 3;10
             
                 * haut a droite x 12 -15 y 0-3
                  12;0 | 13;0 | 14;0 | 15;0 | 13;1 | 14;1 | 15;1 | 14;2 | 15;2 | 15;3
                 */

                if ((x > -1 && x < 4) && (y > 6 && y < 11))
                {
                    // x 0 1 2 3
                    // y 7 8 9 10


                    if ((y == 7 && x > 0) || (x == 3 && y < 10) || (x == 2 && y == 8))
                    {
                        // 1;7 | 2;7 | 3;7 | 2;8 |3;8 | 3;9
                        // case interne
                        return true;
                    }
                    else
                    {
                        // 0;7 | 0;8 | 1;8 | 0;9 | 1;9 | 2;9 | 0;10 | 1;10 | 2;10 | 3;10
                        //case externe
                        return false;
                    }
                }
                else if ((y > -1 && y < 4) && (x > 11 && x < 16))
                {
                    // x 12 13 14 15
                    // y 0 1 2 3

                    if ((x == 12 && y > 0) || (x == 13 && y > 1) || (x == 14 && y == 3))
                    {
                        // 12;1 | 12;2 | 12;3 | 13;2 | 13;3 | 14;3 
                        //case interne
                        return true;
                    }
                    else
                    {
                        // 12;0 | 13;0 | 14;0 | 15;0 | 13;1 | 14;1 | 15;1 | 14;2 | 15;2 | 15;3
                        //case externe
                        return false;
                    }

                }
                else
                {
                    return true;
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
