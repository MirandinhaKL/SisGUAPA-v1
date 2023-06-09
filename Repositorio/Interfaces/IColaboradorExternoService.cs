using Repositorio.Entidades;
using System.Collections.Generic;

/*
 * Criado em: 29/05/23
 * Alterado em: 06/06/23
 */

namespace Repositorio.Interfaces
{
    public interface IColaboradorExternoService
    {
        void SalvarDadosIniciaisDoSistema(Entidade entidade);

        List<ColaboradorExterno> GetColaboradorExternosAtivos(int idEntidade);

        bool SalvarOuAtualizarColaborador(ColaboradorExterno colaborador);

        bool InativarColaborador(ColaboradorExterno colaborador);
    }
}
