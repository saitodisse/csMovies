using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class PastaArquivosServico
    {
        private readonly IPastaArquivosDAO _pastaArquivosDAO;
        public PastaArquivosServico(IPastaArquivosDAO pastaArquivosDAO)
        {
            _pastaArquivosDAO = pastaArquivosDAO;
        }

        public IList<PastaArquivos> PesquisarTodos()
        {
            return _pastaArquivosDAO.GetAll();
        }

        public PastaArquivos Pesquisar(int id)
        {
            return _pastaArquivosDAO.Get(id);
        }
    }
}