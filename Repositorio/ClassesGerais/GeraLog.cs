using System;
using System.IO;
using System.Reflection;

/*
 * Criada em: 01/11/21
 */
namespace Repositorio.ClassesGerais
{
    public class GeraLog
    {
        private static string caminhoExe = string.Empty;

        public static bool Log(string strMensagem, string classe, string strNomeArquivo = "ArquivoLogErros")
        {
            try
            {
                caminhoExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string caminhoArquivo = Path.Combine(caminhoExe, strNomeArquivo);
                if (!File.Exists(caminhoArquivo))
                {
                    FileStream arquivo = File.Create(caminhoArquivo);
                    arquivo.Close();
                }
                using (StreamWriter w = File.AppendText(caminhoArquivo))
                {
                    AppendLog(strMensagem, classe, w);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void AppendLog(string logMensagem, string classe, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("Log: ");
                txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                txtWriter.WriteLine($"Falha referente a classe {classe}");
                txtWriter.WriteLine($"{logMensagem}");
                txtWriter.WriteLine("------------------------------------");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
