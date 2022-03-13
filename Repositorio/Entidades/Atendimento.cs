using System;

/*
 * Criada em: 03/11/2021
 */
namespace Repositorio.Entidades
{
    public class Atendimento
    {
        public Atendimento()
        {

        }

        public virtual int Id { get; set; }
        public virtual DateTime DataAtendimentoInicio { get; set; }
        public virtual DateTime DataAtendimentoFim { get; set; }
        public virtual string Observacao { get; set; }
        public virtual int StatusRealizacaoAtendimento { get; set; }

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Usuario ColaboradorInterno { get; set; }
        public virtual ColaboradorExterno ColaboradorExterno { get; set; }
        public virtual TipoAtendimento TipoAtendimento { get; set; }
        public virtual PreAtendimento PreAtendimento { get; set; }
        public virtual Patologia Patologia { get; set; }
        public virtual Tratamento Tratamento { get; set; }

        #endregion
    }
}
