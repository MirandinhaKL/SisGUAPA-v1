using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
* Criado em: 23/11/2020
* Última alteração em: 05/07/2022
*/

namespace Repositorio.Mapeamentos
{
    public class TratamentoMap : ClassMap<Tratamento>
    {
        public TratamentoMap()
        {
            Id(k => k.Id);

            Map(k => k.EnumStatusTratamento);

            Map(k => k.EnumStatusMedicacao1);
            Map(k => k.EnumStatusMedicacao2);
            Map(k => k.EnumStatusMedicacao3);
            Map(k => k.EnumStatusMedicacao4);
            Map(k => k.EnumStatusMedicacao5);

            Map(k => k.InicioMedicacao1);
            Map(k => k.InicioMedicacao2);
            Map(k => k.InicioMedicacao3);
            Map(k => k.InicioMedicacao4);
            Map(k => k.InicioMedicacao5);

            Map(k => k.FimMedicacao1);
            Map(k => k.FimMedicacao2);
            Map(k => k.FimMedicacao3);
            Map(k => k.FimMedicacao4);
            Map(k => k.FimMedicacao5);

            References(k => k.Entidade);
            References(k => k.Atendimento).Not.LazyLoad();

            References(k => k.Medicamento1).Cascade.All().Not.LazyLoad();
            References(k => k.Medicamento2).Cascade.All().Not.LazyLoad();
            References(k => k.Medicamento3).Cascade.All().Not.LazyLoad();
            References(k => k.Medicamento4).Cascade.All().Not.LazyLoad();
            References(k => k.Medicamento5).Cascade.All().Not.LazyLoad();

            HasMany(k => k.ControlesMedicamento1).Cascade.All().Not.LazyLoad();
            HasMany(k => k.ControlesMedicamento2).Cascade.All().Not.LazyLoad();
            HasMany(k => k.ControlesMedicamento3).Cascade.All().Not.LazyLoad();
            HasMany(k => k.ControlesMedicamento4).Cascade.All().Not.LazyLoad();
            HasMany(k => k.ControlesMedicamento5).Cascade.All().Not.LazyLoad();

            //HasOne(k => k.Atendimento).Cascade.All().PropertyRef("Tratamento");
            
            Table("tratamento");
        }
    }
}
