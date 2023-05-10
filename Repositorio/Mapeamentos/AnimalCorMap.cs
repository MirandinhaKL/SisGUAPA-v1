using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
 * Criado em: 20/08/20
 * Atualizado em: 03/05/23
 */
namespace Repositorio.Mapeamentos
{
    public class AnimalCorMap : ClassMap<AnimalCor>
    {
        public AnimalCorMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Descricao).Length(255);

            References(k => k.Entidade);

            Table("AnimalCor");
        }
    }
}
