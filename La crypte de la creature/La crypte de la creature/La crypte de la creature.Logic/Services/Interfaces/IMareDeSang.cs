﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IMareSangService
    {
        IList<MareDeSang> RetrieveAll();
        MareDeSang Retrieve(RetrieveMareSangArgs args);
        void Create(MareDeSang c);
        void Update(MareDeSang c);
        void Delete(MareDeSang c);
    }
}
