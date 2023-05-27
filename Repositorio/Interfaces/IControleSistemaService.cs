using Repositorio.Entidades;

/*
 * Criada em: 22/05/23
 */
namespace Repositorio.Interfaces
{
    public interface IControleSistemaService
    {
        void RegistrarCriacaoBaseDados();

        void RegistrarCriacaoEntidade(Entidade entidade);
    }
}