using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
* Criado em: 18/11/2020
* Última alteração em: 
*/

namespace Repositorio.Mapeamentos
{
    public class PreAtendimentoMap : ClassMap<PreAtendimento>
    {
        public PreAtendimentoMap()
        {
            Id(k => k.Id).GeneratedBy.Identity();

            Map(k => k.DataPreAtendimento);
            Map(k => k.EnumStatusPreAtendimento);

            References(k => k.Entidade);
            References(k => k.TipoAtendimento);
            HasOne(k => k.Atendimento).Cascade.All().PropertyRef("PreAtendimento");
            
            Table("pre_atendimento");
        }
    }
}
