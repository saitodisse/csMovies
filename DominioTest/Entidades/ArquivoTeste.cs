using Dominio.Entidades;
using NUnit.Framework;

namespace DominioTest.Entidades
{
    [TestFixture]
    public class ArquivoTeste
    {
        [Test]
        public void nome_pega_so_o_nome_do_caminho()
        {
            var arquivo = new Arquivo();
            arquivo.Caminho = @"G:\!downloads\complete\MOVIES 720p\Tropa De Elite 2 (2010) 720p BRRip XviD AC3 TiMPE\Tropa De Elite 2 (2010) 720p BRRip XviD AC3 TiMPE.avi";
            Assert.AreEqual("Tropa De Elite 2 (2010) 720p BRRip XviD AC3 TiMPE.avi", arquivo.Nome());
        }

        [Test]
        public void tamanho_retorna_o_tamanho_em_bytes_long()
        {
            var arquivo = new Arquivo();
            arquivo.Tamanho = 2971491348;
            Assert.AreEqual("2,77GB", arquivo.TamanhoFormatado());
        }
    }
}
