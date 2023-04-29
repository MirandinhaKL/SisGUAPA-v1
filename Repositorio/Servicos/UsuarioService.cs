using Repositorio.Classes;
using Repositorio.Entidades;
using Repositorio.Interfaces;

namespace Repositorio.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        public int SalvarUsuario(Usuario usuario)
        {
            return (int)new UsuarioDAO().Inserir(usuario);
        }
    }
}