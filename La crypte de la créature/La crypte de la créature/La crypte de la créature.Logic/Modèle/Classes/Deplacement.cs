﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_créature.Logic.Modèle.Classes
{
    class Deplacement
    {
        #region attribut
        private Position depart;
        private Position fin;
        #endregion

        /// <summary>
        /// Constructeur de la classe deplacement
        /// Instancier deux positions et la passer dans le constructeur
        /// </summary>
        /// <param name="posDepart">Position de départ</param>
        /// <param name="posFin">Position de Fin</param>
        public Deplacement(Position posDepart,Position posFin)
        {
            depart=posDepart;
            fin=posFin;
        }

        /// <summary>
        /// Confirme le mouvement. 
        /// La fonction est Private ,car elle est appeler seulement dans la classe déplacement par une autre fonction
        /// </summary>
        /// <returns>Retourne vrai si le déplacement est valide sinon retourne faux</returns>
        private bool Confirmation()
        {
            bool Valide=true;

            return Valide;
        }

        /// <summary>
        /// Fonction que fait le mouvement
        /// </summary>
        /// <returns>Retourne la position passer de fin si le mouvement 
        /// est valide sinon retour le position de départ</returns>
        public Position EffectuerDeplacement()
        {
            

            return fin;
        }

    }
}
