using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Criada em: 29/09/21
 */
namespace Repositorio.Entidades
{
    public class Adocao
    {
        public Adocao()
        {
          
        }


        #region PropriedadesHibernate

        public virtual int  Id { get; protected set; }
        public virtual string DoadorAnimal { get; set; }
        public virtual string LocalAdocao { get; set; }
        public virtual DateTime DataAdocao { get; set; }
        public virtual string Observacao { get; set; }

        #endregion PropriedadesHibernate

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Adotante Adotante { get; set; }

        #endregion Relacionamentos
    }
}
