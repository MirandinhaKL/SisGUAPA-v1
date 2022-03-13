using FluentNHibernate.Mapping;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class LarTemporarioMap : ClassMap<LarTemporario>
    {
        public LarTemporarioMap()
        {
            Id(k => k.Id).GeneratedBy.Identity();

            Map(k => k.Nome);
            Map(k => k.Email);
            Map(k => k.DataNascimento);
            Map(k => k.Telefone);
            Map(k => k.RG);
            Map(k => k.CPF);

            References(k => k.Entidade);                
            References(k => k.EnderecoLarTemporario).Cascade.All().Not.LazyLoad();

            Table("lar_temporario");
        }
    }
}
