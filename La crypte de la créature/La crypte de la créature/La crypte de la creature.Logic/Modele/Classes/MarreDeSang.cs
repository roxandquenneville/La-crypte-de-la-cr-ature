using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class MareDeSang
    {
       #region attribut
       private bool forme;

       public virtual List<CaseDeSang> CaseDeSang {get; set;}
       public virtual int? idMareDeSang { get; set; }


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
        /// constructeur de la classe Mare de sang
        /// </summary>
        public MareDeSang()
        {
          CaseDeSang = new List<CaseDeSang>();
        }

       /// <summary>
       /// Constructeur de la classe Mare de sang
       /// </summary>
       /// <param name="bForme">true = en carré  false = en ligne</param>
        public MareDeSang(bool bForme)
        {
            forme = bForme;
            CaseDeSang = new List<CaseDeSang>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            MareDeSang ms = obj as MareDeSang;

            if (ms == null)
            {
                return false;
            }

            return this.idMareDeSang == ms.idMareDeSang;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
