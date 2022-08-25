using System.ComponentModel;

namespace Repositorio.ClassesGerais
{
    public class EnumeracoesClasses
    {
        /// <summary>
        /// Status dos tratamentos cadastradoss nos atendimentos.
        /// </summary>
        public enum EnumStatusMedicacao
        {
            [Description("Não possui")]
            naoPossui = 0,
            [Description("Não iniciado")]
            naoIniciado = 1,
            [Description("Iniciado")]
            iniciado = 2,
            [Description("Encerrado")]
            encerrado = 3,
            [Description("Cancelado")]
            cancelado = 4,
            [Description("Agendado")]
            agendado = 5,
        }

        public enum EnumUnidadeMedicamentos
        {
            [Description("Comprimido(s)")]
            comprimido = 0,
            [Description("Cápsula(s)")]
            capsula = 1,
            [Description("Gota(s)")]
            gota = 2,
            [Description("Grama(s)")]
            grama = 3,
            [Description("Inalação(ões)")]
            instalacao = 4,
            [Description("Injeção(ões)")]
            injecao = 5,
            [Description("Miligrama(s)")]
            miligrama = 6,
            [Description("Mililitro(s)")]
            mililitro = 7,
            [Description("Pedaço(s)")]
            pedaco = 8,
            [Description("Pulverização(ões)")]
            pulverizacao = 9,
            [Description("Sache(s)")]
            sache = 10,
            [Description("Supositório(s)")]
            supositorio = 11,
            [Description("Unidade(s)")]
            unidade = 12
        }

        /// <summary>
        /// O estado da execução atendimento: realizado ou não.
        /// </summary>
        public enum EnumStatusControleMedicação
        {
            [Description("Não realizado")]
            naoRealizado = 0,
            [Description("Realizado")]
            realizado = 1,
            [Description("Cancelado")]
            cancelado = 2,
        }


        public enum EnumFrequenciaIngestao
        {
            diariamenteXvezesDia = 0,
            diariamenteCadaXhoras = 1,
            cadaXdias = 2,
            diasDaSemana = 3,
            ciclosXativosYinativos = 4
        }

        public static string GetDescricaoFrequenciaIngestao(int enumFrequenciaIngestao, int auxiliarX, int auxiliarY, string diasDaSemana)
        {
            var descricao = string.Empty;

            if (enumFrequenciaIngestao == (int)EnumeracoesClasses.EnumFrequenciaIngestao.diariamenteXvezesDia)
                return $"{auxiliarX} vez ao dia";
            if (enumFrequenciaIngestao == (int)EnumeracoesClasses.EnumFrequenciaIngestao.diariamenteCadaXhoras)
                return $"A cada {auxiliarX} hora(s)";
            if (enumFrequenciaIngestao == (int)EnumeracoesClasses.EnumFrequenciaIngestao.cadaXdias)
                return $"A cada {auxiliarX} dia(s)";
            if (enumFrequenciaIngestao == (int)EnumeracoesClasses.EnumFrequenciaIngestao.diasDaSemana)
            {
                char[] dias = diasDaSemana.ToCharArray();

                foreach (var dia in dias)
                {
                    if (dia == '2')
                        descricao += "2ª";

                    if (dia == '3')
                        if (!string.IsNullOrEmpty(descricao))
                            descricao += ", 3ª";
                        else
                            descricao += "3ª";

                    if (dia == '4')
                        if (!string.IsNullOrEmpty(descricao))
                            descricao += ", 4ª";
                        else
                            descricao += "4ª";

                    if (dia == '5')
                        if (!string.IsNullOrEmpty(descricao))
                            descricao += ", 5ª";
                        else
                            descricao += "5ª";

                    if (dia == '6')
                        if (!string.IsNullOrEmpty(descricao))
                            descricao += ", 6ª";
                        else
                            descricao += "6ª";

                    if (dia == 'S')
                        if (!string.IsNullOrEmpty(descricao))
                            descricao += ", Sab";
                        else
                            descricao += "Sab";

                    if (dia == 'D')
                        if (!string.IsNullOrEmpty(descricao))
                            descricao += ", Dom";
                        else
                            descricao += "Dom";

                }
                return descricao;

            }
            if (enumFrequenciaIngestao == (int)EnumeracoesClasses.EnumFrequenciaIngestao.ciclosXativosYinativos)
                return $"{auxiliarX} dia(s) ativo {auxiliarY} dia(s) inativo";
            return descricao;
        }
    }
}
