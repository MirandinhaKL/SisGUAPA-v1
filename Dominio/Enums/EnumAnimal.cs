using System.ComponentModel;

namespace Dominio.Enums
{
    public static class EnumAnimal
    {
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
    }
}