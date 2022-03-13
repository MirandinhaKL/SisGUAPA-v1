using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAO
{
    public class AnimalPorteDAO : RepositorioCrudDao<AnimalPorte>
    {
        public static int Salvar(AnimalPorte porte)
        {
            return (int) new AnimalPorteDAO().Inserir(porte);
        }

        public static bool Atualizar(AnimalPorte porte)
        {
            return new AnimalPorteDAO().Alterar(porte);
        }

        public static string Apagar(AnimalPorte porte)
            => new AnimalPorteDAO().Excluir(porte);
        

        public static List<AnimalPorte> GetTodosRegistros(int entidadeId)
        {
            return new AnimalPorteDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
        }
    }
}
