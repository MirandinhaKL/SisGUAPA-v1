using FluentNHibernate.Mapping;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class RegraAtendimentoMap : ClassMap<RegraAtendimento>
    {
        public RegraAtendimentoMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Procedimento).Length(255);
            Map(k => k.NumeroDias).Length(4);

            References(k => k.Entidade);

            Table("regra_atendimento");
        }
    }
}
