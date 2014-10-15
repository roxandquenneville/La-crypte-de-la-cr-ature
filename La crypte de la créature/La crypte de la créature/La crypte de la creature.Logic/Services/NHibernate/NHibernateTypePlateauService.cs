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
    public class NHibernateTypePlateauService : ITypePlateauService
    {
        private ISession session = NHibernateConnexion.OpenSession();


        #region ITypePlateauService Membres

        public IList<TypePlateau> RetrieveAll()
        {
            return session.Query<TypePlateau>().ToList();
        }

        public TypePlateau Retrieve(RetrieveTypePlateauArgs args)
        {
            var result = from tp in session.Query<TypePlateau>()
                         where tp.idTypePlateau == args.idTypePlateau
                         select tp;

            return result.FirstOrDefault();
        }

        public void Create(TypePlateau tp)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(tp);
                transaction.Commit();
            }
        }

        public void Update(TypePlateau tp)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(tp);
                transaction.Commit();
            }
        }

        public void Delete(TypePlateau tp)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(tp);
                transaction.Commit();
            }
        }

        #endregion
    }
}
