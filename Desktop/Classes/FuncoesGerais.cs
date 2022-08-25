using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Windows.Forms;

namespace Desktop.Classes
{
    static class FuncoesGerais
    {
        /// <summary>
        /// Cria uma lista  a partir de um enumerador.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> ConverterEnumParaLista<T>()
        {
            IList<T> list = new List<T>();
            Type type = typeof(T);
            if (type != null)
            {
                Array enumValues = Enum.GetValues(type);
                foreach (T value in enumValues)
                {
                    list.Add(value);
                }
            }
            return list;
        }

        /// <summary>
        /// Obem a descrição do item do enumerador.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetDescricaoEnum(this Enum item)
        {
            Type tipo = item.GetType();
            FieldInfo fi = tipo.GetField(item.ToString());
            DescriptionAttribute[] atributos =
            fi.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    as DescriptionAttribute[];
            if (atributos.Length > 0)
                return atributos[0].Description;
            else
                return string.Empty;
        }
      

        /// <summary>
        /// Onbtem o valor do enumerador pela Descrição inforamda.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static T GetEnumPelaDescricao<T>(string description)
        {
            if (!typeof(T).IsEnum)
                throw new Exception("T isn't an enumerated type");

            IList<T> list = ConverterEnumParaLista<T>();
            foreach (T item in list)
            {
                if (((Enum)Enum.Parse(typeof(T),
                       item.ToString())).GetDescricaoEnum() == description)
                    return item;
            }

            throw new Exception("A descrição é inválida.");
        }

        /// <summary>
        /// Mensagem exibida ao usuário quando alguma operação do banco de dados for realizada.
        /// </summary>
        /// <param name="acaoMensagem">Salvar/Editar/Excluir</param>
        public static void MensagemCRUDSucesso(Enumeracoes.EnumMensagemAoUsuario acaoMensagem)
        {
            var titulo = GetTituloMensagem(acaoMensagem);
            var mensagem = $"Os dados foram {acaoMensagem.GetDescricaoEnum()} com sucesso.";
            var icone = MessageBoxIcon.Information;
            var botoes = MessageBoxButtons.OK;
            MessageBox.Show(mensagem, titulo, botoes, icone);
        }

        /// <summary>
        /// Mensagem exibida ao usuário quando alguma operação do banco de dados for realizada.
        /// </summary>
        /// <param name="acaoMensagem">Salvar/Editar/Excluir</param>
        /// <param name="mensagem">Mensagem que deseja exibir</param>
        public static void MensagemCRUDSucessoPernsonalizada(Enumeracoes.EnumMensagemAoUsuario acaoMensagem, string mensagem)
        {
            var titulo = GetTituloMensagem(acaoMensagem);
            var icone = MessageBoxIcon.Information;
            var botoes = MessageBoxButtons.OK;
            MessageBox.Show(mensagem, titulo, botoes, icone);
        }

        public static void MensagemCRUDFalha(Enumeracoes.EnumMensagemErroAoUsuario acaoMensagem)
        {
            var titulo = GetTituloMensagem(acaoMensagem);
            var mensagem = $"Falha ao {acaoMensagem.GetDescricaoEnum()} os dados.";
            var icone = MessageBoxIcon.Error;
            var botoes = MessageBoxButtons.OK;
            MessageBox.Show(mensagem, titulo, botoes, icone);
        }

        public static void MensagemFalhaRestricaoChave()
        {
            var titulo = "Atenção!";
            var mensagem = $"Esse item está associado a outra parte do sistema e por isso não pode ser excluído."; 
            var icone = MessageBoxIcon.Information;
            var botoes = MessageBoxButtons.OK;
            MessageBox.Show(mensagem, titulo, botoes, icone);
        }

        private static string GetTituloMensagem(Enumeracoes.EnumMensagemAoUsuario acao)
        {
            switch ((int)acao)
            {
                case (int)Enumeracoes.EnumMensagemAoUsuario.Salvar:
                    return "Novo registro";
                case (int)Enumeracoes.EnumMensagemAoUsuario.Editar:
                    return "Editar registro";
                case (int)Enumeracoes.EnumMensagemAoUsuario.Excluir:
                    return "Excluir registro";
                default:
                    return string.Empty;
            }
        }

        private static string GetTituloMensagem(Enumeracoes.EnumMensagemErroAoUsuario acao)
        {
            switch ((int)acao)
            {
                case (int)Enumeracoes.EnumMensagemErroAoUsuario.Salvar:
                    return "Novo registro";
                case (int)Enumeracoes.EnumMensagemErroAoUsuario.Editar:
                    return "Editar registro";
                case (int)Enumeracoes.EnumMensagemErroAoUsuario.Excluir:
                    return "Excluir registro";
                default:
                    return string.Empty;
            }
        }

        public static void MensagemExcluirSemSucesso()
        {
            var mensagem = "Falha ao excluir os dados.";
            var titulo = "Exclusão de registro";
            var icone = MessageBoxIcon.Error;
            var botoes = MessageBoxButtons.OK;
            MessageBox.Show(mensagem, titulo, botoes, icone);
        }

        public static void MensagemAtualizarComSucesso()
        {
            var mensagem = "Os dados foram atualizados com sucesso.";
            var titulo = "Atualização de registro";
            var icone = MessageBoxIcon.Information;
            var botoes = MessageBoxButtons.OK;
            MessageBox.Show(mensagem, titulo, botoes, icone);
        }

        public static void MensagemAtualizarSemSucesso()
        {
            var mensagem = "Falha ao atualizar os dados.";
            var titulo = "Atualização de registro";
            var icone = MessageBoxIcon.Error;
            var botoes = MessageBoxButtons.OK;
            MessageBox.Show(mensagem, titulo, botoes, icone);
        }
        /// <summary>
        /// Solicita ao usuário se ele tem certeza que deseja exluir um registro.
        /// </summary>
        /// <returns></returns>
        public static DialogResult MensagemDesejaExcluir()
        {
            var mensagem = "Você deseja excluir este registro?";
            var titulo = "Exclusão de registro";
            var icone = MessageBoxIcon.Question;
            var botoes = MessageBoxButtons.YesNo;
            return MessageBox.Show(mensagem, titulo, botoes, icone);
        }
        /// <summary>
        /// Verifica se uma linha foi selecionada em uma listview. Caso não, exibe uma mensagem ao usuário.
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="acao_a_ser_feita">Ex: atualizar, remover, excluir, editar.</param>
        /// <returns></returns>
        public static bool LinhFoiSelecionadaNaListView(ListView listView, string acaoASerFeita)
        {
            if (listView.SelectedItems.Count == 1)
                return true;
            else
            {
                string mensagem = "Por favor, selecione a linha que deseja " + acaoASerFeita + ".";
                string titulo = "Atenção!";
                MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
        }


        /// <summary>
        /// Habilita o componente Save File que permite salvar um arquivo.
        /// </summary>
        /// <param name="saveFile">Componente do forms</param>
        /// <param name="titulo">Título do componente</param>
        /// <param name="enumFormato">Enumerador com o formato do arquivo. Ex: pdf, csv.</param>
        /// <returns></returns>
        public static bool HabilitaSaveFile(SaveFileDialog saveFile, string titulo, Enumeracoes.EnumFormatoArquivo enumFormato)
        {
            saveFile.Filter = FuncoesGerais.GetDescricaoEnum(enumFormato);
            saveFile.FileName = titulo;
            return saveFile.ShowDialog() == DialogResult.OK ? true : false;
        }

        /// <summary>
        /// Informa o usuário que um arquivo com o mesmo nome está aberto.
        /// </summary>
        public static void MensagemArquivoExistente()
        {
            var mensagem = "Um arquivo com o mesmo nome já existe neste diretório. Escolha outro nome e execute esta ação novamente.";
            var titulo = "Falha";
            var icone = MessageBoxIcon.Exclamation;
            var botoes = MessageBoxButtons.OK;
            MessageBox.Show(mensagem, titulo, botoes, icone);
        }

        /// <summary>
        /// Erro genérico para falha ao gerar arquivos (.csv, .pdf).
        /// </summary>
        public static void MensagemFalhaAoGerarArquivo()
        {
            var mensagem = "Erro ao gerar o arquivo.";
            var titulo = "Erro";
            var icone = MessageBoxIcon.Error;
            var botoes = MessageBoxButtons.OK;
            MessageBox.Show(mensagem, titulo, botoes, icone);
        }
        /// <summary>
        /// Carrega uma imagem convertendo de bytes para bitmap.
        /// </summary>
        /// <param name="imagem"></param>
        /// <returns></returns>
        public static Bitmap ConverteByteParaBitmap(byte[] imagem)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] dados = imagem;
            mStream.Write(dados, 0, Convert.ToInt32(dados.Length));
            Bitmap bitmap = new Bitmap(mStream, false);
            mStream.Dispose();
            return bitmap;
        }

        /// <summary>
        /// Reduz o tamanho (altura e largura) da imagem.
        /// </summary>
        /// <param name="imgToResize"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static System.Drawing.Image ResizeImagem(System.Drawing.Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            //Calulate  width with new desired size  
            float nPercentW = size.Width / (float)sourceWidth;
            //Calculate height with new desired size  
            float nPercentH = size.Height / (float)sourceHeight;
            float nPercent;
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        /// <summary>
        /// Validação da própria System para e-mail válido.
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        public static bool EmailEhValido(string emailaddress)
        {
            try
            {
                var  email = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Converte de bitmap para byte (apto a salvar no BD).
        /// </summary>
        /// <param name="imagem">System.Drawing.Image</param>
        /// <returns></returns>
        public static byte[] ConverterBitmapParaByte(Image imagem)
        {
            if (imagem != null)
            {
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(imagem, typeof(byte[]));
            }
            else
                return new byte[0];
        }

        public static void SetImagemPictureBox(PictureBox picture, byte[] imagem)
        {
            if (imagem != null && imagem.Length > 0)
                picture.Image = FuncoesGerais.ConverteByteParaBitmap(imagem);
        }

        /// <summary>
        /// Obtem a descrição do nascimento do animal.
        /// </summary>
        /// <param name="nascimento">Data de nascimento</param>
        /// <returns>Retorna ano e mês de idade</returns>
        public static string GetIdade(DateTime nascimento)
        {
            var idadeBruta = DateTime.Today.Subtract(nascimento);
            var anos = (int)Math.Truncate(idadeBruta.TotalDays / 365);
            var meses = (int)Math.Truncate((idadeBruta.TotalDays % 365) / 30);
            var dias = (int)Math.Truncate((idadeBruta.TotalDays % 365) % 30);

            var ano = string.Empty;
            if (anos == 1)
                ano = "ano";
            else if (anos > 1)
                ano = "anos";

            var mes = string.Empty;
            if (meses == 1)
                mes = "mês";
            else if (meses > 1)
                mes = "meses";

            if (anos == 0 && meses == 0)
                return $"{dias} dias";
            else if (anos == 0 && meses > 0)
                return $"{meses} {mes}";
            else if (anos > 0 && meses == 0)
                return $"{anos} {ano}";
            else
                return $"{anos} {ano} e {meses} {mes}";
        }
       
    }
}
