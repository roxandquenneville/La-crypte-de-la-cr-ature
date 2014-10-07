using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modèle.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class MarreDeSangMap : ClassMap<MarreDeSang>
    {
        public MarreDeSangMap()
        {
              Table("marresDeSang");
              LazyLoad();
              Id(x => x.idMarreDeSang)
                .Column("idMarre")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
			  Map(x => x.Forme)
                .Column("forme")
                .CustomType<string>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");
			  HasMany<MarreDeSang>(x => x.idMarreDeSang)
                .Not.LazyLoad()
                .Access.Property()
                .Cascade.All()
                .Inverse()
                .KeyColumns.Add("idMarre", map => map.Name("idMarre")
                                                    .SqlType("INTEGER")
                                                    .Nullable());
				
        }
    }

}