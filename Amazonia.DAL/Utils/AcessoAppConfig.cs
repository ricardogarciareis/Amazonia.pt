using System.Configuration;
using System.ComponentModel;
using System;

namespace Amazonia.DAL.Utils
{
    public static class AcessoAppConfig
    {
        public static string ObterValorDoConfig(string chave)
        {
            var valorDaChave = ConfigurationManager.AppSettings[chave];
            return valorDaChave;
        }

        
        //Método encontrado pelo Luís Ponciano
        public static T ObterValorDoConfigComConversao<T>(string chave)
        {
            try
            {
                var valorDaChave = ConfigurationManager.AppSettings[chave];

                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    return (T)converter.ConvertFromString(valorDaChave);
                }
                return default(T);
            }
            catch(ArgumentException)
            {
                return default(T);
            }
            catch (NotSupportedException)
            {
                return default(T);
            }
        }
    }
}
