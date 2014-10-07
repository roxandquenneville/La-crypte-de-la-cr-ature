using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modèle.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class JoueurMap : ClassMap<Joueur>
    {
        public JoueurMap()
        {
              Table("joueurs");
              LazyLoad();
              Id(x => x.idJoueur)
                .Column("idJoueur")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
               References(x => x.idPion)
                .Class<Pion>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPion");
				References(x => x.idPartie)
                .Class<Partie>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPartie");
				References(x => x.idCompte)
                .Class<Compte>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idCompte");
			HasMany<Pion>(x => x.ListePion)
                .Not.LazyLoad()
                .Access.Property()
                .Cascade.All()
                .Inverse()
                .KeyColumns.Add("idPion", map => map.Name("idPion")
                                                    .SqlType("INTEGER")
                                                    .Nullable());
        }
    }

}