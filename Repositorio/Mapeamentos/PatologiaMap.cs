using FluentNHibernate.Mapping;
using Repositorio.Entidades;

/*
* Criado em: 15/11/2020
* Última alteração em: 02/06/23
*/

namespace Repositorio.Mapeamentos
{
    public class PatologiaMap : ClassMap<Patologia>
    {
        public PatologiaMap()
        {
            Id(k => k.Id).GeneratedBy.Identity();

            Map(k => k.Nome).Length(255);
            Map(k => k.Descricao).Length(1000);

            References(k => k.Entidade);
            //References(k => k.Atendimento).Cascade.All().Not.LazyLoad(); ;
            
            Table("Patologia");
        }
    }
}
