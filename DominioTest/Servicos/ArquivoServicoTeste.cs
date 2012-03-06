using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Repositorio;
using Dominio.Servicos;
using Moq;
using NUnit.Framework;

namespace DominioTest.Servicos
{
    [TestFixture]
    public class ArquivoServicoTeste
    {
        [Test]
        public void inicializa_arquivo()
        {
            const string CAMINHO = @"c:\pasta\arquivoBanana.mkv";

            var arquiRepoMock = new Mock<IArquiRepo>();
            // (MOCKED) Vai no disco e verifica o tamanho do arquivo
            arquiRepoMock.Setup(x => x.TamanhoArquivo(It.IsAny<string>())).Returns(2971491348);
            IArquiRepo arquiRepo = arquiRepoMock.Object;

            var arquivoDAOMock = new Mock<IArquivoDAO>();
            var arquivoDAO = arquivoDAOMock.Object;

            var arquivoServico = new ArquivoServico(arquiRepo, arquivoDAO);
            Arquivo arquivo = arquivoServico.InicializarArquivo(CAMINHO);

            Assert.AreEqual(CAMINHO, arquivo.Caminho);
            Assert.AreEqual("arquivoBanana.mkv", arquivo.Nome());
            Assert.AreEqual(2971491348, arquivo.Tamanho);
            Assert.AreEqual("2,77GB", arquivo.TamanhoFormatado());
        }

        [Test]
        public void busca_arquivos_em_pasta()
        {
            var arquiRepoMock = new Mock<IArquiRepo>();
            
            var caminhoEncontrados = new List<string>();
            caminhoEncontrados.Add(@"c:\pasta\arq1.mkv");
            caminhoEncontrados.Add(@"c:\pasta\arq2.mkv");
            caminhoEncontrados.Add(@"c:\pasta\arq3.mkv");

            // (MOCKED) Busca todos os arquivos da pasta
            arquiRepoMock.Setup(x => x.BuscarArquivosEmPasta(It.IsAny<string>(), It.IsAny<string>())).Returns(caminhoEncontrados);
            // (MOCKED) Vai no disco e verifica o tamanho do arquivo
            arquiRepoMock.Setup(x => x.TamanhoArquivo(It.IsAny<string>())).Returns(2971491348);
            IArquiRepo arquiRepo = arquiRepoMock.Object;

            var arquivoDAOMock = new Mock<IArquivoDAO>();
            var arquivoDAO = arquivoDAOMock.Object;

            var arquivoServico = new ArquivoServico(arquiRepo, arquivoDAO);
            IList<Arquivo> listaRetornada = arquivoServico.BuscarArquivosEmPasta(@"c:\pasta", "*.mkv");

            // o segundo arquivo tá certinho?
            var segundoArquivo = listaRetornada[1];
            Assert.AreEqual(@"c:\pasta\arq2.mkv", segundoArquivo.Caminho);
            Assert.AreEqual("arq2.mkv", segundoArquivo.Nome());
            Assert.AreEqual(2971491348, segundoArquivo.Tamanho);
            Assert.AreEqual("2,77GB", segundoArquivo.TamanhoFormatado());
        }

        [Test]
        public void pesquisar_arquivos_banco_dados()
        {
            var arquiRepoMock = new Mock<IArquiRepo>();
            IArquiRepo arquiRepo = arquiRepoMock.Object;

            var listaASerRetornada = new List<Arquivo>();
            var arquivo = new Arquivo();
            const string CAMINHO = @"c:\pasta\arquivoBanana.mkv";
            arquivo.Caminho = CAMINHO;
            arquivo.Tamanho = 2971491348;
            listaASerRetornada.Add(arquivo);

            var arquivoDAOMock = new Mock<IArquivoDAO>();
            arquivoDAOMock.Setup(x => x.GetAll()).Returns(listaASerRetornada);
            var arquivoDAO = arquivoDAOMock.Object;

            var arquivoServico = new ArquivoServico(arquiRepo, arquivoDAO);
            IList<Arquivo> arquivos = arquivoServico.PesquisarTodos();
            var primeiroArquivo = arquivos[0];

            Assert.AreEqual(CAMINHO, primeiroArquivo.Caminho);
            Assert.AreEqual("arquivoBanana.mkv", primeiroArquivo.Nome());
            Assert.AreEqual(2971491348, primeiroArquivo.Tamanho);
            Assert.AreEqual("2,77GB", primeiroArquivo.TamanhoFormatado());
        }

        [Test]
        public void pesquisar_unico_arquivo_banco_dados()
        {
            var arquiRepoMock = new Mock<IArquiRepo>();
            IArquiRepo arquiRepo = arquiRepoMock.Object;

            const string CAMINHO = @"c:\pasta\arquivoBanana.mkv";
            var arquivo = new Arquivo();
            arquivo.Caminho = CAMINHO;
            arquivo.Tamanho = 2971491348;

            var arquivoDAOMock = new Mock<IArquivoDAO>();
            arquivoDAOMock.Setup(x => x.Get(It.IsAny<int>())).Returns(arquivo);
            var arquivoDAO = arquivoDAOMock.Object;

            var arquivoServico = new ArquivoServico(arquiRepo, arquivoDAO);
            Arquivo arquivoPesquisado = arquivoServico.Pesquisar(1);

            Assert.AreEqual(CAMINHO, arquivoPesquisado.Caminho);
            Assert.AreEqual("arquivoBanana.mkv", arquivoPesquisado.Nome());
            Assert.AreEqual(2971491348, arquivoPesquisado.Tamanho);
            Assert.AreEqual("2,77GB", arquivoPesquisado.TamanhoFormatado());
        }

        [Test]
        public void salva_unico_arquivo_banco_dados()
        {
            var arquiRepoMock = new Mock<IArquiRepo>();
            IArquiRepo arquiRepo = arquiRepoMock.Object;

            const string CAMINHO = @"c:\pasta\arquivoBanana.mkv";
            var arquivo = new Arquivo();
            arquivo.Caminho = CAMINHO;
            arquivo.Tamanho = 2971491348;

            var arquivoDAOMock = new Mock<IArquivoDAO>();
            arquivoDAOMock.Setup(x => x.Save(arquivo)).Callback(() => { arquivo.Id = 1; });
            var arquivoDAO = arquivoDAOMock.Object;

            var arquivoServico = new ArquivoServico(arquiRepo, arquivoDAO);
            
            Assert.AreEqual(0, arquivo.Id);
            
            arquivoServico.Salvar(arquivo);

            Assert.AreEqual(1, arquivo.Id);
        }

    }
}
