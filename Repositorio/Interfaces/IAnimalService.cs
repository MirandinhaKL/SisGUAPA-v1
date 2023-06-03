using Repositorio.Entidades;
using System;
using System.Collections.Generic;

/*
 * Criado em: 01/05/23 
 * Atualizado em: 23/05/23
 */

namespace Repositorio.Interfaces
{
    public interface IAnimalService
    {
        List<Animal> GetAnimais(int idEntidade);

        string GetIdade(DateTime nascimento);

        bool SalvarOuAtualizarAnimal(Animal animal);

        string GetDadosResumidos(Animal animal);

        bool SalvarOuAtualizarCor(AnimalCor cor);

        List<AnimalCor> GetCoresOrdenadasPorNome(int idEntidade);

        string ExcluirCor(AnimalCor cor);

        bool SalvarOuAtualizarPorte(AnimalPorte porte);

        List<AnimalPorte> GetPortesOrdenadosPorNome(int idEntidade);

        string ExcluirPorte(AnimalPorte porte);

        bool SalvarOuAtualizarEspecie(AnimalEspecie especie);

        List<AnimalEspecie> GetEspeciesOrdenadasPorNome(int idEntidade);

        string ExcluirEspecie(AnimalEspecie especie);

        bool SalvarOuAtualizarMotivoRecolhimento(MotivoRecolhimento motivo);

        List<MotivoRecolhimento> GetMotivosRecolhimentosOrdenadosPorNome(int idEntidade);

        string ExcluirMotivoRecolhimento(MotivoRecolhimento motivo);

        bool SalvarOuAtualizarMotivoFalecimento(MotivoFalecimento motivo);

        List<MotivoFalecimento> GetMotivosFalecimentoOrdenadosPorNome(int idEntidade);

        string ExcluirMotivoFalecimento(MotivoFalecimento motivo);

        bool SalvarOuAtualizarRecolhimento(Recolhimento recolhimento);

        string ExcluirRecolhimento(Recolhimento recolhimento);

        Recolhimento GetDadosRecolhimentoById(int idAnimal);

        EnderecoRecolhimento GetEnderecoRecolhimentoById(int idAnimal);

        void SalvarDadosIniciaisDoSistema(Entidade entidade);
    }
}
