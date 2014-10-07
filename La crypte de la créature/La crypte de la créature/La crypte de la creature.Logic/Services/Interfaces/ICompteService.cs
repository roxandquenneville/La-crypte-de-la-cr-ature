using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modèle.Classes;
using La_crypte_de_la_creature.Logic.Modèle.Args;////////??????

namespace La_crypte_de_la_creature.Services.Definitions
{
    public interface ICompteService
    {
        IList<Compte> RetrieveAll();
        Client Retrieve(RetrieveCompteArgs args);
    }
}