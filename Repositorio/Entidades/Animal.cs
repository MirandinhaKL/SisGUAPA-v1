using System;
using System.Collections.Generic;

namespace Repositorio.Entidades
{
    public class Animal
    {
        #region PropriedadesHibernate

        public Animal()
        {
            Atendimentos = new List<Atendimento>();
            //Hospedagens = new List<Hospedagem>();
        }

        public virtual int Id { get; set; }
        public virtual string Identificacao { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual int Peso { get; set; }
        public virtual int Castrado { get; set; }
        public virtual string Deficiencia { get; set; }
        public virtual int Genero { get; set; }
        public virtual byte[] Imagem { get; set; }
        public virtual int AnimalStatus { get; set; }
        public virtual string Raca { get; set; }
        public virtual DateTime DataFalecimento { get; set; }
        public virtual bool Hospedado { get; set; }

        #endregion

        #region Relacionamentos
        public virtual Entidade Entidade { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual AnimalCor AnimalCor { get; set; }
        public virtual AnimalEspecie AnimalEspecie { get; set; }
        public virtual AnimalPorte AnimalPorte { get; set; }
        public virtual MotivoFalecimento MotivoFalecimento { get; set; }
        public virtual Recolhimento Recolhimento { get; set; }
        public virtual MotivoRecolhimento MotivoRecolhimento { get; set; }

        public virtual Adocao Adocao { get; set; }
        public virtual EnderecoRecolhimento EnderecoRecolhimento { get; set; }
        public virtual IList<Atendimento> Atendimentos { get; protected set; }
        //public virtual IList<Hospedagem> Hospedagens { get; protected set; }

        public virtual void AddAtendimento(Atendimento atendimento)
        {
            atendimento.Animal = this;
            Atendimentos.Add(atendimento);
        }

        public virtual void RemoveAtendimento(Atendimento atendimento)
        {
            atendimento.Animal = this;
            Atendimentos.Remove(atendimento);
        }

        //public virtual void AddHospedagem(Hospedagem hospedagem)
        //{
        //    hospedagem.Animal = this;
        //    Hospedagens.Add(hospedagem);
        //}

        //public virtual void RemoveHospesagem (Hospedagem hospedagem)
        //{
        //    hospedagem.Animal = this;
        //    Hospedagens.Remove(hospedagem);
        //}

        #endregion
    }
}

// https://github.com/nhibernate/fluent-nhibernate/wiki/Getting-started
