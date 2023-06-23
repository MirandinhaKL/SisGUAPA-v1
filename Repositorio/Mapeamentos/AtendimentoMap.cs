using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
 * Criado em: 15/11/21
 */
namespace Repositorio.Mapeamentos
{
    public class AtendimentoMap : ClassMap<Atendimento>
    {
        public AtendimentoMap()
        {
            Id(k => k.Id);

            Map(k => k.DataAtendimentoInicio);
            Map(k => k.DataAtendimentoFim);
            Map(k => k.Observacao).Length(1000);
            Map(k => k.StatusRealizacaoAtendimento);

            References(k => k.Entidade); 
            References(k => k.Animal).Cascade.All().Not.LazyLoad();
            References(k => k.ColaboradorInterno).Cascade.All().Not.LazyLoad();
            References(k => k.ColaboradorExterno).Cascade.All().Not.LazyLoad();
            References(k => k.TipoAtendimento).Cascade.All().Not.LazyLoad();
            References(k => k.Patologia).Cascade.All().Not.LazyLoad();

            References(k => k.PreAtendimento).Unique().Cascade.All().Not.LazyLoad();
            References(k => k.Tratamento).Unique().Cascade.All().Not.LazyLoad();

            Table("Atendimento");
        }
    }
}
