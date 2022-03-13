using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Classes
{
    public class AnimalAuxiliar
    {
        public string FaixaEtaria { get; set; }

        public static string GetClassificaoIdade(DateTime nascimento, DateTime falecimento, int enumStatus)
        {
            var idade = new TimeSpan();

            if ((int)Enumeracoes.EnumStatusAnimal.Morto != enumStatus)
                idade = DateTime.Today.Subtract(nascimento);
            else
                idade = falecimento.Subtract(nascimento);

            return ClassificarFaixaEtaria(idade);
        }

        public static List<Animal> GetTodasIdadesClassificadas(List<Animal> animais, string classificacao)
        {
            var idade = new TimeSpan();
            var animaisClassificados = new List<Animal>();

            foreach (var item in animais)
            {
                Animal animal = item;

                if ((int)Enumeracoes.EnumStatusAnimal.Morto != item.AnimalStatus)
                    idade = DateTime.Today.Subtract(item.DataNascimento);
                else
                    idade = item.DataFalecimento.Subtract(item.DataNascimento);

                var faixaEtaria = ClassificarFaixaEtaria(idade);
                if (faixaEtaria == classificacao)
                    animaisClassificados.Add(animal);
            }

            return animaisClassificados;
        }

        private static string ClassificarFaixaEtaria(TimeSpan idade)
        {
            if (idade != null)
            {
                if (idade.Days < 31)
                    return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumFaixasEtarias.Menos1mes);
                else if (idade.Days >= 31 && idade.Days < 59)
                    return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumFaixasEtarias.De1a2meses);
                else if (idade.Days >= 59 && idade.Days < 90)
                    return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumFaixasEtarias.De2a3Meses);
                else if (idade.Days >= 90 && idade.Days < 180)
                    return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumFaixasEtarias.De3a6meses);
                else if (idade.Days >= 180 && idade.Days < 365)
                    return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumFaixasEtarias.De6mesesA1ano);
                else if (idade.Days >= 365 && idade.Days < 730)
                    return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumFaixasEtarias.De1a2anos);
                else if (idade.Days >= 730 && idade.Days < 1825)
                    return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumFaixasEtarias.De2a5anos);
                else if (idade.Days >= 1825 && idade.Days < 3650)
                    return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumFaixasEtarias.De5a10anos);
                else if (idade.Days >= 3650 && idade.Days < 5475)
                    return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumFaixasEtarias.De10a15anos);
                else if (idade.Days >= 5475 && idade.Days < 7300)
                    return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumFaixasEtarias.De15a20anos);
                else if (idade.Days >= 7300)
                    return FuncoesGerais.GetDescricaoEnum(Enumeracoes.EnumFaixasEtarias.Maior20anos);
                else
                    return string.Empty;
            }
            return string.Empty;
        }
    }
}
