using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IPlateauService
    {
        IList<Plateau> RetrieveAll();
        Plateau Retrieve(RetrievePlateauArgs args);
        void Create(Plateau p);
        void Update(Plateau p);
        void Delete(Plateau p);
    }
}
