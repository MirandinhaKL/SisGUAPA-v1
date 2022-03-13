using System;
/*
 * Criado em: 18/11/21
 */
namespace Repositorio.Entidades
{
    public class PreAtendimento
    {
        public PreAtendimento()
        {
            
        }

        public virtual int Id { get; protected set; }
        public virtual DateTime DataPreAtendimento { get; set; }
        public virtual int enumStatusPreAtendimento { get; set; }

        // Relacionamentos

        public virtual Entidade Entidade { get; set; }
        public virtual Atendimento Atendimento { get; set; }
        public virtual TipoAtendimento TipoAtendimento { get; set; }
    }

}
