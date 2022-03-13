using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.IO;
using static iTextSharp.text.Font;
using Font = iTextSharp.text.Font;

namespace Desktop.PDFs
{
    internal class FabricaPDF
    {
        /// <summary>
        /// Cria e configura o arquivo em PDF.
        /// </summary>
        /// <param name="aquivoDiretorio"></param>
        /// <returns></returns>
        public static Document InicializarPDF(string aquivoDiretorio)
        {
            var documento = new Document();
            documento.SetMargins(40, 40, 20, 40);
            documento.AddCreationDate();
            string caminhoRelatorio = aquivoDiretorio + ".pdf";

            var pdf = PdfWriter.GetInstance(documento, new FileStream(caminhoRelatorio, FileMode.Create));
            documento.Open();
            return documento;
        }

        /// <summary>
        /// Insere texto com a formatação centralizada.
        /// </summary>
        /// <param name="texto"></param>
        public static Document InsereTextoCentralizado(Document arquivo, string texto)
        {
            BaseFont baseTitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            Font fonteTitulo = new Font(baseTitulo, 12, BOLD);
            Paragraph paragrafo = new Paragraph(texto, new Font(fonteTitulo))
            {
                SpacingAfter = 10f,
                Alignment = Element.ALIGN_CENTER
            };
            arquivo.Add(paragrafo);
            return arquivo;
        }

        /// <summary>
        /// Insere uma primeira sentença em negrito e a segunda um texto normal;
        /// </summary>
        /// <param name="arquivo">PDF</param>
        /// <param name="destaque">Label</param>
        /// <param name="texto">Dado cadastrado</param>
        public static Document InsereTextoNegritoENormal(Document arquivo, string destaque, string texto)
        {
            Font fonte1 = new Font(FontFamily.HELVETICA, 10, BOLD, BaseColor.BLACK);
            Font fonte2 = new Font(FontFamily.HELVETICA, 10, NORMAL, BaseColor.BLACK);

            Chunk fragmento1 = new Chunk(destaque, fonte1);
            Chunk fragmento2 = new Chunk(texto, fonte2);

            Phrase frase1 = new Phrase
            {
                fragmento1,
                fragmento2
            };
            Paragraph paragrafo = new Paragraph
            {
                SpacingAfter = 5f,
                Alignment = Element.ALIGN_JUSTIFIED
            };
            paragrafo.Add(frase1);
            arquivo.Add(paragrafo);
            return arquivo;
        }

        /// <summary>
        /// Insere imagem centralizada no pdf.
        /// </summary>
        /// <param name="documento"></param>
        /// <param name="imagem"></param>
        /// <param name="largura"></param>
        /// <param name="altura"></param>
        /// <returns></returns>
        public static Document InsereImagemCentralizada(Document documento, Image imagem, float largura, float altura)
        {
            var pic = iTextSharp.text.Image.GetInstance(imagem);
            pic.ScaleToFit(largura, altura);
            pic.Alignment = Element.ALIGN_CENTER;
            documento.Add(pic);
            return documento;
        }

        public static Document InsereLinhaDivisoriaHorizontal(Document documento)
        {
            LineSeparator hline = new LineSeparator();
            hline.Percentage = 100;
            hline.LineWidth = 1f;
            documento.Add(hline);
            return documento;
        }


        public static Document InsereTituloSublinado(Document documento, string titulo)
        {
            InsereTextoCentralizado(documento, string.Empty);
            InsereTextoCentralizado(documento, string.Empty);
            InsereTextoNegritoENormal(documento, titulo, string.Empty);
            InsereLinhaDivisoriaHorizontal(documento);
            return documento;
        }
    }
}
