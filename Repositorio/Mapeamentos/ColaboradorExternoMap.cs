using FluentNHibernate.Mapping;
using Repositorio.Entidades;

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

            References(k => k.Entidade);                ;
            References(k => k.EnderecoColaboradorExterno).Cascade.All().Not.LazyLoad();

            Table("colaborador_externo");
        }
    }
}
