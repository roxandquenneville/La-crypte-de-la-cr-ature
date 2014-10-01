using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_créature.Logic.Modèle.Classes
{
    class Joueur
    {
        #region attribut
        private string nomUsager;
        private string motDePasse;

        public string NomUsager
        {
            get { return nomUsager; }
            set { nomUsager = value; }
        }

        public string MotDePasse
        {
            get { return motDePasse; }
            set { motDePasse = value; }
        }
        #endregion


        public bool Connexion()
        {
            bool Valide=true;


            return Valide;

        }
    }
}
