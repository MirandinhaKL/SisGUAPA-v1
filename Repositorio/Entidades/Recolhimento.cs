using System;

/*
 * Alterado em: 15/05/23
 */

namespace Repositorio.Entidades
{
    public class Recolhimento
    {
        #region Propriedades

        public virtual int Id { get; set; }
        public virtual DateTime DataRecolhimento { get; set; }
        public virtual string Recolhedor { get; set; }
        public virtual string Observacao { get; set; }
        public virtual string Telefone { get; set; }

        #endregion

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }

        public virtual Animal Animal { get; set; }

        public virtual MotivoRecolhimento MotivoRecolhimento { get; set; }

        public virtual EnderecoRecolhimento EnderecoRecolhimento { get; set; }

        public virtual void SetEnderecoRecolhimento(EnderecoRecolhimento endereco)
        {
            endereco.Recolhimento = this;
            EnderecoRecolhimento = endereco;
        }

        public virtual void SetMotivoRecolhimento(MotivoRecolhimento motivo)
        {
            motivo.Recolhimento = this;
            MotivoRecolhimento = motivo;
        }

        #endregion
    }
}
