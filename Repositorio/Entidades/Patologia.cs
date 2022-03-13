using System;

/*
 * Criada em: 15/11/2021
 */
namespace Repositorio.Entidades
{
    public class Patologia
    {
        public Patologia()
        {

        }

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }


        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }
        public virtual Atendimento Atendimento { get; set; }
        
        #endregion
    }
}
