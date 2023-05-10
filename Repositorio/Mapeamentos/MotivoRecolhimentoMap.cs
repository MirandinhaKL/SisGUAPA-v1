using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
 * Criado em: 23/12/20
 * Atualizado em: 10/05/23
 */
namespace Repositorio.Mapeamentos
{
    public class MotivoRecolhimentoMap : ClassMap<MotivoRecolhimento>
    {
        public MotivoRecolhimentoMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Descricao).Length(255);

            References(k => k.Entidade);

            Table("MotivoRecolhimento");
        }
    }
}
