using FluentNHibernate.Mapping;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(k => k.Id).GeneratedBy.Identity();

            Map(k => k.Nome);
            Map(k => k.Email);
            Map(k => k.Senha);
            Map(k => k.GrauAcesso);
            Map(k => k.DataIngresso);
            Map(k => k.DataNascimento);
            Map(k => k.Telefone);
            Map(k => k.Cargo);
            Map(k => k.RG);
            Map(k => k.CPF);
            Map(k => k.Status);

            References(k => k.Entidade);                ;
            References(k => k.EnderecoUsuario).Cascade.All().Not.LazyLoad();

            Table("Usuario");
        }
    }
}
