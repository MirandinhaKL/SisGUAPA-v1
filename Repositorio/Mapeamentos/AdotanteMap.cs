using FluentNHibernate.Mapping;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Criado em: 23/09/21
 */
namespace Repositorio.Mapeamentos
{
    public class AdotanteMap : ClassMap<Adotante>
    {
        public AdotanteMap()
        {
            Id(k => k.Id);

            Map(k => k.CPF).Length(11);
            Map(k => k.RG).Length(10);
            Map(k => k.Nome).Length(255);
            Map(k => k.DataNascimento);
            Map(k => k.Genero);
            Map(k => k.EstadoCivil); 
            Map(k => k.Profissao); 
            Map(k => k.Telefone1); 
            Map(k => k.Telefone2); 
            Map(k => k.Facebook); 
            Map(k => k.Instagram); 
            Map(k => k.ImagemAdotante); 
            Map(k => k.Email); 

            References(k => k.Entidade); // many to one -> muitos adotantes associados a uma entidade
            HasMany(k => k.Adocoes).Cascade.All().Not.LazyLoad();
            References(k => k.EnderecoAdotante).Unique().Cascade.All().Not.LazyLoad();

            Table("adotante");
        }
    }
}
