using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
* Criado em: 15/11/2020
* Última alteração em: 01/06/23
*/

namespace Repositorio.Mapeamentos
{
    public class TipoAtendimentoMap : ClassMap<TipoAtendimento>
    {
        public TipoAtendimentoMap()
        {
            Id(k => k.Id).GeneratedBy.Identity();

            Map(k => k.Nome).Length(255);
            Map(k => k.DuracaoPadrao).Length(3);
            Map(k => k.Frequencia).Length(3);
            Map(k => k.EnumPreAtendimento).Length(3);

            References(k => k.Entidade);
            //References(k => k.Atendimento).Cascade.All().Not.LazyLoad();
            
            Table("TipoAtendimento");
        }
    }
}
