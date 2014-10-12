using La_crypte_de_la_creature.Logic.Modele.Args;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Services.NHibernate;
using La_crypte_de_la_creature.Services.Definitions;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using System.Threading.Tasks;
using Immobilus.Logic.Services.Helpers;
using La_crypte_de_la_creature.Logic.Services.Interfaces;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate
{
    public class NHibernateHistoriqueService : IHistoriqueService
    {
        private ISession session = NHibernateConnexion.OpenSession();


        #region IJoueurService Membres

        public void Create(Historique h)
        {
            throw new NotImplementedException();
        }

        public IList<Historique> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public Joueur Retrieve(RetrieveHistoriqueArgs args)
        {
            throw new NotImplementedException();
        }

        public void Update(Historique h)
        {
            throw new NotImplementedException();
        }

        public void Delete(Historique h)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
