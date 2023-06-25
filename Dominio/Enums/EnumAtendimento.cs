using System.ComponentModel;

namespace Dominio.Enums
{
    public static class EnumAtendimento
    {
        /// <summary>
        /// Duração do tempo de 5 minutos a 12h.
        /// </summary>
        public enum EnumDuracaoPadrao
        {
            [Description("5 minutos")]
            minutos5 = 0,
            [Description("10 minutos")]
            minutos10 = 1,
            [Description("15 minutos")]
            minutos15 = 2,
            [Description("20 minutos")]
            minutos20 = 3,
            [Description("25 minutos")]
            minutos25 = 4,
            [Description("30 minutos")]
            minutos30 = 5,
            [Description("40 minutos")]
            minutos40 = 6,
            [Description("45 minutos")]
            minutos45 = 7,
            [Description("50 minutos")]
            minutos50 = 8,
            [Description("1 hora")]
            hora1 = 9,
            [Description("1 hora e 20 minutos")]
            hora1min20 = 10,
            [Description("1 hora e 30 minutos")]
            hora1min30 = 11,
            [Description("1 hora e 40 minutos")]
            hora1min40 = 12,
            [Description("2 horas")]
            hora2 = 13,
            [Description("2 horas e 20 minutos")]
            hora2min20 = 14,
            [Description("2 horas e 30 minutos")]
            hora2min30 = 15,
            [Description("2 horas e 40 minutos")]
            hora2min40 = 16,
            [Description("3 horas")]
            hora3 = 17,
            [Description("3 horas e 20 minutos")]
            hora3min20 = 18,
            [Description("3 horas e 30 minutos")]
            hora3min30 = 19,
            [Description("3 horas e 40 minutos")]
            hora3min40 = 20,
            [Description("4 horas")]
            hora4 = 21,
            [Description("4 horas e 20 minutos")]
            hora4min20 = 22,
            [Description("4 horas e 30 minutos")]
            hora4min30 = 23,
            [Description("4 horas e 40 minutos")]
            hora4min40 = 24,
            [Description("5 horas")]
            hora5 = 25,
            [Description("6 horas")]
            hora6 = 26,
            [Description("7 horas")]
            hora7 = 27,
            [Description("8 horas")]
            hora8 = 28,
            [Description("9 horas")]
            hora9 = 29,
            [Description("10 horas")]
            hora10 = 30,
            [Description("11 horas")]
            hora11 = 31,
            [Description("12 horas")]
            hora12 = 32
        }

        /// <summary>
        /// Pré atendimentos: remover comida, água, etc.
        /// </summary>
        public enum EnumPreAtendimento
        {
            [Description("Não é necessário")]
            NaoNecessario = 0,
            [Description("Remover comida e água na noite anterior")]
            ComidaAguaNoiteAnterior = 1,
            [Description("Remover comida na noite anterior")]
            ComidaNoiteAnterior = 2,
            [Description("Remover água na noite anterior")]
            AguaNoiteAnterior = 3,
        }


        /// <summary>
        /// O estado da execução do pré-atendimento: realizado ou não.
        /// </summary>
        public enum EnumStatusPreAtendimento
        {
            [Description("Não realizado")]
            NaoRealizado = 0,
            [Description("Realizado")]
            Realizado = 1,
            [Description("Cancelado")]
            Cancelado = 2,
        }

        public enum EnumFrequenciaRecomendada
        {
            [Description("Não é recorrente")]
            naoRecorrente = 0,
            [Description("Semanal")]
            semanal = 1,
            [Description("Quinzenal")]
            quinzenal = 2,
            [Description("Mensal")]
            mensal = 3,
            [Description("Trimentral")]
            trimentral = 4,
            [Description("Semestral")]
            semestral = 5,
            [Description("Anual")]
            anual = 6,
        }

        /// <summary>
        /// O estado da execução atendimento: realizado ou não.
        /// </summary>
        public enum StatusRealizacaoAtendimento
        {
            [Description("Não realizado")]
            NaoRealizado = 0,
            [Description("Realizado")]
            Realizado = 1,
            [Description("Cancelado")]
            Cancelado = 2,
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

            if (enumFrequenciaIngestao == (int)EnumFrequenciaIngestao.diariamenteXvezesDia)
                return $"{auxiliarX} vez ao dia";
            if (enumFrequenciaIngestao == (int)EnumFrequenciaIngestao.diariamenteCadaXhoras)
                return $"A cada {auxiliarX} hora(s)";
            if (enumFrequenciaIngestao == (int)EnumFrequenciaIngestao.cadaXdias)
                return $"A cada {auxiliarX} dia(s)";
            if (enumFrequenciaIngestao == (int)EnumFrequenciaIngestao.diasDaSemana)
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
            if (enumFrequenciaIngestao == (int)EnumAtendimento.EnumFrequenciaIngestao.ciclosXativosYinativos)
                return $"{auxiliarX} dia(s) ativo {auxiliarY} dia(s) inativo";
            return descricao;
        }
    }
}