using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class CartesMonstre
    {
         #region attribut
        private string url;
        private List<int> listeDeCarte;

        public virtual int? idCartesMonstre { get; set; }
        public virtual int? idPartie { get; set; }

        public virtual List<int> ListeDeCarte
        {
            get {return listeDeCarte;}
            set {listeDeCarte = value;}

        }

        #endregion



        

    }
}
