using FluentNHibernate.Mapping;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class EntidadeMap : ClassMap<Entidade>
    {
        public EntidadeMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Nome).Length(255);
            Map(k => k.Email).Length(255);
            Map(k => k.Senha).Length(255);
            Map(k => k.TipoEntidade);
            Map(k => k.Estado);
            Map(k => k.DataCadastro);
            Map(k => k.CNPJ);
            Map(k => k.Telefone);

            HasMany(k => k.Usuarios).Cascade.All().Not.LazyLoad();
            //References(k => k.EnderecoEntidade).Unique().Cascade.All().Not.LazyLoad();

            Table("entidade");
        }
    }
}
