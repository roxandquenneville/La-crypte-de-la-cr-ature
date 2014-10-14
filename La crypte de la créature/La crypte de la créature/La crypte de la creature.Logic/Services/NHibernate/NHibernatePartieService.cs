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
    public class NHibernatePartieService : IPartieService
    {
        private ISession session = NHibernateConnexion.OpenSession();

        public IList<Partie> RetrieveAll()
        {
            return session.Query<Partie>().ToList();
        }

        public Partie Retrieve(RetrievePartieArgs args)
        {
            var result = from p in session.Query<Partie>()
                         where p.idPartie == args.idPartie
                         select p;

            return result.FirstOrDefault();
        }

        public void Create(Partie p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(Partie p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(Partie p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(p);
                transaction.Commit();
            }
        }

    }
}
