using Dominio.Entidades;
using FluentNHibernate.Mapping;

namespace InfraNhibernate.Mappings
{
    public class FilmeMap : ClassMap<Filme>
    {
        public FilmeMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();
            Map(x => x.Nome);
            References(x => x.ImdbInfo);
            HasMany(x => x.Releases);
        }
    }
}
