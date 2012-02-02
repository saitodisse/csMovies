using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dominio.Repositorio;

namespace ArquivoRepositorio
{
    public class ArquiRepo : IArquiRepo
    {
        public long TamanhoArquivo(string caminho)
        {
            var fi = new FileInfo(caminho);
            return fi.Length;
        }

        public List<string> BuscarArquivosEmPasta(string pasta, string tipoArquivo)
        {
            var dir = new DirectoryInfo(pasta);
            return dir.GetFiles(tipoArquivo).Select(x=>x.FullName).ToList();
        }
    }
}
