using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Repositorio.Entidades;
/*
 * Criado em: 23/09/20
 */
namespace Repositorio.Mapeamentos
{
    public class RecolhimentoMap : ClassMap<Recolhimento>
    {
        public RecolhimentoMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.DataRecolhimento);
            Map(k => k.Recolhedor).Length(255);
            Map(k => k.Observacao);
            Map(k => k.Telefone);

            References(k => k.Entidade);

            Table("recolhimento");
        }
    }
}
