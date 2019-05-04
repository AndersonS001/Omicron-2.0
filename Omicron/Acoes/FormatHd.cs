using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omicron.Acoes
{
    public static class FormatHd
    {
        public static void FormatarHd(string hd)
        {
            var saida = File.Open("MainHd.txt", FileMode.OpenOrCreate);
            List<string> main = new List<string>();

            using (StreamReader sw = new StreamReader(saida))
            {
                string linha = sw.ReadLine();

                while (linha != null)
                {
                    main.Add(linha);
                    linha = sw.ReadLine();
                }
            }

            if(main.Contains(hd))
            {
                int tam;
                var arq = File.Open(hd + ".txt", FileMode.Open);
                HD deserializedProduct;

                using (StreamReader sr = new StreamReader(arq))
                {
                    deserializedProduct = JsonConvert.DeserializeObject<HD>(sr.ReadToEnd());
                    tam = deserializedProduct.Tamanho;
                }
                
                File.Delete(hd + ".txt");
                CreateHd.CriarHd(hd, tam);
            }

        }
    }
}
