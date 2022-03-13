using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
 * Criado em: 29/09/21
 */
namespace Repositorio.Mapeamentos
{
    public class AdocaoMap : ClassMap<Adocao>
    {
        public AdocaoMap()
        {
            Id(k => k.Id);

            Map(k => k.DoadorAnimal).Length(255);
            Map(k => k.LocalAdocao).Length(255);
            Map(k => k.DataAdocao).Length(255);
            Map(k => k.Observacao).Length(1000);

            References(k => k.Animal).Cascade.All().Not.LazyLoad();
            References(k => k.Adotante);
            References(k => k.Entidade);

            Table("adocao");
        }
    }
}
