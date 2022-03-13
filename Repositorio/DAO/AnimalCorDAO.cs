using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAO
{
    public class AnimalCorDAO : RepositorioCrudDao<AnimalCor>
    {
        public static int Salvar(AnimalCor cor)
        {
            return (int)new AnimalCorDAO().Inserir(cor);
        }

        public static bool Atualizar(AnimalCor cor)
        {
            return new AnimalCorDAO().Alterar(cor);
        }

        public static string Apagar(AnimalCor cor)
            => new AnimalCorDAO().Excluir(cor);
        
        public static List<AnimalCor> GetTodosRegistros(int entidadeId)
        {
            return new AnimalCorDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
        }
    }
}
