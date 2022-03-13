using FluentNHibernate.Mapping;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Criado em: 23/12/20
 */
namespace Repositorio.Mapeamentos
{
    public class MotivoRecolhimentoMap : ClassMap<MotivoRecolhimento>
    {
        public MotivoRecolhimentoMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Descricao).Length(255);

            References(k => k.Entidade);

            Table("motivo_recolhimento");
        }
    }
}
