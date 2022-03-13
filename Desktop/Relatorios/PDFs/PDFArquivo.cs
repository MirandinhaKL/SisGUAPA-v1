using Desktop.Classes;
using Desktop.Relatorios.Campos;
using Desktop.Relatorios.PDFs;
using iTextSharp.text;
using Repositorio.Entidades;
using System.IO;
using System.Windows.Forms;

/*
* Criado em: 19/10/21
*/
namespace Desktop.PDFs
{
    public class PDFAdocao
    {
        private Document documento = new Document(PageSize.A4);

        private static Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.GetInstance(memstr);
                return img;
            }
        }

        internal static bool OberRelatorio(SaveFileDialog saveFileDialog, ItensPDF itensPDF)
        {
            var pdf = FabricaPDF.InicializarPDF(saveFileDialog.FileName);

            // cabeçalho
            FabricaPDF.InsereTextoCentralizado(pdf, $"\n{itensPDF.TituloRelatorio}");

            if (itensPDF.Animal != null)
            {
                var animal = itensPDF.Animal;
                var campos = ImpAnimal.GetCabecalho();

                // insere imagem animal
                if (animal.Imagem != null && animal.Imagem.Length > 0)
                {
                    var imagem = byteArrayToImage(animal.Imagem);
                    FabricaPDF.InsereImagemCentralizada(pdf, imagem, 120f, 150f);
                    FabricaPDF.InsereTextoCentralizado(pdf, string.Empty);
                }

                FabricaPDF.InsereTituloSublinado(pdf, "Dados do Animal");

                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{campos.Identificacao}:  ", animal.Identificacao);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{campos.Nome}:  ", animal.Nome);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{campos.DataNascimento}:  ", animal.DataNascimento.ToShortDateString());
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{campos.Especie}:  ", animal.AnimalEspecie?.Descricao);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{campos.Genero}:  ", FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)animal.Genero));
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{campos.Cor}:  ", animal.AnimalCor?.Descricao);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{campos.DataRecolhimento}:  ", animal.Recolhimento?.DataRecolhimento.ToShortDateString());
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{campos.Peso}:  ", $"{ animal.Peso} Kg");
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{campos.Deficiencia}:  ", animal.Deficiencia == string.Empty ? "Não" : animal.Deficiencia);
            }

            if (itensPDF.Adotante != null)
            {
                var adocao = itensPDF.Adotante;
                var camposAdotante = ImpAdotante.GetCabecalho();

                FabricaPDF.InsereTituloSublinado(pdf, "Dados Pessoais do Adotante");

                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposAdotante.Nome}:  ", adocao.Nome);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposAdotante.CPF}:  ", adocao.CPF);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposAdotante.RG}:  ", adocao.RG);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposAdotante.DataNascimento}:  ", adocao.DataNascimento.ToShortDateString());
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposAdotante.Genero}:  ", FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumGenero)adocao.Genero));
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposAdotante.EstadoCivil}: ", FuncoesGerais.GetDescricaoEnum((Enumeracoes.EnumEstadoCivil)adocao.EstadoCivil));
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposAdotante.Profissao}: ", adocao.Profissao);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposAdotante.Telefone1}: ", adocao.Telefone1);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposAdotante.Telefone2}: ", adocao.Telefone2);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposAdotante.Email}: ", adocao.Email);
            }

            if (itensPDF.Adotante?.EnderecoAdotante != null)
            {
                var endereco = itensPDF.Adotante?.EnderecoAdotante;
                var camposEndereco = ImpAdotante.GetCabecalho();

                FabricaPDF.InsereTituloSublinado(pdf, "Endereço do Adotante");

                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposEndereco.Cidade}:  ", endereco.Cidade);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposEndereco.Bairro}:  ", endereco.Bairro);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposEndereco.Logradouro}:  ", endereco.Logradouro);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposEndereco.Numero}:  ", endereco.Numero);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposEndereco.Complemento}:  ", endereco.Complemento);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposEndereco.CEP}:  ", endereco.CEP);
                FabricaPDF.InsereTextoNegritoENormal(pdf, $"{camposEndereco.Observacao}:  ", endereco.Adotante.EnderecoAdotante.Observacao);
            }

            pdf.NewPage();
            pdf.Close();
            System.Diagnostics.Process.Start(saveFileDialog.FileName + ".pdf");
            return true;
        }
    }
}
