using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    class CaseDeSang : Piece
    {
        public virtual int? idCaseDeSang { get; set; }
        public virtual int? idMarreDeSang { get; set; }

        /// <summary>
        /// Constructeur de la classe Case De Sang
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
