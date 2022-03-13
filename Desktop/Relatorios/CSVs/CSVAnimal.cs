using CsvHelper;
using CsvHelper.Configuration;
using Desktop.Classes;
using Desktop.Relatorios.Campos;
using Repositorio.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * Criada em 27/07/21
 */
namespace Desktop.CSVs
{
    /// <summary>
    /// Gera um arquivo no formato CSV contendo todos os dados dos animais cadastrados no sistema.
    /// </summary>
    public class CSVAnimal
    {
        public static bool GetCSVCompleto(SaveFileDialog saveFileDialog)
        {
            string caminho = $"{saveFileDialog.FileName}.csv";
            var config = new CsvConfiguration(CultureInfo.CurrentCulture);
            config.HasHeaderRecord = false;

            try
            {
                using (var escritor = new StreamWriter(caminho, false, Encoding.UTF8))
                using (var csv = new CsvWriter(escritor, config))
                {
                    var animais = DadosAjustados();
                    csv.WriteRecords(animais);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

            // Abre o arquivo no formato CSV.
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process.Start(caminho);

            return true;
        }

       

        private static List<ImpAnimal> DadosAjustados()
        {
            var animaisOriginal = AnimalDAO.GetTodosRegistros(Global.UsuarioLogado.Entidade.Id);
            var animaisImpressao = new List<ImpAnimal>();

            var titlulo = ImpAnimal.GetCabecalho();
            animaisImpressao.Add(titlulo);

            if (animaisOriginal.Count > 0)
            {
                foreach (var item in animaisOriginal)
                {
                    var animal = new ImpAnimal()
                    {
                        Identificacao = item.Identificacao,
                        Nome = item.Nome,
                        DataNascimento = item.DataNascimento.ToShortDateString(),
                        Peso = item.Peso.ToString(),
                        Castrado = (FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumPossibilidades)item.Castrado)),
                        Deficiencia = item.Deficiencia,
                        Genero = (FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)item.Genero)),
                        Status = (FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumStatusAnimal)item.AnimalStatus)),
                        Raca = item.Raca,
                        Cor = item.AnimalCor?.Descricao,
                        Especie = item.AnimalEspecie?.Descricao,
                        Porte = item.AnimalPorte?.Descricao,
                        DataRecolhimento = item.Recolhimento?.DataRecolhimento.ToShortDateString(),
                        MotivoRecolhimento = item.MotivoRecolhimento?.Descricao,
                        Recolhedor = item.Recolhimento?.Recolhedor,
                        Observacao = item.Recolhimento?.Observacao,
                        DataFalecimento = item.DataFalecimento == DateTime.MinValue ? string.Empty : item.DataFalecimento.ToShortDateString(),
                        MotivoFalecimento = item.MotivoFalecimento?.Descricao,
                    };

                    animaisImpressao.Add(animal);
                }
            }
            return animaisImpressao;
        }
    }
}
