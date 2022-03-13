using FluentNHibernate.Mapping;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Criado em: 20/08/20
 */
namespace Repositorio.Mapeamentos
{
    public class AnimalCorMap : ClassMap<AnimalCor>
    {
        public AnimalCorMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Descricao).Length(255);

            References(k => k.Entidade);

            Table("animal_cor");
        }
    }
}
