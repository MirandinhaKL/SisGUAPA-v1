using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
 * Criado em: 07/09/20
 * Editado em: 04/05/23
 */
namespace Repositorio.Mapeamentos
{
    public class AnimalPorteMap : ClassMap<AnimalPorte>
    {
        public AnimalPorteMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Descricao).Length(255);

            References(k => k.Entidade);

            Table("AnimalPorte");
        }
    }
}
