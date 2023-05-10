using Repositorio.DAO;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

/*
 * Criado em: 01/05/23
 */

namespace Repositorio.Servicos
{
    public class AnimalService : IAnimalService
    {
        public List<Animal> GetAnimais(int idEntidade)
        {
            return AnimalDAO.GetTodosRegistros(idEntidade).OrderBy(k => k.Nome).ToList();
        }

        #region cor

        public bool SalvarOuAtualizarCor(AnimalCor cor)
        {
            AnimalCorDAO corDAO = new AnimalCorDAO();
            return corDAO.SalvarOuAtualizar(cor);
        }
        
        public List<AnimalCor> GetCoresOrdenadasPorNome(int idEntidade)
        {
            List<AnimalCor> cores = AnimalCorDAO.GetTodosRegistros(idEntidade);
            cores = cores.OrderBy(k => k.Descricao).ToList();
            return cores;
        }

        public string ExcluirCor(AnimalCor cor)
        {
            AnimalCorDAO corDAO = new AnimalCorDAO();
            return corDAO.Excluir(cor);
        }

        #endregion cor

        #region porte

        public bool SalvarOuAtualizarPorte(AnimalPorte porte)
        {
            AnimalPorteDAO porteDAO = new AnimalPorteDAO();
            return porteDAO.SalvarOuAtualizar(porte);
        }

        public List<AnimalPorte> GetPortesOrdenadosPorNome(int idEntidade)
        {
            List<AnimalPorte> portes = AnimalPorteDAO.GetTodosRegistros(idEntidade);
            portes = portes.OrderBy(k => k.Descricao).ToList();
            return portes;
        }

        public string ExcluirPorte(AnimalPorte porte)
        {
            AnimalPorteDAO porteDAO = new AnimalPorteDAO();
            return porteDAO.Excluir(porte);
        }
        
        #endregion porte

        #region especie

        public bool SalvarOuAtualizarEspecie(AnimalEspecie especie)
        {
            AnimalEspecieDAO especieDAO = new AnimalEspecieDAO();
            return especieDAO.SalvarOuAtualizar(especie);
        }

        public List<AnimalEspecie> GetEspeciesOrdenadasPorNome(int idEntidade)
        {
            List<AnimalEspecie> especies = AnimalEspecieDAO.GetTodosRegistros(idEntidade);
            especies = especies.OrderBy(k => k.Descricao).ToList();
            return especies;
        }

        public string ExcluirEspecie(AnimalEspecie especie)
        {
            AnimalEspecieDAO especieDAO = new AnimalEspecieDAO();
            return especieDAO.Excluir(especie);
        }

        #endregion

        #region motivoDeRecolhimento

        public bool SalvarOuAtualizarMotivoRecolhimento(MotivoRecolhimento motivo)
        {
            MotivoRecolhimentoDAO motivoDAO = new MotivoRecolhimentoDAO();
            return motivoDAO.SalvarOuAtualizar(motivo);
        }

        public List<MotivoRecolhimento> GetMotivosRecolhimentosOrdenadosPorNome(int idEntidade)
        {
            List<MotivoRecolhimento> motivos = MotivoRecolhimentoDAO.GetTodosRegistros(idEntidade);
            motivos = motivos.OrderBy(k => k.Descricao).ToList();
            return motivos;
        }

        public string ExcluirMotivoRecolhimento(MotivoRecolhimento motivo)
        {
            MotivoRecolhimentoDAO motivoDAO = new MotivoRecolhimentoDAO();
            return motivoDAO.Excluir(motivo);
        }

        #endregion

        #region MotivoFalecimento

        public bool SalvarOuAtualizarMotivoFalecimento(MotivoFalecimento motivo)
        {
            MotivoFalecimentoDAO motivoDAO = new MotivoFalecimentoDAO();
            return motivoDAO.SalvarOuAtualizar(motivo);
        }

        public List<MotivoFalecimento> GetMotivosFalecimentoOrdenadosPorNome(int idEntidade)
        {
            List<MotivoFalecimento> motivos = MotivoFalecimentoDAO.GetTodosRegistros(idEntidade);
            motivos = motivos.OrderBy(k => k.Descricao).ToList();
            return motivos;
        }

        public string ExcluirMotivoFalecimento(MotivoFalecimento motivo)
        {
            MotivoFalecimentoDAO motivoDAO = new MotivoFalecimentoDAO();
            return motivoDAO.Excluir(motivo);
        }

        #endregion
    }
}