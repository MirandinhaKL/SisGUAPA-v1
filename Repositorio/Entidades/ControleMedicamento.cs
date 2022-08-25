using System;

/*
 * Criada em: 26/11/2021
 */
namespace Repositorio.Entidades
{
    public class ControleMedicamento
    {
        public ControleMedicamento()
        {

        }

        public virtual int Id { get; protected set; }
        public virtual DateTime DataExecucao { get; set; }
        public virtual int EnumStatusControleMedicação { get; set; }

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }
        public virtual Tratamento Tratamento { get; set; }
        public virtual Medicamento Medicamento { get; set; }
        
        //public virtual Atendimento Atendimento { get; set; }

        #endregion
    }
}
