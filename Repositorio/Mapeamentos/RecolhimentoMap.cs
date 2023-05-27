using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
 * Criado em: 23/09/20
 * Alterado em: 26/05/23
 */
namespace Repositorio.Mapeamentos
{
    public class RecolhimentoMap : ClassMap<Recolhimento>
    {
        public RecolhimentoMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.DataRecolhimento);
            Map(k => k.Recolhedor).Length(255);
            Map(k => k.Observacao);
            Map(k => k.Telefone);

            References(k => k.Entidade);
            References(k => k.Animal);
            References(k => k.EnderecoRecolhimento).Cascade.All().Not.LazyLoad();
            References(k => k.MotivoRecolhimento);

            Table("DadosRecolhimento");
        }
    }
}