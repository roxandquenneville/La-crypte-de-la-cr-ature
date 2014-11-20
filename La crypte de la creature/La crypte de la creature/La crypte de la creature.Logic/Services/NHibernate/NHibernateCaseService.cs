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
    public class NHibernateCaseService : ICaseService
    {
        private ISession session = NHibernateConnexion.OpenSession();
        #region ICaseService Members

        public IList<Case> RetrieveAll()
        {
            return session.Query<Case>().ToList();
        }
        public IList<Case> RetrievePlateau(int idPlateau)
        {

            var result = from p in session.Query<Case>()
                         where p.Plateau.idPlateau == idPlateau     
                                           
                         select p;

            return result.ToList();
        }

        public Case Retrieve(RetrieveCaseArgs args)
        {
            var result = from p in session.Query<Case>()
                         where p.idCase == args.idCase
                         select p;

            return result.FirstOrDefault();

        }

        public void Create(Case p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(Case p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(Case p)
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
