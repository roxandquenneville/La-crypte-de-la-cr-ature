using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class CarteMonstreMap : ClassMap<CartesMonstre>
    {
        public CarteMonstreMap()
        {
            Table("CartesMonstre");
            LazyLoad();
            Id(x => x.idCase)
              .Column("idCarteMonstre")
              .CustomType("Int32")
              .Access.Property()
              .CustomSqlType("INTEGER")
              .Not.Nullable()
              .GeneratedBy.Identity();
            References(x => x.idPartie)
            .Class<Plateau>()
            .Access.Property()
            .LazyLoad(Laziness.False)
            .Cascade.None()
            .Columns("idPartie");
            Map(x => x.utilise)
                 .Column("utilise")
                 .CustomType<bool>()
                 .Access.Property()
                 .Generated.Never()
                 .CustomSqlType("BOOL");
            Map(x => x.ValeurDeplacement)
            .Column("valeurDeplacement")
            .CustomType<int>()
            .Access.Property()
            .Generated.Never()
            .CustomSqlType("INTEGER");


        }
    }

}
