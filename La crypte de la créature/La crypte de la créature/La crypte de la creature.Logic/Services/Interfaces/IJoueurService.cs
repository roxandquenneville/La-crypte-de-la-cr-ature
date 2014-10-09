using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Args;
using La_crypte_de_la_creature.Logic.Modele.Classes;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IJoueurService
    {
        IList<Joueur> RetrieveAll();
        Joueur Retrieve(RetrieveJoueurArgs args);
        void Create(Compte propriete);
        void Update(Compte propriete);
        void Delete(Compte propriete);
    }
}
