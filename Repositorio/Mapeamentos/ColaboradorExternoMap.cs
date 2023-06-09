using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
 *  Criado em: 12/11/2021
 *  Alterado em: 05/06/23
 */
namespace Repositorio.Mapeamentos
{
    public class ColaboradorExternoMap : ClassMap<ColaboradorExterno>
    {
        public ColaboradorExternoMap()
        {
            Id(k => k.Id).GeneratedBy.Identity();

            Map(k => k.NomeEmpresa);
            Map(k => k.NomeColaborador);
            Map(k => k.Email);
            Map(k => k.Telefone);
            Map(k => k.Cargo);
            Map(k => k.Status);

            References(k => k.Entidade);
            HasOne(k => k.EnderecoColaboradorExterno)
                .Cascade.AllDeleteOrphan().Not.LazyLoad();

            Table("ColaboradorExterno");
        }
    }
}

//TODO: Falha de restrição na chave estrangeira ao excluir.