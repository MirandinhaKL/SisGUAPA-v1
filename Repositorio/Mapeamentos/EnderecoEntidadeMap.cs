using FluentNHibernate.Mapping;
using Repositorio.Entidades;
/*
 * Criado em: 01/11/21
 * Alterado em: 06/04/23
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

            References(k => k.Entidade);

            Table("EnderecoEntidade");
        }
    }
}