using FluentNHibernate.Mapping;
using Repositorio.Entidades;
/*
 * Criado em: 01/11/21
 */
namespace Repositorio.Mapeamentos
{
    public class EnderecoEntidadeMap : ClassMap<EnderecoEntidade>
    {
        public EnderecoEntidadeMap()
        {
            Id(k => k.Id);

            Map(k => k.Estado);
            Map(k => k.Cidade).Length(255);
            Map(k => k.Bairro).Length(255);
            Map(k => k.Logradouro).Length(255);
            Map(k => k.Numero).Length(255);
            Map(k => k.Complemento).Length(255);
            Map(k => k.CEP).Length(10);

            //HasOne(k => k.Entidade);
            //HasOne(k => k.Entidade).Cascade.All().PropertyRef("EnderecoAdotante");

            Table("endereco_entidade");
        }
    }
}
