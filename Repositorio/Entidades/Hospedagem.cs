using System;

/*
 * Criado em: 09/11/21
 */

namespace Repositorio.Entidades
{
    public class Hospedagem
    {
        public Hospedagem()
        {

        }

        #region Propriedades

        public virtual int Id { get; set; }

        public virtual DateTime DataInicio { get; set; }
        public virtual DateTime DataFinal { get; set; }
        public virtual string ObservacaoFinal { get; set; }
        public virtual decimal ValorMensal { get; set; }

        #endregion Propriedades


        #region Relacionamentos
        public virtual Animal Animal { get; set; }
        public virtual LarTemporario LarTemporario { get; set; }
        public virtual Entidade Entidade { get; set; }

        #endregion Relacionamentos
    }
}
