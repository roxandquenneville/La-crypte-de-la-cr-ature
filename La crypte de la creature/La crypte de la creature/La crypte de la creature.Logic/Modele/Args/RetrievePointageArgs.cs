﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Args
{
    public class RetrievePointageArgs
    {
        public int idPointage { get; set; }
        public int idPartie { get; set; }
        public int points { get; set; }
    }
}