using FluentNHibernate.Mapping;
using Repositorio.Entidades;
/*
 * Criado em: 26/11/21
 */
namespace Repositorio.Mapeamentos
{
    public class ControleMedicamento1Map : ClassMap<ControleMedicamento>
    {
        public ControleMedicamento1Map()
        {
            Id(k => k.Id);

            Map(k => k.DataExecucao);
            Map(k => k.EnumStatusControleMedicação);

            References(k => k.Entidade);
            References(k => k.Tratamento).Not.LazyLoad();
            References(k => k.Medicamento).Not.LazyLoad();

            Table("controle_medicamento1");
        }
    }
}
