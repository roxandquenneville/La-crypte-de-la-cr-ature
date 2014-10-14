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
using La_crypte_de_la_creature.Logic.Services.Helpers;
using La_crypte_de_la_creature.Logic.Services.Interfaces;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate
{
    public class NHibernatePointageService : IPointageService
    {
        private ISession session = NHibernateConnexion.OpenSession();


        #region IPointageService Membres

        public IList<Pointage> RetrieveAll()
        {
            return session.Query<Pointage>().ToList();
        }

        public Pointage Retrieve(RetrievePointageArgs args)
        {
            var result = from p in session.Query<Pointage>()
                         where p.idPointage == args.idPointage
                         select p;

            return result.FirstOrDefault();
        }

        public void Create(Pointage p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(Pointage p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(Pointage p)
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