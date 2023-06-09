using Dominio.Enums;
using Repositorio.Classes;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

/*
 * Criado em: 29/05/23
 * Alterado em: 06/06/23
 */
namespace Repositorio.Servicos
{
    public class ColaboradorExternoService : IColaboradorExternoService
    {
        public void SalvarDadosIniciaisDoSistema(Entidade entidade)
        {
            var colaboradores = GetColaboradoresMoqDados(entidade);

            foreach (var item in colaboradores)
                SalvarOuAtualizarColaborador(item);
        }

        public List<ColaboradorExterno> GetColaboradorExternosAtivos(int idEntidade)
        {
            var colaboradores = ColaboradorExternoDAO.GetTodosRegistros(idEntidade).
               Where(k => k.Status != (int)EnumPessoa.EnumStatusUsuario.Inativo).ToList();
            return colaboradores;
        }

        public bool SalvarOuAtualizarColaborador(ColaboradorExterno colaborador)
        {
            ColaboradorExternoDAO colaboradorDAO = new ColaboradorExternoDAO();
            return colaboradorDAO.SalvarOuAtualizar(colaborador);
        }

        public bool InativarColaborador(ColaboradorExterno colaborador)
        {
            colaborador.Status = (int)EnumPessoa.EnumStatusUsuario.Inativo;
            ColaboradorExternoDAO colaboradorDAO = new ColaboradorExternoDAO();
            bool status = colaboradorDAO.SalvarOuAtualizar(colaborador);
            return status;
        }

        private List<ColaboradorExterno> GetColaboradoresMoqDados(Entidade entidade)
        {
            var enderecos = GetEnderecoColaboradorMoqDados(entidade);

            var colaboradores = new List<ColaboradorExterno>
            {
                new ColaboradorExterno(){Entidade = entidade, NomeColaborador = "Colaborador 0", Cargo = "Zelador", Email = "colab0@gmail.com",
                NomeEmpresa = "Vigilancia", Status = (int)EnumPessoa.EnumStatusUsuario.Inativo, Telefone = "34 XXXX-XXXX" },

                new ColaboradorExterno(){Entidade = entidade, NomeColaborador = "Colaborador 1", Cargo = "Veterinária", Email = "colab1@gmail.com",
                NomeEmpresa = "Clínica Bixo Feliz", Status = (int)EnumPessoa.EnumStatusUsuario.Ativo, Telefone = "54 XXXX-XXXX" },

                new ColaboradorExterno(){Entidade = entidade, NomeColaborador = "Colaborador 2", Cargo = "Cuidadora", Email = "colab2@gmail.com",
                NomeEmpresa = "PetShop Alegria", Status = (int)EnumPessoa.EnumStatusUsuario.Ativo, Telefone = "94 XXXX-XXXX" }
            };

            colaboradores[1].SetEnderecoColaborador(enderecos[0]);
            colaboradores[2].SetEnderecoColaborador(enderecos[1]);

            return colaboradores;
        }

        private List<EnderecoColaboradorExterno> GetEnderecoColaboradorMoqDados(Entidade entidade)
        {
            return new List<EnderecoColaboradorExterno>()
            {
                new EnderecoColaboradorExterno(){Entidade = entidade, Estado = 21, Bairro = "Volta Grande", Cidade = "Farroupilha",
                Complemento = "Prédio verde", Logradouro = "Rua Pedro Grendene", Numero = "500", CEP = "95180000" },

                new EnderecoColaboradorExterno(){Entidade = entidade, Estado = 21, Bairro = "Niterói", Cidade = "Canoas", Complemento = "Casa 5",
                Logradouro = "Rua Tamoio", Numero = "2024", CEP = "90625000" }
            };
        }
    }
}
