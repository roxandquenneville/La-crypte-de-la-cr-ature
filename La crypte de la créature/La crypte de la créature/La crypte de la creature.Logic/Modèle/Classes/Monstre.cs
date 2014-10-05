using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modèle.Classes
{
    class Monstre : Piece
    {
        #region attribut
        private int orientation;

        public virtual int? idMonstre { get; set; }

        public virtual int Orientation
        {
            get { return orientation; }
            set 
            {
                if (value > 0 && value < 4)
                {
                    orientation = value;
                }
            }

        }
        #endregion

        /// <summary>
        /// Constructeur de la classe monstre
        /// </summary>
        /// <param name="posXY">Position du monstre</param>
        /// <param name="Sens">LE sens du monstre 0 = gauche 1 = haut 2 = droite 3 = bas</param>
        public Monstre(Position posXY, int Sens): base(posXY)
        {
            Orientation = Sens;
        }

        /// <summary>
        /// Determine quel monstre sera prit
        /// </summary>
        /// <returns>retourne le nom du monstre utilisé</returns>
        public string DeterminerMonstre()
        {
            string nom="";
            
            return nom;
        }

        /// <summary>
        /// Retourne le type
        /// </summary>
        /// <returns>Retourne la string "Monstre"</returns>
        public override string Get_Type() { return "Monstre"; }
    }
}
