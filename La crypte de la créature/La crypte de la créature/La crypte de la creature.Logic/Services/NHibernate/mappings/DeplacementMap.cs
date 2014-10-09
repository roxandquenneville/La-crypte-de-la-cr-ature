using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class DeplacementMap : ClassMap<Deplacement>
    {
        public DeplacementMap()
        {
              Table("déplacements");
              LazyLoad();
              Id(x => x.idDeplacement)
                .Column("idDeplacement")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
				References(x => x.idHistorique)
                .Class<Historique>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idHistorique");
				References(x => x.idPiece)
                .Class<Piece>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPiece");
                HasMany<Position>(x => x.idDeplacement)
                 .Not.LazyLoad()
                 .Access.Property()
                 .Cascade.All()
                 .Inverse()
                 .KeyColumns.Add("idDeplacement", map => map.Name("idDeplacement")
                                                     .SqlType("INTEGER")
                                                     .Nullable());
				
        }
    }

}