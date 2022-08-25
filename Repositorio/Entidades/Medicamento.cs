/*
 * Criado em: 22/11/21
 * última alteração em:
 */

using System.Collections.Generic;

namespace Repositorio.Entidades
{
    public class Medicamento
    {
        public Medicamento() 
        {
            //ControlesMedicamento = new List<ControleMedicamento>();
        }

        #region PropriedadesHibernate

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual int EnumUnidadeMedicamentos { get; set; }
        public virtual int Duracao { get; set; }
        public virtual int EnumFrequenciaIngestao { get; set; }
        public virtual int AuxiliarX { get; set; }
        public virtual int AuxiliarY { get; set; }
        public virtual string DiasDaSemana { get; set; }
        public virtual decimal Quantidade { get; set; }

        #endregion

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }
        //public virtual IList<ControleMedicamento> ControlesMedicamento { get; protected set; }

        //public virtual void AddControleMedicamento(ControleMedicamento controle)
        //{
        //    controle.Medicamento = this;
        //    ControlesMedicamento.Add(controle);
        //}

        //public virtual void RemoveAdocao(ControleMedicamento controle)
        //{
        //    controle.Medicamento = this;
        //    ControlesMedicamento.Remove(controle);
        //}

        #endregion
    }
}
