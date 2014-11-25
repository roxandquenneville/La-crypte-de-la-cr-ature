using La_crypte_de_la_creature.Logic.Modele.Args;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Services.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Services.Helpers;
using La_crypte_de_la_creature.Logic.Services.Interfaces;

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
                         where c.NomUsager == args.nomUsager
                         select c;

            return result.FirstOrDefault();
        }

        public void Create(Compte c)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(c);
                transaction.Commit();
            }
        }

        public void Update(Compte c)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(c);
                transaction.Commit();
            }
        }

        public void Delete(Compte c)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(c);
                transaction.Commit();
            }
        }

        #endregion
    }
}