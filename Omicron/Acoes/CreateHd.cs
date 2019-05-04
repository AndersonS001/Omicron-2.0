using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Omicron.Acoes
{
    public static class CreateHd
    {
        //public string Nome { get; set; }
        //public int Buffer { get; set; }

        //public CreateHd(string nome, int buffer)
        //{
        //    Nome = nome;
        //    Buffer = buffer;
        //}

        public static void CriarHd(string nome, int buffer, bool atualizaMain = false)
        {
            Stream saida = File.Open(nome + ".txt", FileMode.Create);
            HD hd = new HD();
            hd.NomeHd = nome;
            hd.Tamanho = buffer;

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(saida, Encoding.UTF8, buffer))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, hd);
            }

            if (atualizaMain)
            {
                List<string> main = new List<string>();

                saida = File.Open("MainHd.txt", FileMode.Open);
                using (StreamReader sw = new StreamReader(saida))
                {
                    string linha = sw.ReadLine();

                    while (linha != null)
                    {
                        main.Add(linha);
                        linha = sw.ReadLine();
                    }
                }

                saida = File.Open("MainHd.txt", FileMode.OpenOrCreate);
                main[0] = (int.Parse(main[0]) + 1) + "";
                main.Add(nome);
                using (StreamWriter sw = new StreamWriter(saida))
                {
                    foreach (var item in main)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
        }

        public static void CriaHdComJson(HD hd, string hdAbir, int buffer)
        {
            var saida = File.Open(hdAbir + ".txt", FileMode.CreateNew);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(saida, Encoding.UTF8, buffer))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, hd);
            }

        }
    }
}
