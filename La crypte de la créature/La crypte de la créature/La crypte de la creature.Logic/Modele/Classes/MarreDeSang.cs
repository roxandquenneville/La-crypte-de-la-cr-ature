using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class MarreDeSang
    {
       private List<CaseDeSang> listeDeCaseDeSang;
       private bool forme;

       public virtual int? idCaseDeSang { get; set; }
       public virtual int? idMarreDeSang { get; set; }

       public virtual List<CaseDeSang> ListeDeCaseDeSang
       {
           get { return listeDeCaseDeSang; }
           set
           {
               listeDeCaseDeSang = value;
           }
       }

       public virtual bool Forme
       {
           get { return forme; }
           set
           {
               forme = value;
           }
       }

        /// <summary>
        /// constructeur de la classe Marre de sang
        /// </summary>
        public MarreDeSang()
        {
          ListeDeCaseDeSang = new List<CaseDeSang>();
        }

       /// <summary>
       /// Constructeur de la classe Marre de sang
       /// </summary>
       /// <param name="bForme">true = en carré  false = en ligne</param>
        public MarreDeSang(bool bForme)
        {
            forme = bForme;
            ListeDeCaseDeSang = new List<CaseDeSang>();
        }

    }
}
