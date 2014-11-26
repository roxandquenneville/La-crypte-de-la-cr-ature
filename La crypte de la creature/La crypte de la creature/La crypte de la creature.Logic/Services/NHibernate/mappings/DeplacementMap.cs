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
              Table("deplacements");
              LazyLoad();
              Id(x => x.idDeplacement)
                .Column("idDeplacement")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
				References(x => x.Historique)
                .Class<Historique>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idHistorique");
				References(x => x.Pion)
                .Class<Pion>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPion");
                References(x => x.Pierre)
                .Class<Pierre>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPierre");
                References(x => x.Monstre)
                .Class<Monstre>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idMonstre");
                References(x => x.Depart)
                .Class<Position>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPositionDepart");
                References(x => x.Fin)
                .Class<Position>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPositionFin");
				
        }
    }

}