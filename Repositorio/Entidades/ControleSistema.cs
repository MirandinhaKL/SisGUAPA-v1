using System;

/*
 * Criado em: 19/05/23
 */
namespace Repositorio.Entidades
{
    public class ControleSistema
    {
        public virtual int Id { get; protected set; }

        public virtual string Acao { get; set; }

        public virtual DateTime DataDaAcao { get; set; }

        public virtual Entidade Entidade { get; set; }
    }
}