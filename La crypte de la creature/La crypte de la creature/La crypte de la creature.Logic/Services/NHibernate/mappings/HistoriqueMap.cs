using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class HistoriqueMap : ClassMap<Historique>
    {
        public HistoriqueMap()
        {
              Table("historiques");
              LazyLoad();
              Id(x => x.idHistorique)
                .Column("idHistorique")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
			HasMany<Deplacement>(x => x.Deplacement)
                .Not.LazyLoad()
                .Access.Property()
                .Cascade.All()
                .Inverse()
                .KeyColumns.Add("idHistorique", map => map.Name("idHistorique")
                                                    .SqlType("INTEGER")
                                                    .Nullable());
				
        }
    }

}