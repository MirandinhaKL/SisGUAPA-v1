using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Relatorios.CSVs
{
    public class FabricaCSV
    {
        public static bool Obter(SaveFileDialog saveFileDialog, object dados)
        {
            string caminho = $"{saveFileDialog.FileName}.csv";
            var config = new CsvConfiguration(CultureInfo.CurrentCulture);
            config.HasHeaderRecord = false;
            try
            {
                using (var escritor = new StreamWriter(caminho, false, Encoding.UTF8))
                using (var csv = new CsvWriter(escritor, config))
                {
                    csv.WriteRecords(dados.ToString());
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
    }
}
