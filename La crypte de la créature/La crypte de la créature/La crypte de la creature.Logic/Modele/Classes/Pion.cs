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
        private int valeurDeplacement;
        private int tmpDeplacement;
        private const int MAXDEPLACEMENT = 7;

        public virtual int? idPion { get { return base.idPiece; } set { base.idPiece = value; } }
        public virtual Joueur Joueur {get; set;}
        public virtual bool EstVivant{get;set;}
        public virtual bool EstSortie { get;set;}

        public virtual int ValeurDeplacement
        {
            get { return valeurDeplacement; }
            set
            {
                if (value > 0)
                {
                    valeurDeplacement = value;
                }
               TmpDeplacement=ValeurDeplacement;
            }
        }
        public virtual int TmpDeplacement 
        {
            get { return tmpDeplacement; }
          set
          {
            if(value >-1 && value < 8)
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
            TmpDeplacement=valeurDeplacement;
        }


        /// <summary>
        /// Change la valeurDeplacement
        /// </summary>
        public virtual void CalculerFace() 
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
