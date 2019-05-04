using Newtonsoft.Json;
using System;
using System.IO;

namespace Omicron.Acoes
{
    public static class TypeArq
    {
        public static void MostrarTudo(string contexto, string arquivo)
        {
            var context = contexto.Split('/');
            string hd = context[0];

            var arq = File.Open(hd + ".txt", FileMode.Open);
            HD hdManipulado;

            using (StreamReader sr = new StreamReader(arq))
            {
                hdManipulado = JsonConvert.DeserializeObject<HD>(sr.ReadToEnd());
            }

            bool achou = false;

            if (context.Length == 1)
            {
                foreach (var item in hdManipulado.Arquivos)
                {
                    if (item.NomeArquivo.Equals(arquivo))
                    {
                        Console.WriteLine(item.ValorArquivo);
                        achou = true;
                    }
                }
            }
            else if (context.Length == 2)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item1 in item.Arquivos)
                    {
                        if (item1.NomeArquivo.Equals(arquivo))
                        {
                            Console.WriteLine(item1.ValorArquivo);
                            achou = true;
                        }
                    }
                }
            }
            else
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item1 in item.SubPasta)
                    {
                        foreach (var item2 in item1.Arquivos)
                        {
                            if (item2.NomeArquivo.Equals(arquivo))
                            {
                                Console.WriteLine(item2.ValorArquivo);
                                achou = true;
                            }
                        }
                    }
                }
            }

            if (!achou)
                Console.WriteLine("Arquivo não encontrado");
        }
    }
}
