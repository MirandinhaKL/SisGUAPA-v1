using Repositorio.DAO;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Criado em: 01/05/23
 * Atualizado em: 25/05/23
 */

namespace Repositorio.Servicos
{
    public class AnimalService : IAnimalService
    {
        public void SalvarDadosIniciaisDoSistema(Entidade entidade)
        {
            var cores = GetCoresMoqDados(entidade);
            var portes = GetPortesMoqDados(entidade);
            var especies = GetEspeiciesMoqDados(entidade);
            var motivosFalecimento = GetMotivosFalecimentosMoqDados(entidade);
            var motivosRecolhimento = GetMotivosRecolhimentosMoqDados(entidade);

            foreach (var item in cores)
                SalvarOuAtualizarCor(item);

            foreach (var item in portes)
                SalvarOuAtualizarPorte(item);

            foreach (var item in especies)
                SalvarOuAtualizarEspecie(item);

            foreach (var item in motivosFalecimento)
                SalvarOuAtualizarMotivoFalecimento(item);

            foreach (var item in motivosRecolhimento)
                SalvarOuAtualizarMotivoRecolhimento(item);

            var animais = GetAnimaisMoqados(entidade);

            foreach (var item in animais)
                SalvarOuAtualizarAnimal(item);
        }

        public List<Animal> GetAnimais(int idEntidade)
        {
            return AnimalDAO.GetTodosRegistros(idEntidade).OrderBy(k => k.Nome).ToList();
        }

        public bool SalvarOuAtualizarAnimal(Animal animal)
        {
            AnimalDAO animalDAO = new AnimalDAO();
            return animalDAO.SalvarOuAtualizar(animal);
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

        #region motivoFalecimento

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

        #region dadosRecolhimento

        public bool SalvarOuAtualizarRecolhimento(Recolhimento recolhimento)
        {
            RecolhimentoDAO recolhimentoDAO = new RecolhimentoDAO();
            return recolhimentoDAO.SalvarOuAtualizar(recolhimento);
        }

        public string ExcluirRecolhimento(Recolhimento recolhimento)
        {
            RecolhimentoDAO recolhimentoDAO = new RecolhimentoDAO();
            return recolhimentoDAO.Excluir(recolhimento);
        }

        public Recolhimento GetDadosRecolhimentoById(int idAnimal)
        {
            RecolhimentoDAO recolhimentoDAO = new RecolhimentoDAO();
            return recolhimentoDAO.GetPorId(idAnimal);
        }

        public EnderecoRecolhimento GetEnderecoRecolhimentoById(int idAnimal)
        {
            EnderecoRecolhimentoDAO enderecoDAO = new EnderecoRecolhimentoDAO();
            return enderecoDAO.GetPorId(idAnimal);
        }

        #endregion

        #region DadosMoqados

        private List<AnimalCor> GetCoresMoqDados(Entidade entidade)
        {
            return new List<AnimalCor>
            {
                new AnimalCor() { Descricao = "Amarelo", Entidade = entidade },
                new AnimalCor() { Descricao = "Branco", Entidade = entidade },
                new AnimalCor() { Descricao = "Preto e Branco", Entidade = entidade },
                new AnimalCor() { Descricao = "Preto", Entidade = entidade },
                new AnimalCor() { Descricao = "Marrom", Entidade = entidade },
                new AnimalCor() { Descricao = "Marrom e Branco", Entidade = entidade }
            };
        }

        private List<AnimalPorte> GetPortesMoqDados(Entidade entidade)
        {
            return new List<AnimalPorte>
            {
                new AnimalPorte(){Descricao = "PP", Entidade = entidade},
                new AnimalPorte(){Descricao = "P", Entidade = entidade},
                new AnimalPorte(){Descricao = "M", Entidade = entidade},
                new AnimalPorte(){Descricao = "G", Entidade = entidade},
                new AnimalPorte(){Descricao = "EG", Entidade = entidade}
            };
        }

        private List<AnimalEspecie> GetEspeiciesMoqDados(Entidade entidade)
        {
            return new List<AnimalEspecie>
            {
                new AnimalEspecie(){Descricao = "Gato", Entidade = entidade},
                new AnimalEspecie(){Descricao = "Cachorro", Entidade = entidade},
                new AnimalEspecie(){Descricao = "Cavalo", Entidade = entidade}
            };
        }

        private List<MotivoFalecimento> GetMotivosFalecimentosMoqDados(Entidade entidade)
        {
            return new List<MotivoFalecimento>
            {
                new MotivoFalecimento(){Descricao = "Idade", Entidade = entidade},
                new MotivoFalecimento(){Descricao = "FIV", Entidade = entidade},
                new MotivoFalecimento(){Descricao = "FELV", Entidade = entidade},
                new MotivoFalecimento(){Descricao = "Sinomose", Entidade = entidade},
                new MotivoFalecimento(){Descricao = "Hepatite", Entidade = entidade}
            };
        }

        private List<MotivoRecolhimento> GetMotivosRecolhimentosMoqDados(Entidade entidade)
        {
            return new List<MotivoRecolhimento>
            {
                new MotivoRecolhimento(){Descricao = "Abandono", Entidade = entidade},
                new MotivoRecolhimento(){Descricao = "Maus-tratos", Entidade = entidade},
                new MotivoRecolhimento(){Descricao = "Nasceu na instituição", Entidade = entidade},
            };
        }

        private List<Animal> GetAnimaisMoqados(Entidade entidade)
        {
            List<Animal> animais = new List<Animal>();

            var cores = GetCoresOrdenadasPorNome(entidade.Id);
            var especies = GetEspeciesOrdenadasPorNome(entidade.Id);
            var portes = GetPortesOrdenadosPorNome(entidade.Id);
            var motivosRecolhimento = GetMotivosRecolhimentosOrdenadosPorNome(entidade.Id);

            #region animal1

            var animal1 = new Animal()
            {
                AnimalCor = cores.Where(k => k.Descricao.ToLower() == "Marrom e Branco".ToLower()).FirstOrDefault(),
                AnimalEspecie = especies.Where(k => k.Descricao.ToLower() == "Cachorro".ToLower()).FirstOrDefault(),
                AnimalPorte = portes.Where(k => k.Descricao.ToLower() == "M".ToLower()).FirstOrDefault(),
                AnimalStatus = 0,
                Castrado = 1,
                DataCadastro = DateTime.Today,
                DataNascimento = new DateTime(2008, 10, 1),
                Deficiencia = string.Empty,
                Genero = 1,
                Identificacao = "CAO01",
                Nome = "William Wallace",
                Peso = 15,
                Raca = "ND",
                Entidade = entidade
            };

            var recolhimento1 = new Recolhimento()
            {
                DataRecolhimento = new DateTime(2012, 09, 15),
                Observacao = "Atropelado, tutor se negou a prestar atendimento.",
                Recolhedor = "Arlene",
                Entidade = entidade,
                Telefone = "54 99999-9999",
            };

            var motivoRecolhimento1 = motivosRecolhimento.Where(k => k.Descricao.ToLower() == "Maus-tratos".ToLower()).FirstOrDefault();
            recolhimento1.SetMotivoRecolhimento(motivoRecolhimento1);

            var enderecoRecolhimento1 = new EnderecoRecolhimento()
            {
                Entidade = entidade,
                Estado = 21,
                Bairro = "Volta Grande",
                Cidade = "Farroupilha",
                Complemento = "Igreja evangélica",
                Logradouro = "Rua Pedro Grendene",
                Numero = "500",
                CEP = "95180000"
            };

            recolhimento1.SetEnderecoRecolhimento(enderecoRecolhimento1);
            animal1.SetDadosRecolhimento(recolhimento1);

            #endregion

            #region animal2

            var animal2 = new Animal()
            {
                AnimalCor = cores.Where(k => k.Descricao.ToLower() == "Branco".ToLower()).FirstOrDefault(),
                AnimalEspecie = especies.Where(k => k.Descricao.ToLower() == "Cachorro".ToLower()).FirstOrDefault(),
                AnimalPorte = portes.Where(k => k.Descricao.ToLower() == "P".ToLower()).FirstOrDefault(),
                AnimalStatus = 2, // morto
                Castrado = 1,
                DataCadastro = new DateTime(2020, 01, 14),
                DataNascimento = new DateTime(2002, 06, 1),
                Deficiencia = string.Empty,
                Genero = 0, // F
                Identificacao = "CAO02",
                Nome = "Dominick",
                Peso = 15,
                Raca = "Poodle",
                Entidade = entidade
            };

            var recolhimento2 = new Recolhimento()
            {
                DataRecolhimento = new DateTime(2020, 01, 14),
                Observacao = "Lado da Madernit",
                Recolhedor = "Karine",
                Entidade = entidade,
                Telefone = "54 99999-9998",
            };

            var motivoRecolhimento2 = motivosRecolhimento.Where(k => k.Descricao.ToLower() == "Nasceu na instituição".ToLower()).FirstOrDefault();
            recolhimento2.SetMotivoRecolhimento(motivoRecolhimento2);

            var enderecoRecolhimento2 = new EnderecoRecolhimento()
            {
                Entidade = entidade,
                Estado = 21,
                Bairro = "Niterói",
                Cidade = "Canoas",
                Complemento = "Casa 5",
                Logradouro = "Rua Tamoio",
                Numero = "2024",
                CEP = "90625000"
            };

            recolhimento2.SetEnderecoRecolhimento(enderecoRecolhimento2);
            animal2.SetDadosRecolhimento(recolhimento2);

            #endregion

            #region animal3

            var animal3 = new Animal()
            {
                AnimalCor = cores.Where(k => k.Descricao.ToLower() == "Marrom".ToLower()).FirstOrDefault(),
                AnimalEspecie = especies.Where(k => k.Descricao.ToLower() == "Gato".ToLower()).FirstOrDefault(),
                AnimalPorte = portes.Where(k => k.Descricao.ToLower() == "G".ToLower()).FirstOrDefault(),
                AnimalStatus = 0,
                Castrado = 1,
                DataCadastro = new DateTime(2020, 07, 10),
                DataNascimento = new DateTime(2020, 05, 1),
                Deficiencia = string.Empty,
                Genero = 1, //m
                Identificacao = "GAT01",
                Nome = "Inhonho Milanda",
                Peso = 9,
                Raca = "Sagrado da Birmânia",
                Entidade = entidade
            };

            var recolhimento3 = new Recolhimento()
            {
                DataRecolhimento = new DateTime(2020, 07, 10),
                Observacao = "Doado.",
                Recolhedor = "Karine",
                Entidade = entidade,
                Telefone = "54 99999-9997",
            };

            var motivoRecolhimento3 = motivosRecolhimento.Where(k => k.Descricao.ToLower() == "Abandono".ToLower()).FirstOrDefault();
            recolhimento3.SetMotivoRecolhimento(motivoRecolhimento3);

            var enderecoRecolhimento3 = new EnderecoRecolhimento()
            {
                Entidade = entidade,
                Estado = 21,
                Bairro = "Nova Vicenza",
                Cidade = "Farroupilha",
                Complemento = "Técnico da NET",
                Logradouro = "Pinheiro Machado",
                Numero = "2023",
                CEP = "95180000"
            };

            recolhimento3.SetEnderecoRecolhimento(enderecoRecolhimento3);
            animal3.SetDadosRecolhimento(recolhimento3);

            #endregion

            animais.Add(animal1);
            animais.Add(animal2);
            animais.Add(animal3);

            return animais;
        }

        #endregion
    }
}