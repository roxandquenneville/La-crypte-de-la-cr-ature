using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IPionService
    {
        IList<Pion> RetrieveAll();
        Pion Retrieve(RetrievePionArgs args);
        void Create(Pion c);
        void Update(Pion c);
        void Delete(Pion c);
    }
}