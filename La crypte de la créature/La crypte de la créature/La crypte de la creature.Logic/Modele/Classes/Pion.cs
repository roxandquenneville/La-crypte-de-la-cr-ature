using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Pion : Piece
    {
        #region attribut
        private bool estVivant;
        private bool estSortie;
        private int valeurDeplacement;
        private const int MAXDEPLACEMENT = 7;

       // public virtual int? idPiece { get; set; }
        public virtual int? idPion { get { return base.idPiece; } set { base.idPiece = value; } }
        public virtual int? idJoueur { get;set; }

        public virtual bool EstVivant
        {
            get { return estVivant; }
            set
            {
                estVivant = value;
            }

        }
        public virtual bool EstSortie
        {
            get { return estSortie; }
            set
            {
                estSortie = value;
            }

        }

        public virtual int ValeurDeplacement
        {
            get { return valeurDeplacement; }
            set
            {
                if (value != 0)
                {

                    valeurDeplacement = value;
                }
            }
        }
        public int tmpDeplacement 
        {
            get { return tmpDeplacement; }
          set
          {
            if(value >0 && value < 8)
            { 
                tmpDeplacement =value;
            }
          }
         }
        #endregion

        /// <summary>
        /// constructeur de la classe Pion
        /// </summary>
        public Pion():base()
        {
        }

        /// <summary>
        /// Constructeur de la classe Pion
        /// </summary>
        /// <param name="posXY">Position du pion</param>
        /// <param name="deplacement">valeur de la première face</param>
        public Pion(int deplacement):base()
        {
            EstVivant=true;
            EstSortie=true;
            valeurDeplacement=deplacement;
            tmpDeplacement=valeurDeplacement;
        }


        /// <summary>
        /// Change la valeurDeplacement
        /// </summary>
        void CalculerFace() 
        {
            ValeurDeplacement = MAXDEPLACEMENT - ValeurDeplacement;
        }

        /// <summary>
        /// Retourne le type
        /// </summary>
        /// <returns>Retourne la string "Pion"</returns>
        public override string Get_Type() { return "Pion"; }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Pion p = obj as Pion;

            if (p == null)
            {
                return false;
            }

            return this.idPion == p.idPion;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
