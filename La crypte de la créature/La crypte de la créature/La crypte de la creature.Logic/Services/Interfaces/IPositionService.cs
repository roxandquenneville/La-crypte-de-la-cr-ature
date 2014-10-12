using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IPositionService
    {
        IList<Position> RetrieveAll();
        Position Retrieve(RetrievePositionArgs args);
        void Create(Position p);
        void Update(Position p);
        void Delete(Position p);
    }
}
