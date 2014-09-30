﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_créature.Logic.Modèle.Classes
{
    abstract class Piece : Case
    {
        /// <summary>
        /// Constructeur de piece
        /// </summary>
        /// <param name="posXY">position de la piece</param>
        protected Piece(Position posXY) : base(posXY,true) { }

        /// <summary>
        /// Fonction de déplacement
        /// </summary>
        /// <param name="posDep">Position de départ</param>
        /// <param name="posFin">Position de Fin</param>
        protected void Deplacer(Position posDep,Position posFin) { }

        /// <summary>
        /// fonction pour déterminer si c'est une piece, un monstre,un pion,une pierre,une case de sang
        /// </summary>
        /// <returns>Retourne un string "piece"</returns>
        abstract public string get_type() { return "piece"; }
    }
}
