using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Monstre : Piece
    {
        #region attribut
        private int orientation;

        //public virtual int? idPiece { get; set; }
        public virtual int? idMonstre { get { return base.idPiece; } set { base.idPiece = value; } }

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
        /// constructeur de la classe Pion
        /// </summary>
        public Monstre():base()
        {
        }


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
        public virtual string DeterminerMonstre()
        {
            string nom="";
            
            return nom;
        }

        /// <summary>
        /// Retourne le type
        /// </summary>
        /// <returns>Retourne la string "Monstre"</returns>
        public override string Get_Type() { return "Monstre"; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Monstre m = obj as Monstre;

            if (m == null)
            {
                return false;
            }

            return this.idMonstre == m.idMonstre;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
