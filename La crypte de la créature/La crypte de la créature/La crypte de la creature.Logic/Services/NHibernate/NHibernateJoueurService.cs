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
    public class NHibernateJoueurService : IJoueurService
    {
        private ISession session = NHibernateConnexion.OpenSession();


        #region IJoueurService Membres

        public IList<Joueur> RetrieveAll()
        {
            return session.Query<Joueur>().ToList();
        }

        public Joueur Retrieve(RetrieveJoueurArgs args)
        {
            var result = from j in session.Query<Joueur>()
                         where j.idJoueur == args.idJoueur
                         select j;
            return result.FirstOrDefault();

        }

        public void Create(Joueur j)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(j);
                transaction.Commit();
            }
        }

        public void Update(Joueur j)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(j);
                transaction.Commit();
            }
        }

        public void Delete(Joueur j)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(j);
                transaction.Commit();
            }
        }

        #endregion
    }
}