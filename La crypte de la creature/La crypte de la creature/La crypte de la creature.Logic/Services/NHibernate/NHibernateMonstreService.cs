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
    public class NHibernateMonstreService : IMonstreService
    {
        private ISession session = NHibernateConnexion.OpenSession();
        #region IMonstreService Members

        public IList<Monstre> RetrieveAll()
        {
            return session.Query<Monstre>().ToList();
        }

        public Monstre Retrieve(RetrieveMonstreArgs args)
        {
            var result = from p in session.Query<Monstre>()
                         where p.idMonstre == args.idMonstre
                         select p;

            return result.FirstOrDefault();

        }

        public void Create(Monstre p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(Monstre p)
        {
            session.Close();
            session = NHibernateConnexion.OpenSession();
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(Monstre p)
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
