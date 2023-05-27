using Repositorio.DAO;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;

/*
 * Criado em: 19/05/23
 */
namespace Repositorio.Servicos
{
    public class ControleSistemaService : IControleSistemaService
    {
        public ControleSistemaService()
        {

        }

        public void RegistrarCriacaoBaseDados()
        {
            var controleDAO = new ControleSistemaDAO();
            var dados = controleDAO.Consultar(1);

            if (dados.Count == 0)
            {
                var controle = new ControleSistema()
                {
                    DataDaAcao = DateTime.Now,
                    Acao = "CRIACAO DA BASE DE DADOS"
                };
                controleDAO.Inserir(controle);
            }
        }

        public void RegistrarCriacaoEntidade(Entidade entidade)
        {
            var controle = new ControleSistema()
            {
                DataDaAcao = DateTime.Now,
                Acao = $"ENTIDADE CADASTRADA - {entidade.Id} - {entidade.Nome}"
            };
            var controleDAO = new ControleSistemaDAO();
            controleDAO.Inserir(controle);
        }
    }
}