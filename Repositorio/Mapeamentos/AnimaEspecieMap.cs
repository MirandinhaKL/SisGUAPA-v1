using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
 * Criado em: 10/09/20
 * Editado em: 04/05/23
 */
namespace Repositorio.Mapeamentos
{
    public class AnimalEspecieMap : ClassMap<AnimalEspecie>
    {
        public AnimalEspecieMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Descricao).Length(255);

            References(k => k.Entidade).Not.LazyLoad();

            Table("AnimalEspecie");
        }
    }
}
