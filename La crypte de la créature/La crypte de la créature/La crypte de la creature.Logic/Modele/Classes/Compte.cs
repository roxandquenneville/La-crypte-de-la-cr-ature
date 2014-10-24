using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Compte
    {
        #region attribut
        public virtual int? idCompte { get; set; }
        public virtual string NomUsager{get;set; }
        public virtual string MotDePasse{get;set; }
        #endregion



        /// <summary>
        /// Constructeur de la classe joueur
        /// </summary>
        /// <param name="nom">Nom d'usager</param>
        /// <param name="code">Mot de passe</param>
        public Compte(string nom, string code)
        {
            NomUsager = nom;
            MotDePasse = code;
        }

        public Compte()
        {
            NomUsager = "";
            MotDePasse = "";
        }

        /// <summary>
        /// Vérifie si la connexion est valide
        /// </summary>
        /// <returns>Retourne vrai si sa fonction sinon retourne faux</returns>
        public virtual bool Connexion()
        {
            bool Valide = true;


            return Valide;

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Compte c = obj as Compte;

            if (c == null)
            {
                return false;
            }

            return this.idCompte == c.idCompte;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
