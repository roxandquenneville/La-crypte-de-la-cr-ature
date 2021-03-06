﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class CaseDeSang : Piece
    {
        
        public virtual int? idCaseDeSang { get { return base.idPiece; } set { base.idPiece = value; } }
        public virtual MareDeSang MareDeSang { get; set;}


        /// <summary>
        /// constructeur de la classe case de sang
        /// </summary>
        public CaseDeSang():base()
        {
        }


        /// <summary>
        /// Constructeur de la classe Case De Sang
        /// </summary>
        /// <param name="posXY">Position de la case de sang</param>
        public CaseDeSang(Position posXY):base(posXY){
            DetermineImage();
         }


        /// <summary>
        /// Retourne le type
        /// </summary>
        /// <returns>Retourne la string "CaseDeSang"</returns>
        public override string Get_Type() { return ConstanteGlobale.CASEDESANG; }


        /// <summary>
        /// Determine l'image de la case de sang
        /// </summary>
        public override void DetermineImage()
        {
            Url = "pack://application:,,,/Images/CaseMareDeSang.png";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            CaseDeSang cs = obj as CaseDeSang;

            if (cs == null)
            {
                return false;
            }

            return this.idCaseDeSang == cs.idCaseDeSang;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
