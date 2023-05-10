using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
 * Criado em: 13/09/20
 * Atualizado em: 10/05/23
 */
namespace Repositorio.Mapeamentos
{
    public class MotivoFalecimentoMap : ClassMap<MotivoFalecimento>
    {
        public MotivoFalecimentoMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Descricao).Length(255);

            References(k => k.Entidade);

            Table("MotivoFalecimento");
        }
    }
}