using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAO
{
    public class AnimalEspecieDAO : RepositorioCrudDao<AnimalEspecie>
    {
        public static int Salvar(AnimalEspecie especie)
        {
            return (int)new AnimalEspecieDAO().Inserir(especie);
        }

        public static bool Atualizar(AnimalEspecie especie)
        {
            return new AnimalEspecieDAO().Alterar(especie);
        }

        public static string Apagar(AnimalEspecie especie)
            => new AnimalEspecieDAO().Excluir(especie);

        public static List<AnimalEspecie> GetTodosRegistros(int entidadeId)
        {
            return new AnimalEspecieDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList(); 
        }
    }
}
