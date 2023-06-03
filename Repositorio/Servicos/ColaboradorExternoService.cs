using Dominio.Enums;
using Repositorio.Classes;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

/*
 * Criado em: 29/05/23
 */
namespace Repositorio.Servicos
{
    public class ColaboradorExternoService : IColaboradorExternoService
    {
        public IEnumerable<ColaboradorExterno> GetColaboradorExternosAtivos(int idEntidade)
        {
            var colaboradores = ColaboradorExternoDAO.GetTodosRegistros(idEntidade)
                .ToList().Where(k => k.Status != (int)EnumPessoa.EnumStatusUsuario.Inativo);
            return colaboradores;
        }
    }
}
