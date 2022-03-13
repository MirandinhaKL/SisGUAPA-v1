using Repositorio.ClassesGerais;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Classes
{
    public class EntidadeDAO : RepositorioCrudDao<Entidade>
    {
        public static bool Salvar(Entidade entidade)
            => new EntidadeDAO().SalvarOuAtualizar(entidade);

        public static string Apagar(Entidade entidade)
            => new EntidadeDAO().Excluir(entidade);

        public static Entidade GetEntidade(int entidadeId)
        {
            var entidades = new EntidadeDAO().Consultar(entidadeId).ToList();
            var usuariosInstituicao = entidades?.Where(k => k.Id == entidadeId);
            return usuariosInstituicao.FirstOrDefault();
        }

    }
}
