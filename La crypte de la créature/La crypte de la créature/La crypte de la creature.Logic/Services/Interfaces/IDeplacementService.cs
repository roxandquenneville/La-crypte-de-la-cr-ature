using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IDeplacementService
    {
        IList<Deplacement> RetrieveAll();
        Deplacement Retrieve(RetrieveDeplacementArgs args);
        void Create(Deplacement d);
        void Update(Deplacement d);
        void Delete(Deplacement d);
    }
}
