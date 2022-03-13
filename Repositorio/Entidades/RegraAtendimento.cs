/*
 * Criada em: 26/10/21
 */

namespace Repositorio.Entidades
{
    public class RegraAtendimento
    {
        public RegraAtendimento() { }

        #region PropriedadesHibernate

        public virtual int Id { get; protected set; }
        public virtual string Procedimento { get; set; }
        public virtual int NumeroDias { get; set; }

        #endregion

        #region Relacionamentos
        public virtual Entidade Entidade { get; set; }
        #endregion

    }
}
