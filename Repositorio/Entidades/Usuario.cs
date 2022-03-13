using System;

/*
* Criado em: 20/01/2020
* Última alteração em: 01/22/2021
*/

namespace Repositorio.Entidades
{
    /// <summary>
    /// Contém os atributos e métodos referentes a um Usuário.
    /// </summary>
    public class Usuario
    {
        #region Propriedades

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Telefone { get; set; }
        public virtual int GrauAcesso { get; set; }
        public virtual DateTime DataIngresso { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Cargo { get; set; }
        public virtual string RG { get; set; }
        public virtual string CPF { get; set; }
        public virtual int Status { get; set; }

        #endregion

        #region Relacionamentos

        public virtual Entidade Entidade { get;set; }
        public virtual EnderecoUsuario EnderecoUsuario { get;set; }

        #endregion


    }
}
