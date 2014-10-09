using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
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
              References(x => x.idPartie)
                .Class<Partie>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPartie");
               Map(x => x.ListeDePoint)
                .Column("ipoint")
                .CustomType<int>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("INTEGER");
			  
				
				
        }
    }

}