namespace Repositorio.Entidades
{
    /*
     * Alterado em: 18/05/23
     */
    public class MotivoRecolhimento
    {
        public virtual int Id { get; set; }

        public virtual string Descricao { get; set; }

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }

        public virtual Recolhimento Recolhimento { get; set; }

        #endregion
    }

}
