using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
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
               References(x => x.idCompte)
                .Class<Pion>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idCompte");
				References(x => x.idPartie)
                .Class<Partie>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPartie");
			
			HasMany<Pion>(x => x.idPion)
                .Not.LazyLoad()
                .Access.Property()
                .Cascade.All()
                .Inverse()
                .KeyColumns.Add("idJoueur", map => map.Name("idJoueur")
                                                    .SqlType("INTEGER")
                                                    .Nullable());
        }
    }

}