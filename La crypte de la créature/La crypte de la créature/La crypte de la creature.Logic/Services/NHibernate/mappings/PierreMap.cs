using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class PierreMap : ClassMap<Pierre>
    {
        public PierreMap()
        {
              Table("pieres");
              LazyLoad();
              Id(x => x.idPierre)
                .Column("idPierre")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
				Map(x => x.EstSurPlateau)
                .Column("estSurPlateau")
                .CustomType<bool>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("BOOL");
        }
    }

}