﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IPointageService
    {
        IList<Pointage> RetrieveAll();
        Pointage Retrieve(RetrievePointageArgs args);
        void Create(Pointage p);
        void Update(Pointage p);
        void Delete(Pointage p);
    }
}
