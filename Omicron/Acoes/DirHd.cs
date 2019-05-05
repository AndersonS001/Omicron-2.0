using System;
using System.Collections.Generic;
using System.IO;

namespace Omicron.Acoes
{
    public static class DirHd
    {
        public static void ListaHd()
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

            main.RemoveAt(0);
            foreach (var item in main)
            {
                Console.WriteLine("-" + item);
            }
        }
    }
}