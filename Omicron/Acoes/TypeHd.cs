using System;
using System.IO;

namespace Omicron.Acoes
{
    public static class TypeHd
    {
        public static void ImprimeTudo(string hd)
        {
            try
            {
                var arq = File.Open(hd + ".txt", FileMode.Open);
                using (StreamReader sr = new StreamReader(arq))
                {
                    string linha = sr.ReadLine();
                    while(linha != null)
                    {
                        char[] hex = linha.ToCharArray();
                        Console.WriteLine(linha);
                        foreach (var item in hex)
                        {
                            int letra = Convert.ToInt32(item);
                            Console.Write($"{letra:X} ");
                        }
                        Console.WriteLine();
                        linha = sr.ReadLine();
                    }
                }

                Console.WriteLine("");
            }
            catch (Exception)
            {
                Console.WriteLine("HD não existente");
            }     
        }
    }
}
