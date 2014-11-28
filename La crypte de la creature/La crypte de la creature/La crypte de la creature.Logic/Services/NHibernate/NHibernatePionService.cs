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
        private ISession session;
        #region IPionService Members

        public IList<Pion> RetrieveAll()
        {
            session = NHibernateConnexion.OpenSession();
            return session.Query<Pion>().ToList();
            
        }

        public Pion Retrieve(RetrievePionArgs args)
        {
            session = NHibernateConnexion.OpenSession();
            var result = from p in session.Query<Pion>()
                         where p.idPion == args.idPion
                         select p;
            return result.FirstOrDefault();
            

        }

        public void Create(Pion p)
        {
            session= NHibernateConnexion.OpenSession();
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
            session.Close();
        }

        public void Update(Pion p)
        {
             session= NHibernateConnexion.OpenSession();
            using (var transaction = session.BeginTransaction())
            {
                session.Merge(p);
                transaction.Commit();
                session.Flush();
            }
           session.Close();
          
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
