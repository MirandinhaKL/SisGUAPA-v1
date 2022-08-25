using FluentNHibernate.Mapping;
using Repositorio.Entidades;
/*
 * Criado em: 26/11/21
 */
namespace Repositorio.Mapeamentos
{
    public class ControleMedicamento3Map : ClassMap<ControleMedicamento>
    {
        public ControleMedicamento3Map()
        {
            Id(k => k.Id);

            Map(k => k.DataExecucao);
            Map(k => k.EnumStatusControleMedicação);

            References(k => k.Entidade);
            References(k => k.Tratamento).Cascade.All().Not.LazyLoad();
            References(k => k.Medicamento).Cascade.All().Not.LazyLoad();

            Table("controle_medicamento3");
        }
    }
}
