using System;

/*
 * Criada em: 23/11/2021
 */
namespace Repositorio.Entidades
{
    public class Tratamento
    {
        public Tratamento()
        {

        }

        public virtual int Id { get; protected set; }
        public virtual int EnumStatusTratamento { get; set; }

        public virtual Medicamento Medicamento1 { get; set; }
        public virtual Medicamento Medicamento2 { get; set; }
        public virtual Medicamento Medicamento3 { get; set; }
        public virtual Medicamento Medicamento4 { get; set; }
        public virtual Medicamento Medicamento5 { get; set; }

        public virtual int EnumStatusMedicacao1 { get; set; }
        public virtual int EnumStatusMedicacao2 { get; set; }
        public virtual int EnumStatusMedicacao3 { get; set; }
        public virtual int EnumStatusMedicacao4 { get; set; }
        public virtual int EnumStatusMedicacao5 { get; set; }

        public virtual DateTime InicioMedicacao1 { get; set; }
        public virtual DateTime InicioMedicacao2 { get; set; }
        public virtual DateTime InicioMedicacao3 { get; set; }
        public virtual DateTime InicioMedicacao4 { get; set; }
        public virtual DateTime InicioMedicacao5 { get; set; }

        public virtual DateTime FimMedicacao1 { get; set; }
        public virtual DateTime FimMedicacao2 { get; set; }
        public virtual DateTime FimMedicacao3 { get; set; }
        public virtual DateTime FimMedicacao4 { get; set; }
        public virtual DateTime FimMedicacao5 { get; set; }

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }
        public virtual Atendimento Atendimento { get; set; }
        

        #endregion
    }
}
