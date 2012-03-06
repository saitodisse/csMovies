using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class AdministradorServico
    {
        private readonly IFilmeDAO _filmeDAO;
        private readonly IReleaseDAO _releaseDAO;
        private readonly ILegendaDAO _legendaDAO;
        private readonly IUsuarioDAO _usuarioDAO;
        private readonly IImdbInfoDAO _imdbInfoDAO;
        private readonly IBancoDadosCreator _bancoDadosCreator;
        private readonly IArquivoDAO _arquivoDAO;

        public AdministradorServico(IFilmeDAO filmeDAO, IReleaseDAO releaseDAO, ILegendaDAO legendaDAO, IUsuarioDAO usuarioDAO, IBancoDadosCreator bancoDadosCreator, IImdbInfoDAO imdbInfoDAO, IArquivoDAO arquivoDAO)
        {
            _filmeDAO = filmeDAO;
            _releaseDAO = releaseDAO;
            _legendaDAO = legendaDAO;
            _usuarioDAO = usuarioDAO;
            _bancoDadosCreator = bancoDadosCreator;
            _imdbInfoDAO = imdbInfoDAO;
            _arquivoDAO = arquivoDAO;
        }

        public void AutoCriarBancoDeDados()
        {
            _bancoDadosCreator.AutoCriarBancoDeDados();
        }

        public Filme PesquisarFilme(int id)
        {
            return _filmeDAO.Get(id);
        }

        public IList<Arquivo> PesquisarArquivosPorFilme(int filme_id)
        {
            return _arquivoDAO.PesquisarArquivosPorFilme(filme_id);
        }

        public Filme InserirDadosTeste()
        {
            // NOVO FILME
            var filme = new Filme();
            filme.Nome = "Meu Filme";
            _filmeDAO.Save(filme);

            var filme2 = new Filme();
            filme2.Nome = "Robocop";
            _filmeDAO.Save(filme2);

            // NOVO IMDB INFO
            var imbdInfo = new ImdbInfo();
            imbdInfo.Rating = "9.0/10";
            _imdbInfoDAO.Save(imbdInfo);

            // ASSOCIA FILME E IMDB INFO
            imbdInfo.Filme = filme;
            _imdbInfoDAO.Save(imbdInfo);
            filme.ImdbInfo = imbdInfo;
            _filmeDAO.Save(filme);
            // FILME 2
            imbdInfo.Filme = filme2;
            _imdbInfoDAO.Save(imbdInfo);
            filme2.ImdbInfo = imbdInfo;
            _filmeDAO.Save(filme2);
            
            // 2 RELEASES
            var release1 = new Release();
            release1.Nome = "Meu.Filme-2011-Divx.Axxo";
            _releaseDAO.Save(release1);
            var release2 = new Release();
            release2.Nome = "Meu.Filme-2011-XVid-720p.Corpse";
            _releaseDAO.Save(release2);
            var release3 = new Release();
            release3.Nome = "Outro.Filme-1950-720p.Xinobi";
            _releaseDAO.Save(release3);
            var release4 = new Release();
            release4.Nome = "Robocop-1990-1080p-Vitor";
            _releaseDAO.Save(release4);

            // NOVA LEGENDA
            var legenda = new Legenda();
            legenda.Linguagem = "pt-BR";
            _legendaDAO.Save(legenda);

            // NOVO USUARIO
            var usuario = new Usuario();
            usuario.Login = "user";
            usuario.PasswordHash = "123128973189273891273";
            _usuarioDAO.Save(usuario);

            // MESMA LEGENDA SERVE NOS 2 RELEASES
            release1.AdicionarLegenda(legenda);
            release2.AdicionarLegenda(legenda);
            _releaseDAO.Save(release1);
            _releaseDAO.Save(release2);

            // FILME X RELEASE
            filme.AdicionarRelease(release1);
            filme.AdicionarRelease(release2);
            _filmeDAO.Save(filme);
            // FILME 2
            filme2.AdicionarRelease(release1);
            filme2.AdicionarRelease(release2);
            filme2.AdicionarRelease(release3);
            filme2.AdicionarRelease(release4);
            _filmeDAO.Save(filme2);

            // RELACIONA ARQUIVOS COM RELEASES
            var arquivo = new Arquivo();
            arquivo.Release = release1;
            arquivo.Caminho = @"G:\!downloads\complete\MOVIES 720p\Tropa De Elite 2 (2010) 720p BRRip XviD AC3 TiMPE\Tropa De Elite 2 (2010) 720p BRRip XviD AC3 TiMPE.avi";
            _arquivoDAO.Save(arquivo);

            arquivo = new Arquivo();
            arquivo.Release = release2;
            arquivo.Caminho = @"C:\filmes\filme2.mkv";
            _arquivoDAO.Save(arquivo);

            arquivo = new Arquivo();
            arquivo.Release = release2;
            arquivo.Caminho = @"C:\filmes\filme2.avi";
            _arquivoDAO.Save(arquivo);


            // USUARIO POSSUI 2 RELEASE
            usuario.AdicionarRelease(release1);
            usuario.AdicionarRelease(release2);
            _usuarioDAO.Save(usuario);

            return filme;
        }
    }
}
