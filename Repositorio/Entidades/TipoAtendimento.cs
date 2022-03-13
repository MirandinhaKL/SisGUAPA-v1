using System;

/*
* Criado em: 15/11/2020
* Última alteração em: 
*/

namespace Repositorio.Entidades
{
    /// <summary>
    /// Contém os atributos e métodos referentes a um tipo de atendimento (atendimento médico, cirurgia, etc.).
    /// </summary>
    public class TipoAtendimento
    {
        #region Propriedades

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual int  DuracaoPadrao { get; set; }
        public virtual int  Frequencia { get; set; }
        public virtual int enumPreAtendimento { get; set; } // É o valor do enumerador, não da classe.

        #endregion

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }
        public virtual Atendimento Atendimento { get; set; }
        #endregion


    }
}
