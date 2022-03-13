using FluentNHibernate.Mapping;
using Repositorio.Entidades;
/*
 * Criado em: 08/11/21
 */
namespace Repositorio.Mapeamentos
{
    public class EnderecoLarTemporarioMap : ClassMap<EnderecoLarTemporario>
    {
        public EnderecoLarTemporarioMap()
        {
            Id(k => k.Id);

            Map(k => k.Estado);
            Map(k => k.Cidade).Length(255);
            Map(k => k.Bairro).Length(255);
            Map(k => k.Logradouro).Length(255);
            Map(k => k.Numero).Length(255);
            Map(k => k.Complemento).Length(255);
            Map(k => k.CEP).Length(10);

            References(k => k.Entidade);

            Table("endereco_lar_temporario");
        }
    }
}
