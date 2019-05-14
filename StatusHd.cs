using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

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
                tam = deserializedProduct.Tamanho;
                espacoUtilizado = json.Length;
            }

            Console.WriteLine("Capacidade Total do HD: " + tam +"KB");
            Console.WriteLine("Espaço Utilizado  do HD: " + espacoUtilizado + "KB");
            Console.WriteLine("Espaço Livre  do HD: " + (tam - espacoUtilizado + "KB"));
            Console.WriteLine("Número de Pastas: " + deserializedProduct.StatusHd.NumeroPasta);
            Console.WriteLine("Número de Arquivos: " + deserializedProduct.StatusHd.NumeroArquivos);
        }
    }
}
