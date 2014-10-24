using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class MarreDeSang
    {
       #region attribut
       private bool forme;

       public virtual List<CaseDeSang> CaseDeSang {get; set;}
       public virtual int? idMarreDeSang { get; set; }


       public virtual bool Forme
       {
           get { return forme; }
           set
           {
               forme = value;
           }
       }
       #endregion

        /// <summary>
        /// constructeur de la classe Marre de sang
        /// </summary>
        public MarreDeSang()
        {
          CaseDeSang = new List<CaseDeSang>();
        }

       /// <summary>
       /// Constructeur de la classe Marre de sang
       /// </summary>
       /// <param name="bForme">true = en carré  false = en ligne</param>
        public MarreDeSang(bool bForme)
        {
            forme = bForme;
            CaseDeSang = new List<CaseDeSang>();
        }

    }
}
