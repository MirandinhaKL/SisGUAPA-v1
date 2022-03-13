using Repositorio.Entidades;

namespace Desktop.Relatorios.PDFs
{
    /// <summary>
    /// Dados que serão exibidos no relatório no formato PDF
    /// </summary>
    public class ItensPDF
    {
        public string TituloRelatorio{ get; set; }
        public Animal Animal { get; set; }
        public Adotante Adotante { get; set; }
        public Adocao Adocao { get; set; }
        //public EnderecoAdotante EnderecoAdotante { get; set; }
    }
}
