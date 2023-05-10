namespace Repositorio.Entidades
{
    public class AnimalCor
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }

        #endregion
    }

}