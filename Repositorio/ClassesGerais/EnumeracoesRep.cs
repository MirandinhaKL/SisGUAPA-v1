using System.ComponentModel;

namespace Repositorio.ClassesGerais
{
    public class EnumeracoesRep
    {
        
        public enum EnumStatusAnimal
        {
            [Description("Adotado")]
            Adotado,
            [Description("Disponível")]
            Disponível,
            [Description("Morto")]
            Morto
        }

        public enum EnumStatusDaAcao
        {
            FALHA = -1,
            OK = 0,
        }
    }
}
