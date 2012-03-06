using FluentNHibernate.Mapping;
using Dominio.Entidades;

namespace InfraNhibernate.Mappings
{
    public class PastaArquivosMap : ClassMap<PastaArquivos>
    {
        public PastaArquivosMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();

            Map(x => x.Caminho);
            Map(x => x.TipoArquivo);
        }
    }
}
