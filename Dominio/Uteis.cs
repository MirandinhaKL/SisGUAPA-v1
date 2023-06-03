using System;
using System.ComponentModel;
using System.Reflection;

namespace Dominio
{
    public static class Uteis
    {
        /// <summary>
        /// Obem a descrição do item do enumerador.
        /// </summary>
        public static string GetDescricaoEnum(this Enum item)
        {
            Type tipo = item.GetType();
            FieldInfo fi = tipo.GetField(item.ToString());

            var atributos = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (atributos.Length > 0)
                return atributos[0].Description;
            else
                return string.Empty;
        }
    }
}
