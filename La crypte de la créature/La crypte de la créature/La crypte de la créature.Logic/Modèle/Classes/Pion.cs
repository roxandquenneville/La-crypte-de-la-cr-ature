﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_créature.Logic.Modèle.Classes
{
    class Pion : Piece
    {
        #region attribut
        public bool EstVivant;
        public bool EstSortie;
        private int valeurDeplacement;

        public int ValeurDeplacement
        {
            get { return valeurDeplacement; }
            set { valeurDeplacement = value; }
        }
        #endregion

        /// <summary>
        /// Constructeur de Pion
        /// </summary>
        /// <param name="posXY">Position du pion</param>
        /// <param name="deplacement">valeur de la première face</param>
        public Pion(Position posXY,int deplacement):base(posXY)
        {
            EstVivant=true;
            EstSortie=true;
            valeurDeplacement=deplacement;
        
        }

        /// <summary>
        /// Change la valeurDeplacement
        /// </summary>
        void CalculerFace() { }
    }
}
