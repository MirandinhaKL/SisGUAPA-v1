using System;
using System.Collections.Generic;

/*
 * Criada em: 23/09/21 
 */
namespace Repositorio.Entidades
{
    public class Adotante
    {
        public Adotante()
        {
            Adocoes = new List<Adocao>();
        }

        #region PropriedadesHibernate

        public virtual int Id { get; protected set; }
        public virtual string CPF { get; set; }
        public virtual string RG { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual int Genero { get; set; }
        public virtual int EstadoCivil { get; set; }
        public virtual string Profissao { get; set; }
        public virtual string Telefone1 { get; set; }
        public virtual string Telefone2 { get; set; }
        public virtual string Facebook { get; set; }
        public virtual string Instagram { get; set; }
        public virtual byte[] ImagemAdotante { get; set; }
        public virtual string Email { get; set; }


        #endregion PropriedadesHibernate

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }
        public virtual EnderecoAdotante EnderecoAdotante { get; set; }
        public virtual IList<Adocao> Adocoes { get; protected set; }

        public virtual void AddAdocao(Adocao adocao)
        {
            adocao.Adotante = this;
            Adocoes.Add(adocao);
        }

        public virtual void RemoveAdocao(Adocao adocao)
        {
            adocao.Adotante = this;
            Adocoes.Remove(adocao);
        }

        #endregion Relacionamentos
    }

}
