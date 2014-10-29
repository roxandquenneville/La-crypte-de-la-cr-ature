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
    public class NHibernatePionService : IPionService
    {
        private ISession session = NHibernateConnexion.OpenSession();
        #region IPionService Members

        public IList<Pion> RetrieveAll()
        {
            return session.Query<Pion>().ToList();
        }

        public Pion Retrieve(RetrievePionArgs args)
        {
            var result = from p in session.Query<Pion>()
                         where p.idPion == args.idPion
                         select p;

            return result.FirstOrDefault();

        }

        public void Create(Pion p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(Pion p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(Pion p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(p);
                transaction.Commit();
            }
        }

        #endregion
    }
}
