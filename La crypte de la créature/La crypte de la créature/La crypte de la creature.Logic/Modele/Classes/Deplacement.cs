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
        public virtual bool Confirmation(Plateau plateau)
        {
            bool Valide = true;
            bool Present = false;
            string type;
            Piece pTmp = null;

            foreach (Case item in plateau.Case)
            {
                if (item.Coordonnee.X == Fin.X && item.Coordonnee.Y == Fin.Y)
                {
                    Present = true;
                    //vérifie que le case est interne
                    if (item.Interne == false)
                    {
                        return false;
                    }
                }

            }
            //La case n'existe pas
            if (Present == false)
            {
                return false;
            }

            //reset ma variable
            Present = false;

            //vérifier la case et si cest une pierre vérifier la case derriere
            //si c une mare de sang changer position de fin
            foreach (Piece item in plateau.Piece)
            {
                if (item.Position.X == Fin.X && item.Position.Y == Fin.Y)
                {
                    Present = true;
                    pTmp = item;
                }
            }
            //il n'y a pas de piece
            if (Present == false)
            {
                return true;
            }
            else
            {
                type = pTmp.Get_Type();
                string sens;

                if ((Depart.X - Fin.X) > 0)
                {
                    sens = "gauche";
                }
                if ((Depart.X - Fin.X) < 0)
                {
                    sens = "droite";
                }
                if ((Depart.Y - Fin.Y) > 0)
                {
                    sens = "monte";
                }
                if ((Depart.Y - Fin.Y) < 0)
                {
                    sens = "descent";
                }

                switch (type)
                {
                    case "Pierre":

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
