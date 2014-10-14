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
        private bool interne;
        private string url;

        public virtual int? idCase { get; set; }
        public virtual int? idPlateau { get; set; }
        public virtual int? idPosition { get; set; }

        public virtual bool Interne
         {
             get { return interne; }
             set { interne = value; }
        }

        public virtual Position Coordonnee 
        { 
            get{return coordonnee;}
            set
            {
                coordonnee=value;
                DetermineImage(coordonnee, interne);
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
            interne=bInterne;
            DetermineImage(Coordonnee, interne);
           
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
                url = "../La crypte de la créature/Images/CaseSortie.png";
                return;
            }
            if (pos.X == 15 && pos.Y == 10)
            {
                url = "../La crypte de la créature/Images/CaseEntree.png";
                return;
            }

            if (interieur == true)
            {
                url = "../La crypte de la créature/Images/CaseNormale.png";
                return;
            }
            else
            {
                url = "../La crypte de la créature/Images/CaseGazon.png";
                return;
            }
        }

    }
}
