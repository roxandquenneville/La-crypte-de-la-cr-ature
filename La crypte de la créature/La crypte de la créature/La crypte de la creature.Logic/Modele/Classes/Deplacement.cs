using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Deplacement
    {
        #region attribut
        private Position depart;
        private Position fin;

        public virtual int? IdDeplacement { get; set; }
        public virtual Partie Partie { get; set; }
        public virtual Piece Piece { get; set; }
        public virtual Historique Historique { get; set; }
        public virtual Position Depart {get; set; }
        public virtual Position Fin { get; set;}
      
        #endregion


        /// <summary>
        /// Constructeur de la classe Deplacement pour la bd
        /// </summary>
        public Deplacement()
        {
            Depart = new Position();
            Fin = new Position();
        }


        /// <summary>
        /// Constructeur de la classe deplacement
        /// Instancier deux positions et la passer dans le constructeur
        /// </summary>
        /// <param name="posDepart">Position de départ</param>
        /// <param name="posFin">Position de Fin</param>
        public Deplacement(Position posDepart,Position posFin)
        {
            Depart=posDepart;
            Fin=posFin;
        }

        /// <summary>
        /// Confirme le mouvement. 
        /// La fonction est Private ,car elle est appeler seulement dans la classe déplacement par une autre fonction
        /// </summary>
        /// <returns>Retourne vrai si le déplacement est valide sinon retourne faux</returns>
        public virtual bool Confirmation()
        {
            bool Valide = true;
            string type;
            Piece pTmp;
            Case cTmp;

            cTmp = Partie.Plateau.Case.Find(x => x.Coordonnee == Fin);

            if (cTmp == null)
            {
                return false;
            }

            //vérifier la case et si cest une pierre vérifier la case derriere
            //si c une mare de sang changer position de fin
            pTmp = Partie.Plateau.Piece.Find(x => x.Position == Fin);

            if (pTmp == null)
            {
                return true;
            }
            else
            {
                type = pTmp.Get_Type();

                switch (type)
                {
                    case "Pierre":
                        Console.WriteLine("Case 1");
                        break;
                    case "CaseDeSang":
                        Console.WriteLine("Case 2");
                        break;
                    case "Monstre":
                        return false;
                       
                }

            }



            return Valide;
        }

       

    }
}
