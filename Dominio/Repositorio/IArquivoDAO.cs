using System.Collections.Generic;
using Dominio.Entidades;

namespace Dominio.Repositorio
{
    public interface IArquivoDAO : IRepositorio<Arquivo>
    {
        IList<Arquivo> PesquisarArquivosPorFilme(int filmeId);
    }
}