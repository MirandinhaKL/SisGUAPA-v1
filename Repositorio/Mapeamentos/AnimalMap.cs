using FluentNHibernate.Mapping;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class AnimalMap : ClassMap<Animal>
    {
        public AnimalMap()
        {
            Id(k => k.Id).GeneratedBy.Increment();

            Map(k => k.Identificacao).Length(255);
            Map(k => k.Nome).Length(255);
            Map(k => k.DataNascimento);
            Map(k => k.Peso);
            Map(k => k.Castrado);
            Map(k => k.Deficiencia).Length(255);
            Map(k => k.Genero);
            Map(k => k.Raca);
            Map(k => k.AnimalStatus);
            Map(k => k.Imagem).CustomType("BinaryBlob");
            Map(k => k.DataFalecimento);
            Map(k => k.Hospedado);
            Map(k => k.DataCadastro);

            References(k => k.Entidade);
            References(k => k.Usuario);
            References(k => k.AnimalCor).Not.LazyLoad();
            References(k => k.AnimalEspecie).Not.LazyLoad();
            References(k => k.AnimalPorte).Not.LazyLoad();
            References(k => k.MotivoFalecimento).Not.LazyLoad();

            References(k => k.DadosRecolhimento).Cascade.All().Not.LazyLoad();
            //References(k => k.Atendimentos).Cascade.All().Not.LazyLoad();

            //References(k => k.Adocao).Not.LazyLoad();
            //HasMany(k => k.Hospedagens).Cascade.All().Not.LazyLoad();

            Table("Animal");
        }
    }
}
