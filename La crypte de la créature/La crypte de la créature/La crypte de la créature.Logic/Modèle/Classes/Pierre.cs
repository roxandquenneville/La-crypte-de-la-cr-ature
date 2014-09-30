using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_créature.Logic.Modèle.Classes
{
    class Pierre : Piece
    {
        #region attribut
        private bool estSurPlateau;

        public bool EstSurPlateau
        {
            get {return estSurPlateau;}
            set {
                    //TODO: Vérifie que sa position est en jeu
                    estSurPlateau=value;
                 }

        }
        #endregion

        /// <summary>
        /// Constructeur de pierre
        /// </summary>
        /// <param name="posXY">position de la pierre</param>
        /// <param name="enJeu">Vrai si la pierre est en jeu sinon faux </param>
        public Pierre(Position posXY, bool enJeu):base(posXY)
        {
            EstSurPlateau=enJeu;
        }
    }
}
