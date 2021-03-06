﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Pointage
    {
        #region attribut
        private int point;

        public virtual Partie Partie {get; set; }
        public virtual int? idPointage { get; set; }
        

        public virtual int Point
        {
            get { return point;}
            set 
            {
                if (value > -1)
                {
                    point = value;
                }
            }

        }
       
        #endregion

        /// <summary>
        /// Constructeur de la classe pointage
        /// Créer un tableau de la bonne taille et met toutes les cases a 0
        /// </summary>
        public Pointage(int score = 0)
        {
           Point= score;
           Partie = new Partie();
        }

        public Pointage()
        {
            Point=0;
            Partie = new Partie();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Pointage p = obj as Pointage;

            if (p == null)
            {
                return false;
            }

            return this.idPointage == p.idPointage;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }




    }
}
