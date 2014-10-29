using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IPierreService
    {
        IList<Pierre> RetrieveAll();
        Pierre Retrieve(RetrievePierreArgs args);
        void Create(Pierre c);
        void Update(Pierre c);
        void Delete(Pierre c);
    }
}