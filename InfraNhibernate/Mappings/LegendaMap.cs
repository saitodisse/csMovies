using FluentNHibernate.Mapping;
using Dominio.Entidades;

namespace InfraNhibernate.Mappings
{
    public class LegendaMap : ClassMap<Legenda>
    {
        public LegendaMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();

            Map(x => x.Linguagem);

            References(x => x.Release);
        }
    }
}
