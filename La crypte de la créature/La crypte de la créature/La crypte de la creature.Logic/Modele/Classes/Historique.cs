﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Historique
    {
        #region attribut
        private List<Deplacement> listeDeplacement;

        public virtual int? idHistorique { get; set; }

        public virtual List<Deplacement> ListeDeplacement
        {
            get { return listeDeplacement;}
            set
            {
                listeDeplacement = value;
            }

        }
        #endregion

        /// <summary>
        /// Constructeur de la classe Historique
        /// </summary>
        public Historique() 
        {
            listeDeplacement = new List<Deplacement>();
        }

        /*/// <summary>
        /// Lorsqu'on prend les informations de la bd.
        /// Ce constructeur est seulement utile lorsque 
        /// la partie est déjà commencer lorsqu'on la charge en mémoire.
        /// </summary>
        /// <param name="TabDeplacement">Les déplacements de la bd dans une liste de Deplacement(Du premier coup au dernier coup)</param>
        public Historique(List<Deplacement> BdDeplacement)
        {
            if (BdDeplacement.Count > 0)
            {
                listeDeplacement = new List<Deplacement>(BdDeplacement);
            }
        }*/

    }
}
