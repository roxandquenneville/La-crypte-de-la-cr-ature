using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modèle.Classes
{
    class Compte
    {
        #region attribut
        private string nomUsager;
        private string motDePasse;

        public virtual int? idCompte { get; set; }

        public virtual string NomUsager
        {
            get { return nomUsager; }
            set { nomUsager = value; }
        }

        public virtual string MotDePasse
        {
            get { return motDePasse; }
            set { motDePasse = value; }
        }
        #endregion

        /// <summary>
        /// Constructeur de la classe joueur
        /// </summary>
        /// <param name="nom">Nom d'usager</param>
        /// <param name="code">Mot de passe</param>
        public Compte(string nom,string code)
        {
            NomUsager = nom;
            MotDePasse = code;
        }


        /// <summary>
        /// Vérifie si la connexion est valide
        /// </summary>
        /// <returns>Retourne vrai si sa fonction sinon retourne faux</returns>
        public bool Connexion()
        {
            bool Valide=true;


            return Valide;

        }
    }
}
