using FluentNHibernate.Mapping;
using Repositorio.Entidades;
/*
 * Criado em: 26/11/21
 */
namespace Repositorio.Mapeamentos
{
    public class ControleMedicamentoMap : ClassMap<ControleMedicamento>
    {
        public ControleMedicamentoMap()
        {
            Id(k => k.Id);

            Map(k => k.DataExecucao);
            Map(k => k.EnumStatusControleMedicação);

            References(k => k.Entidade);
            References(k => k.Medicamento);
            //HasOne(k => k.Medicamento).Cascade.All().PropertyRef("ControleMedicamento");

            Table("controle_medicamento");
        }
    }
}
