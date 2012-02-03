using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ConfiguracoesGeraisServico
    {
        private readonly IConfiguracoesGeraisDAO _configuracoesGeraisDAO;
        public ConfiguracoesGeraisServico(IConfiguracoesGeraisDAO configuracoesGeraisDAO)
        {
            _configuracoesGeraisDAO = configuracoesGeraisDAO;
        }

        public ConfiguracoesGerais Pesquisar()
        {
            var lista = _configuracoesGeraisDAO.GetAll();
            
            // Se não existir cria uma nova configuração
            if (lista == null || lista.Count == 0)
            {
                var configuracoesGerais = new ConfiguracoesGerais();
                configuracoesGerais.TamanhoMinimoArquivos = 2971491348;
                configuracoesGerais.TiposArquivosPadrao = "*.mkv";
                _configuracoesGeraisDAO.Save(configuracoesGerais);
                return configuracoesGerais;
            }
            return lista.First();
        }

        public void Salvar(ConfiguracoesGerais configuracoesGerais)
        {
            _configuracoesGeraisDAO.Save(configuracoesGerais);
        }
    }
}