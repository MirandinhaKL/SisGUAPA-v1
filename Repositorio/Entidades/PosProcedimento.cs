using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class PosProcedimento
    {
        public PosProcedimento()
        {
            
        }

        public virtual int Id { get; protected set; }
        public virtual string Atividade { get; set; }
        public virtual int Frequencia { get; set; }
        public virtual bool Efetuado { get; set; }

        public virtual Entidade Entidade { get; set; }
    }
}
