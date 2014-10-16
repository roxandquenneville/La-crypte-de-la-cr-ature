using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Plateau
    {
        #region attribut
        private List<Case> listeCase;
        private List<Piece> listePiece;

        public virtual int? idPlateau { get; set; }
        public virtual int? idTypePlateau { get; set; }

        public List<Piece> ListePiece
        {
            get {return listePiece;}

            set 
            { 
               listePiece = value;
            }
        }
       


        public List<Case> ListeCase
        {
            get {return listeCase;}

            set 
            { 
               listeCase = value;
            }
        }
        #endregion

        /// <summary>
        /// Constructeur de la classe plateau
        /// </summary>
        public Plateau()
        {
          ListeCase = new List<Case>();
          ListePiece = new List<Piece>();
        }

        /// <summary>
        /// Constructeur de la classe plateau
        /// </summary>
        public Plateau(TypePlateau type)
        {
            ListeCase = new List<Case>();
            ListePiece = new List<Piece>();
            if (type.NomDePlateau == "Normal")
            {
               for(int x=0;x<16;x++)
                {
                    for(int y=0;y<11;y++)
                    {
                        ListeCase.Add(new Case(new Position(x, y), estInterne(x, y, type.NomDePlateau)));
                    }
                }

                //Selon la page 3 du manuel
                //Ajout des pierres
                ListePiece.Add(new Pierre(new Position(2,2),true));
                ListePiece.Add(new Pierre(new Position(4,7), true));
                ListePiece.Add(new Pierre(new Position(5,9), true));
                ListePiece.Add(new Pierre(new Position(6,6), true));
                ListePiece.Add(new Pierre(new Position(7,4), true));
                ListePiece.Add(new Pierre(new Position(8,5), true));
                ListePiece.Add(new Pierre(new Position(8,9), true));
                ListePiece.Add(new Pierre(new Position(12,3), true));
                ListePiece.Add(new Pierre(new Position(12,7), true));
                ListePiece.Add(new Pierre(new Position(13,5), true));
                ListePiece.Add(new Pierre(new Position(14,8), true));

                //Ajout des cases de sang
                ListePiece.Add(new CaseDeSang(new Position(8,2)));
                ListePiece.Add(new CaseDeSang(new Position(8,3)));
                ListePiece.Add(new CaseDeSang(new Position(9,2)));
                ListePiece.Add(new CaseDeSang(new Position(9,3)));
                ListePiece.Add(new CaseDeSang(new Position(4,8)));
                ListePiece.Add(new CaseDeSang(new Position(5,8)));
                ListePiece.Add(new CaseDeSang(new Position(6,8)));
                ListePiece.Add(new CaseDeSang(new Position(7,8)));

                //Ajout du monstre
                ListePiece.Add(new Monstre(new Position(0,0),2));
            }

        }


        /// <summary>
        /// Permet de savoir si la case est dans le jeu ou non
        /// </summary>
        /// <param name="x">Emplacement en x</param>
        /// <param name="y">Emplacement en x</param>
        /// <param name="type">type de plateau</param>
        /// <returns></returns>
        private bool estInterne(int x, int y,string type)
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

    }
}
