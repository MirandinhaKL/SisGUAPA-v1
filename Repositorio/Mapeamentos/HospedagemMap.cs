using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
* Criado em: 10/11/2020
* Última alteração em: 
*/

namespace Repositorio.Mapeamentos
{
    public class HospedagemMap : ClassMap<Hospedagem>
    {
        public HospedagemMap()
        {
            Id(k => k.Id).GeneratedBy.Identity();

            Map(k => k.DataInicio);
            Map(k => k.DataFinal);
            Map(k => k.ValorMensal);
            Map(k => k.ObservacaoFinal).Length(1000);

            References(k => k.Entidade);
            References(k => k.LarTemporario).Cascade.All().Not.LazyLoad(); ;
            References(k => k.Animal).Cascade.All().Not.LazyLoad(); ;
            
            Table("hospedagem");
        }
    }
}
