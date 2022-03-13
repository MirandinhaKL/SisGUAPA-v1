using System;

/*
* Criado em: 08/11/2020
* Última alteração em: 
*/

namespace Repositorio.Entidades
{
    /// <summary>
    /// Contém os atributos e métodos referentes a um lar temporário.
    /// </summary>
    public class LarTemporario
    {
        #region Propriedades

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Telefone { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string RG { get; set; }
        public virtual string CPF { get; set; }

        #endregion

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }
        public virtual EnderecoLarTemporario EnderecoLarTemporario { get; set; }

        #endregion


    }
}
