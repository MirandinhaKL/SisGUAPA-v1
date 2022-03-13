using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface ICrudDao<T>
    {
        object Inserir(T entidade);
        bool Alterar(T entidade);
        string Excluir(T entidade);
        T GetPorId(int id);
        IList<T> Consultar(int EntidadeId);
    }
}
