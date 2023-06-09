using System.ComponentModel;

namespace Dominio.Enums
{
    public static class EnumPessoa
    {
        public enum EnumStatusUsuario
        {
            [Description("Ativo")]
            Ativo = 0,
            [Description("Inativo")]
            Inativo = 1,
        }
    }
}