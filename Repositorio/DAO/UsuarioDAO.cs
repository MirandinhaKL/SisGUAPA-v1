using NHibernate;
using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Classes
{
    public class UsuarioDAO : RepositorioCrudDao<Usuario>
    {
        public static Usuario Global { get; private set; }

        public static Usuario GetPorEmail(string email)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                return Session.Query<Usuario>().Where(k => k.Email == email).FirstOrDefault();
            }
        }

        public Usuario ValidarLogin(string email, string senha)
        {
            var usuario = GetPorEmail(email);

            if (usuario != null)
            {
                if (usuario.Senha == senha)
                    return usuario;
                else
                {
                    usuario.Id = -1;
                    return usuario;
                }
            }
            return new Usuario();
        }

        public static string Apagar(Usuario usuario)
           => new UsuarioDAO().Excluir(usuario);

        public static bool Salvar(Usuario usuario)
            => new UsuarioDAO().SalvarOuAtualizar(usuario);

        public static List<Usuario> GetTodosRegistrosSemAministrador(int entidadeId)
        {
            var usuarios = new UsuarioDAO().Consultar(entidadeId).ToList();
            var usuariosInstituicao = usuarios?.Where(k => k.Entidade?.Id == entidadeId).ToList();
            
            // remover o administrador
            var usuarioEntidade = usuariosInstituicao.Find(k => k.Id == entidadeId);
            usuariosInstituicao.Remove(usuarioEntidade);
            return usuariosInstituicao;
        }

        public static List<Usuario> GetTodosRegistros(int entidadeId)
        {
            var usuarios = new UsuarioDAO().Consultar(entidadeId).ToList();
            return usuarios?.Where(k => k.Entidade?.Id == entidadeId).ToList();
        }

        public static Usuario LoadEntidadeById(int usarioId)
        {
            return new UsuarioDAO().GetPorId(usarioId);
        }
    }
}
