using System.ComponentModel;

namespace Dominio.Enums
{
    public static class EnumGeral
    {
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
              
    }
}
