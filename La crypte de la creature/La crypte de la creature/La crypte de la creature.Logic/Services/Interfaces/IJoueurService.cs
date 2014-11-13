using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IJoueurService
    {
        IList<Joueur> RetrieveAll();
        Joueur Retrieve(RetrieveJoueurArgs args);
        void Create(Joueur j);
        void Update(Joueur j);
        void Delete(Joueur j);
    }
}
