using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Mod�le.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class PointageMap : ClassMap<Pointage>
    {
        public PointageMap()
        {
              Table("pointages");
              LazyLoad();
              Id(x => x.idPointage)
                .Column("idPointage")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
               Map(x => x.ListeDePoint)
                .Column("ipoint")
                .CustomType<int>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("INTEGER");
			  
				
				
        }
    }

}