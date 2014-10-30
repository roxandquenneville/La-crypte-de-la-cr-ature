using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Position
    {
        #region attribut
        private int x;
        private int y;

        public virtual int? idPosition { get; set; }
     
        public virtual int X
        {
            get { return x; }
            set 
            { 
                if(value>=0)
                {
                 x = value;
                }
            }

        }

        public virtual int Y
        {
            get { return y; }
            set
            {
                if (value >= 0)
                {
                    y = value;
                }
            }

        }
        #endregion


        /// <summary>
        /// Constructeur de la classe Position pour la bd
        /// </summary>
        public Position()
        {
            X = 15;
            Y = 10;
        }

        /// <summary>
        /// Constructeur de la classe Position
        /// Prendre information dans la bd et la passer dans le constructeur
        /// </summary>
        /// <param name="posX">Position en x</param>
        /// <param name="posY">Position en y</param>
        public Position(int posX,int posY)
        {
            X=posX;
            Y=posY;
        }

        /// <summary>
        /// Permet de changer la position diriger selon le sens
        /// </summary>
        /// <param name="sens">sens droite gauche monte descent</param>
        /// <param name="pACote">Position à modifier</param>
        /// <returns>Retourne la nouvelle position</returns>
        public virtual void ChangePosition(string sens)
        {
            string test = sens;
            switch (test)
            {
                case ConstanteGlobale.GAUCHE:
                    X = X - 1;
                    break;
                case ConstanteGlobale.DROITE:
                    X = X + 1;
                    break;
                case ConstanteGlobale.MONTE:
                    Y = Y - 1;
                    break;
                case ConstanteGlobale.DESCEND:
                    Y = Y + 1;
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Position p = obj as Position;

            if (p == null)
            {
                return false;
            }

            return this.idPosition == p.idPosition;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
