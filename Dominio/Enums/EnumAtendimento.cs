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
    }
}
