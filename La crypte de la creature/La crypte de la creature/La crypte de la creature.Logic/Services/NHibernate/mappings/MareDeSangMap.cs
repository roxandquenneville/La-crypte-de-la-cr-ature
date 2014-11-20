using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class MareDeSangMap : ClassMap<MareDeSang>
    {
        public MareDeSangMap()
        {
              Table("MaresDeSang");
              LazyLoad();
              Id(x => x.idMareDeSang)
                .Column("idMare")
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
			  HasMany<MareDeSang>(x => x.idMareDeSang)
                .Not.LazyLoad()
                .Access.Property()
                .Cascade.All()
                .KeyColumns.Add("idMare", map => map.Name("idMare")
                                                    .SqlType("INTEGER")
                                                    .Nullable());
				
        }
    }

}