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
            Id(x => x.position)
              .Column("idPosition")
              .CustomType("Int32")
              .Access.Property()
              .CustomSqlType("INTEGER")
              .Not.Nullable()
              .GeneratedBy.Identity();          
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
