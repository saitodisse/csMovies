using FluentNHibernate.Mapping;
using Dominio.Entidades;

namespace InfraNhibernate.Mappings
{
    public class DownloadLinkMap : ClassMap<DownloadLink>
    {
        public DownloadLinkMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();

            Map(x => x.Downloaded);
            Map(x => x.Uri);
        }

    }
}
