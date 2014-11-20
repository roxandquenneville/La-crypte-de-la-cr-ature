using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cstj.MvvmToolkit.Services;
using La_crypte_de_la_creature.Logic.Services.Interfaces;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Plateau
    {
        #region attribut
        public virtual String type { get; set; }
        public virtual int? idPlateau { get; set; }
        public virtual IList<Case> Case { get;set;}
       
        
        #endregion

        /// <summary>
        /// Constructeur de la classe plateau
        /// </summary>
        public Plateau()
        {
          Case = new List<Case>();
          
        }
        public Plateau(IList<Case> cases)
        {


        }

        /// <summary>
        /// Constructeur de la classe plateau
        /// </summary>
        public Plateau(string nom)
        {
            Case = new List<Case>();

               for(int x=0;x<16;x++)
                {
                    for(int y=0;y<11;y++)
                    {
                        Case.Add(new Case(new Position(x, y), estInterne(x, y,nom)));
                    }
                }
        }


        /// <summary>
        /// Permet de savoir si la case est dans le jeu ou non
        /// </summary>
        /// <param name="x">Emplacement en x</param>
        /// <param name="y">Emplacement en x</param>
        /// <param name="type">type de plateau</param>
        /// <returns></returns>
        public virtual bool estInterne(int x, int y,string type)
        {
            bool Interne = true;

            if (type == "Normal")
            {
                /* x;y tpe plateau 1
                 *bas a gauche x 0-3 y 7-10
                 0;7 | 0;8 | 1;8 | 0;9 | 1;9 | 2;9 | 0;10 | 1;10 | 2;10 | 3;10
             
                 * haut a droite x 12 -15 y 0-3
                  12;0 | 13;0 | 14;0 | 15;0 | 13;1 | 14;1 | 15;1 | 14;2 | 15;2 | 15;3
                 */

                if ((x > -1 && x < 4) &&  (y > 6 && y < 11))
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
                else if((y >-1 && y<4) && (x > 11 && x < 16))
                {
                      // x 12 13 14 15
                      // y 0 1 2 3

                    if((x == 12 && y > 0) || (x == 13 && y> 1) || (x == 14 && y == 3))
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
            return Interne;
        }
        /// <summary>
        /// Vérifie si la case n'est pas dans le plateau ou encore externe
        /// </summary>
        /// <param name="pos">Position à vérifier</param>
        /// <returns>retourne true si la case est présente et non externe sinon retourne false</returns>
        public virtual bool ConfirmationCase(Position pos)
        {
            bool Present = false;
            //vérifie si la case est dans la liste de case du plateau
            foreach (Case item in Case)
            {
                if (item.Coordonnee.X == pos.X && item.Coordonnee.Y == pos.Y)
                {
                    Present = true;
                    //vérifie que le case est interne
                    if (item.Interne == false)
                    {
                        return false;
                    }
                }

            }
            return Present;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Plateau p = obj as Plateau;

            if (p == null)
            {
                return false;
            }

            return this.idPlateau == p.idPlateau;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
