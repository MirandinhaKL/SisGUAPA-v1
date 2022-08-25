using System;
using System.Collections.Generic;

/*
 * Criada em: 23/11/2021
 */
namespace Repositorio.Entidades
{
    public class Tratamento
    {
        public Tratamento()
        {
            ControlesMedicamento1 = new List<ControleMedicamento>();
            ControlesMedicamento2 = new List<ControleMedicamento>();
            ControlesMedicamento3 = new List<ControleMedicamento>();
            ControlesMedicamento4 = new List<ControleMedicamento>();
            ControlesMedicamento5 = new List<ControleMedicamento>();
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

        public virtual IList<ControleMedicamento> ControlesMedicamento1 { get; protected set; }
        public virtual IList<ControleMedicamento> ControlesMedicamento2 { get; protected set; }
        public virtual IList<ControleMedicamento> ControlesMedicamento3 { get; protected set; }
        public virtual IList<ControleMedicamento> ControlesMedicamento4 { get; protected set; }
        public virtual IList<ControleMedicamento> ControlesMedicamento5 { get; protected set; }

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }
        public virtual Atendimento Atendimento { get; set; }

        public virtual void AddControleMedicamento1(ControleMedicamento controle)
        {
            controle.Tratamento = this;
            ControlesMedicamento1.Add(controle);
        }

        public virtual void AddControleMedicamento2(ControleMedicamento controle)
        {
            controle.Tratamento = this;
            ControlesMedicamento2.Add(controle);
        }

        public virtual void AddControleMedicamento3(ControleMedicamento controle)
        {
            controle.Tratamento = this;
            ControlesMedicamento3.Add(controle);
        }

        public virtual void AddControleMedicamento4(ControleMedicamento controle)
        {
            controle.Tratamento = this;
            ControlesMedicamento4.Add(controle);
        }

        public virtual void AddControleMedicamento5(ControleMedicamento controle)
        {
            controle.Tratamento = this;
            ControlesMedicamento5.Add(controle);
        }

        public virtual void RemoveControlesMedicamento(int index)
        {
            if (index == 1)
                ControlesMedicamento1.Clear();
            else if (index == 2)
                ControlesMedicamento2.Clear();
            else if (index == 3)
                ControlesMedicamento3.Clear();
            else if (index == 4)
                ControlesMedicamento4.Clear();
            else if (index == 5)
                ControlesMedicamento5.Clear();
        }


        public virtual void RemoveMedicamento(ControleMedicamento controle, int index)
        {
            if (index == 1)
            {
                controle.Tratamento = this;
                ControlesMedicamento1.Remove(controle);
            }
            else if (index == 2)
            {
                controle.Tratamento = this;
                ControlesMedicamento2.Remove(controle);
            }
            else if (index == 3)
            {
                controle.Tratamento = this;
                ControlesMedicamento3.Remove(controle);
            }
            else if (index == 4)
            {
                controle.Tratamento = this;
                ControlesMedicamento4.Remove(controle);
            }
            else if (index == 5)
            {
                controle.Tratamento = this;
                ControlesMedicamento5.Remove(controle);
            }
        }

        #endregion
    }
}
