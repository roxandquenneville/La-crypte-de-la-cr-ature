using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_créature.Logic.Modèle.Classes
{
    class CaseDeSang : Piece
    {
        /// <summary>
        /// Constructeur de la classe CaseDeSang
        /// </summary>
        /// <param name="posXY">Position de la case de sang</param>
        public CaseDeSang(Position posXY):base(posXY){ }


        /// <summary>
        /// Retourne le type
        /// </summary>
        /// <returns>Retourne la string "CaseDeSang"</returns>
        public override string Get_Type() { return "CaseDeSang"; }
    }
}
