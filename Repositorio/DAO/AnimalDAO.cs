using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.DAO
{
    public class AnimalDAO : RepositorioCrudDao<Animal>
    {
        public static bool Salvar(Animal animal)
            => new AnimalDAO().SalvarOuAtualizar(animal);


        public static string Apagar(Animal animal) 
            => new AnimalDAO().Excluir(animal);

        public static List<Animal> GetTodosRegistros(int entidadeId)
        {
            var animais = new AnimalDAO().Consultar(entidadeId).ToList();
            var animaisInstituição = animais?.Where(k => k.Entidade?.Id == entidadeId);
            return animaisInstituição.ToList();
        }
       
        public static Animal GetById(int id)
           => new AnimalDAO().GetPorId(id);

    }
}
