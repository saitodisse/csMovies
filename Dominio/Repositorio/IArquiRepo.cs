using System.Collections.Generic;

namespace Dominio.Repositorio
{
    public interface IArquiRepo
    {
        long TamanhoArquivo(string caminho);
        List<string> BuscarArquivosEmPasta(string pasta, string tipoArquivo);
    }
}