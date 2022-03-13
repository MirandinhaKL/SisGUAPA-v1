using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

        //testar MAPEAMENTO E CONTINUAR O CADASTRO NA ABA RECOLHIMENTO e FORM AUXILIAR COM CADASTRO DE MOTIVO RECOLHIMENTO.
    }
}
