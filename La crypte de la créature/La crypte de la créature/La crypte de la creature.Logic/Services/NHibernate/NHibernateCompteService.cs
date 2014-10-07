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

namespace La_crypte_de_la_creature.Logic.Services.NHibernate
{
    public class NHibernateCompteService : ICompteService
    {
        private ISession session = NHibernateConnexion.OpenSession();


        #region ICompteService Membres

        public IList<Compte> RetrieveAll()
        {
            return session.Query<Compte>().ToList();
        }

        public Compte Retrieve(RetrieveCompteArgs args)
        {
            var result = from c in session.Query<Compte>()
                         where c.idCompte == args.IdClient
                         select c;

            return result.FirstOrDefault();
        }

        #endregion
    }
}