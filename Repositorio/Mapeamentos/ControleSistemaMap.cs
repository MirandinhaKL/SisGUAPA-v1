/*
* Criado em: 22/05/23
*/
using FluentNHibernate.Mapping;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class ControleSistemaMap : ClassMap<ControleSistema>
    {
        public ControleSistemaMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Acao).Length(255);
            Map(k => k.DataDaAcao);

            References(k => k.Entidade);
            Table("ControleSistema");
        }
    }
}