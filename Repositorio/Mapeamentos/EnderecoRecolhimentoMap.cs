using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
 * Criado em: 23/09/20
 * Alterado em: 15/05/23
 */
namespace Repositorio.Mapeamentos
{
    public class EnderecoRecolhimentoMap : ClassMap<EnderecoRecolhimento>
    {
        public EnderecoRecolhimentoMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Estado);
            Map(k => k.Cidade).Length(255);
            Map(k => k.Bairro).Length(255);
            Map(k => k.Logradouro).Length(255);
            Map(k => k.Numero).Length(255);
            Map(k => k.Complemento).Length(255);
            Map(k => k.CEP).Length(10);

            References(k => k.Entidade);
            References(k => k.Animal);
            References(k => k.Recolhimento);

            Table("EnderecoRecolhimento");
        }
    }
}
