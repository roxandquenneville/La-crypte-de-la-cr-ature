using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.mappings
{
    public class PositionMap : ClassMap<Position>
    {
        public PositionMap()
        {
            Table("position");
            LazyLoad();
            Id(x => x.idPosition)
              .Column("idPosition")
              .CustomType("Int32")
              .Access.Property()
              .CustomSqlType("INTEGER")
              .Not.Nullable()
              .GeneratedBy.Identity();
            References(x => x.idDeplacement)
               .Class<Deplacement>()
               .Access.Property()
               .LazyLoad(Laziness.False)
               .Cascade.None()
               .Columns("idDeplacement");
            Map(x => x.X)
              .Column("X")
              .CustomType<int>()
              .Access.Property()
              .Generated.Never()
              .CustomSqlType("INTEGER");
            Map(x => x.Y)
                .Column("Y")
                .CustomType<int>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("INTEGER");
        }  
    }
}
