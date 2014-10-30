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
        public Case(Position posXY,bool bInterne)
        {
            Coordonnee = posXY;
            Interne=bInterne;
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
                Url = "../La crypte de la créature/Images/CaseSortie.png";
                return;
            }
            if (pos.X == 15 && pos.Y == 10)
            {
                Url = "../La crypte de la créature/Images/CaseEntree.png";
                return;
            }

            if (interieur)
            {
                Url = "../La crypte de la créature/Images/CaseNormale.png";
                return;
            }
            else
            {
                Url = "../La crypte de la créature/Images/CaseGazon.png";
                return;
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
