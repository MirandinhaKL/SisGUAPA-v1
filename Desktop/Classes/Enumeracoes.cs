using System.ComponentModel;

namespace Desktop.Classes
{
    public class Enumeracoes
    {
        /// <summary>
        /// Níveis de acesso ao sistema
        /// </summary>
        public enum EnumGrauAcesso
        {
            [Description("Administrador")]
            Administrador,
            [Description("Usuário comum")]
            UsuarioComum,
            [Description("Somente consulta")]
            SomenteConsulta
        }

        /// <summary>
        /// Nomenclatura do status das ações efetuadas no sistema.
        /// </summary>
        public enum EnumStatusDaAcao
        {
            FALHA = -1,
            OK = 0,
        }

        /// <summary>
        /// Possibilidades binárias
        /// </summary>
        public enum EnumPossibilidades 
        { 
            [Description("Não")]
            Nao = 0,
            [Description("Sim")]
            Sim = 1,
            [Description("Não Informado")]
            NaoSei = 2
        }

        /// <summary>
        /// Opções de gêneros
        /// </summary>
        public enum EnumGenero
        {
           [Description("")]
           Vazio = -1,
           [Description("Feminino")]
           Feminino = 0,
           [Description("Masculino")]
           Masculino = 1,
           [Description("Não informado")]
           NaoSei = 2
        }

        /// <summary>
        /// Opçoes do form auxiliar
        /// </summary>
        public enum EnumTelaAuxiliar
        {
            [Description("Cor")]
            Cor = 1,
            [Description("Porte")]
            Porte = 2,
            [Description("Espécie")]
            Especie = 3,
            [Description("Razão do falecimento")]
            MotivoFalecimento = 4,
            [Description("Motivo do recolhimento")]
            MotivoRecolhimento = 5
        }

        /// <summary>
        /// Ações dos botões dos Forms
        /// </summary>
        public enum EnumAcaoBotao 
        {
            Novo = 1,
            Editar = 2,
            Excluir = 3
        }

        public enum EnumTipoTela
        {
            Consulta = 1,
            Cadastro = 2,
            Edicao = 3,
            ConsultaECadastro = 4
        }


        /// <summary>
        /// Classificação das entidades que tem interesse no sistema.
        /// </summary>
        public enum EnumTipoEntidades
        {
            [Description("Associação")]
            Associacao,
            [Description("Canil")]
            Canil,
            [Description("Gatil")]
            Gatil,
            [Description("Lar temporário")]
            LarTemporario,
            [Description("ONG")]
            ONG,
            [Description("Outros")]
            Outros,
            [Description("Prefeitura")]
            Prefeitura,
            [Description("Protetor Individual")]
            ProtetorIndividual
        }

        public enum EnumFaixasEtarias
        {
            [Description("")]
            Vazio = 1,
            [Description("Menor que 1 mês")]
            Menos1mes = 2,
            [Description("De 1 a 2 meses")]
            De1a2meses = 3,
            [Description("De 2 a 3 meses")]
            De2a3Meses = 4,
            [Description("De 3 a 6 meses")]
            De3a6meses = 5,
            [Description("De 6 meses a 1 ano")]
            De6mesesA1ano = 6,
            [Description("De 1 a 2 anos")]
            De1a2anos = 7,
            [Description("De 2 a 5 anos")]
            De2a5anos = 8,
            [Description("De 5 a 10 anos")]
            De5a10anos = 9,
            [Description("De 10 a 15 anos")]
            De10a15anos = 10,
            [Description("De 15 a 20 anos")]
            De15a20anos = 11,
            [Description("Maior que 20 anos")]
            Maior20anos = 12
        }

        public enum EnumStatusAnimal
        {
            [Description("Adotado")]
            Adotado, 
            [Description("Disponível")]
            Disponível,
            [Description("Morto")]
            Morto
        }

        /// <summary>
        /// Padronização da mensagem exibida ao usuário referente as operações CRUD dos dados.
        /// </summary>
        public enum EnumMensagemAoUsuario
        {
            [Description("salvos")]
            Salvar = 1,
            [Description("editados")]
            Editar = 2,
            [Description("excluídos")]
            Excluir = 3
        }


        /// <summary>
        /// Padronização da mensagem de falha exibida ao usuário referente as operações CRUD dos dados.
        /// </summary>
        public enum EnumMensagemErroAoUsuario
        {
            [Description("salvar")]
            Salvar = 1,
            [Description("editar")]
            Editar = 2,
            [Description("excluir")]
            Excluir = 3
        }

        /// <summary>
        /// Formato de arquivos para impressão de dados.
        /// </summary>
        public enum EnumFormatoArquivo 
        { 
            [Description("CSV(*.csv)|*csv")]
            CSV = 1,
            [Description("PDF(*.pdf) | *pdf")]
            PDF = 2
        }

        /// <summary>
        /// Estados do Brasil
        /// </summary>
        public enum EnumEstadosBrasil
        {
            AC,
            AL,
            AP,
            AM,
            BA,
            CE,
            ES,
            GO,
            MA,
            MT,
            MS,
            MG,
            PA,
            PB,
            PR,
            PE,
            PI,
            RJ,
            RN,
            RS,
            RO,
            RR,
            SC,
            SP,
            SE,
            TO
        }

        /// <summary>
        /// Estado civil
        /// </summary>
        public enum EnumEstadoCivil
        {
            [Description("Solteiro")]
            Solteiro = 1,
            [Description("Casado")]
            Casado = 2,
            [Description("Outros")]
            Outros = 3
        }

        public enum EnumStatusUsuario
        {
            [Description("Ativo")]
            Ativo = 0,
            [Description("Inativo")]
            Inativo = 1,
        }

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
            sementral = 5,
            [Description("Anual")]
            anual = 6,
        }

        /// <summary>
        /// Pré atendimentos: remover comida, água, etc.
        /// </summary>
        public enum EnumPreAtendimento
        {
            [Description("Não é necessário")]
            naoNecessario = 0,
            [Description("Remover comida e água na noite anterior")]
            comidaAguaNoiteAnterior = 1,
            [Description("Remover comida na noite anterior")]
            comidaNoiteAnterior = 2,
            [Description("Remover água na noite anterior")]
            aguaNoiteAnterior = 3,
        }

        /// <summary>
        /// O estado da execução do pré-atendimento: realizado ou não.
        /// </summary>
        public enum EnumStatusPreAtendimento
        {
            [Description("Não realizado")]
            naoRealizado = 0,
            [Description("Realizado")]
            realizado = 1,
            [Description("Cancelado")]
            cancelado = 2,
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

        /// <summary>
        /// Status dos tratamentos cadastrados nos atendimentos.
        /// </summary>
        public enum EnumStatusTratamento 
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
            [Description("Parcial")]
            parcialmenteIniciado = 5
        }

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


        /// <summary>
        /// O estado da execução atendimento: realizado ou não.
        /// </summary>
        public enum StatusRealizacaoAtendimento
        {
            [Description("Não realizado")]
            naoRealizado = 0,
            [Description("Realizado")]
            realizado = 1,
            [Description("Cancelado")]
            cancelado = 2,
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
    }
}
