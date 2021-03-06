﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public abstract class Piece
    {
        public virtual string Url {get; set;}

        public virtual int? idPiece { get; set; }
        public virtual Position Position { get; set;}
        public virtual Partie Partie { get; set;}

        /// <summary>
        /// constructeur de base de la classe piece
        /// </summary>
        public Piece()
        {
            Position = new Position();
            Partie = new Partie();
        }


        /// <summary>
        /// Constructeur de la classe piece
        /// </summary>
        /// <param name="posXY">position de la piece</param>
        protected  Piece(Position posXY)
        {
            Position = posXY;
            Partie = new Partie();
        }

        /// <summary>
        /// fonction pour déterminer si c'est une piece, un monstre,un pion,une pierre,une case de sang
        /// </summary>
        /// <returns>Retourne la string "Piece"</returns>
        public virtual string Get_Type() { return "Piece"; }


        public virtual void DetermineImage() { }




        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Piece p = obj as Piece;

            if (p == null)
            {
                return false;
            }

            return this.idPiece == p.idPiece;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
