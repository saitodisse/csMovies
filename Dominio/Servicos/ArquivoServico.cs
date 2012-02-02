using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ArquivoServico
    {
        private readonly IArquiRepo _arquiRepo;
        private readonly IArquivoDAO _arquivoDAO;

        public ArquivoServico(IArquiRepo arquiRepo, IArquivoDAO arquivoDAO)
        {
            _arquiRepo = arquiRepo;
            _arquivoDAO = arquivoDAO;
        }

        public Arquivo InicializarArquivo(string caminho)
        {
            var arquivo = new Arquivo();
            arquivo.Caminho = caminho;
            arquivo.Tamanho = _arquiRepo.TamanhoArquivo(caminho);
            return arquivo;
        }

        public IList<Arquivo> BuscarArquivosEmPasta(string pasta, string tipoArquivo)
        {
            var caminhosArquivos = _arquiRepo.BuscarArquivosEmPasta(pasta, tipoArquivo);
            var arquivos = new List<Arquivo>();
            foreach (var caminho in caminhosArquivos)
            {
                arquivos.Add(InicializarArquivo(caminho));
            }
            return arquivos;
        }

        public IList<Arquivo> PesquisarTodos()
        {
            return _arquivoDAO.GetAll();
        }

        public Arquivo Pesquisar(int id)
        {
            return _arquivoDAO.Get(id);
        }

        public void Salvar(Arquivo arquivo)
        {
            _arquivoDAO.Save(arquivo);
        }
    }
}
