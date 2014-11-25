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
              //References(x => x.idPiece)
              //   .Class<Piece>()
              //   .Access.Property()
              //   .LazyLoad(Laziness.False)
              //   .Cascade.None()
              //   .Columns("idPiece");
              References(x => x.Position)
                .Class<Position>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPosition");
              References(x => x.Partie)
                .Class<Partie>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPartie");
				Map(x => x.EstSurPlateau)
                .Column("estSurPlateau")
                .CustomType<bool>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("BOOL");
        }
    }

}