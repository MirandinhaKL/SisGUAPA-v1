using FluentNHibernate.Mapping;
using Repositorio.Entidades;
/*
 * Criado em: 23/09/20
 */
namespace Repositorio.Mapeamentos
{
    public class EnderecoAdotanteMap : ClassMap<EnderecoAdotante>
    {
        public EnderecoAdotanteMap()
        {
            Id(k => k.Id);

            Map(k => k.Estado);
            Map(k => k.Cidade).Length(255);
            Map(k => k.Bairro).Length(255);
            Map(k => k.Logradouro).Length(255);
            Map(k => k.Numero).Length(255);
            Map(k => k.Complemento).Length(255);
            Map(k => k.CEP).Length(10);
            Map(k => k.Observacao).Length(2000);

            References(k => k.Entidade);
            HasOne(k => k.Adotante).Cascade.All().PropertyRef("EnderecoAdotante");

            Table("endereco_adotante");
        }
    }
}
