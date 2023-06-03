using Repositorio.Entidades;
using System.Collections.Generic;

/*
 * Criado em: 29/05/23
 */

namespace Repositorio.Interfaces
{
    public interface IColaboradorExternoService
    {
        IEnumerable<ColaboradorExterno> GetColaboradorExternosAtivos(int idEntidade);
    }
}
