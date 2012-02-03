using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ReleaseServico
    {
        private readonly IReleaseDAO _releaseDAO;
        public ReleaseServico(IReleaseDAO releaseDAO)
        {
            _releaseDAO = releaseDAO;
        }

        public IList<Release> PesquisarTodos()
        {
            return _releaseDAO.GetAll();
        }

        public Release Pesquisar(int id)
        {
            return _releaseDAO.Get(id);
        }
    }
}