using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
* Criado em: 22/11/2020
* Última alteração em: 
*/

namespace Repositorio.Mapeamentos
{
    public class MedicamentoMap : ClassMap<Medicamento>
    {
        public MedicamentoMap()
        {
            Id(k => k.Id).GeneratedBy.Identity();

            Map(k => k.Nome).Length(255);
            Map(k => k.EnumUnidadeMedicamentos);
            Map(k => k.Duracao);
            Map(k => k.EnumFrequenciaIngestao);
            Map(k => k.AuxiliarX);
            Map(k => k.AuxiliarY);
            Map(k => k.DiasDaSemana);
            Map(k => k.Quantidade);

            References(k => k.Entidade);
            //HasMany(k => k.ControlesMedicamento).Cascade.All().Not.LazyLoad();

            Table("Medicamento");
        }
    }
}
