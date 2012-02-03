using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class FilmeServico
    {
        private readonly IFilmeDAO _filmeDAO;
        public FilmeServico(IFilmeDAO filmeDAO)
        {
            _filmeDAO = filmeDAO;
        }

        public IList<Filme> PesquisarTodos()
        {
            return _filmeDAO.GetAll();
        }

        public Filme Pesquisar(int id)
        {
            return _filmeDAO.Get(id);
        }
    }
}