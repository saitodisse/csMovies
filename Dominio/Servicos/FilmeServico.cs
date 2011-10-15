using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public interface IFilmeServico
    {
        IList<Filme> Todos();
    }

    public class FilmeServico : IFilmeServico
    {
        private readonly IFilmeDAO _filmeDAO;
        public FilmeServico(IFilmeDAO filmeDAO)
        {
            _filmeDAO = filmeDAO;
        }

        public IList<Filme> Todos()
        {
            return _filmeDAO.GetAll();
        }
    }
}