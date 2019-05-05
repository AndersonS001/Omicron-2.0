using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace Omicron.Acoes
{
    public static class StatusHd
    {
        public static void Status(string hd)
        {
            var arq = File.Open(hd + ".txt", FileMode.Open);
            HD deserializedProduct;
            var tam = 0;
            var espacoUtilizado = 0;

            using (StreamReader sr = new StreamReader(arq))
            {
                var json = sr.ReadToEnd();
                deserializedProduct = JsonConvert.DeserializeObject<HD>(json);
                tam = deserializedProduct.Tamanho * 1000;
                espacoUtilizado = json.Length;
            }


            Console.WriteLine("Capacidade Total do HD: " + tam);
            Console.WriteLine("Espaço Utilizado  do HD: " + espacoUtilizado);
            Console.WriteLine("Espaço Livre  do HD: " + (tam - espacoUtilizado));
            Console.WriteLine("Número de Pastas: " + deserializedProduct.StatusHd.NumeroPasta);
            Console.WriteLine("Número de Arquivos: " + deserializedProduct.StatusHd.NumeroArquivos);
        }
    }
}
