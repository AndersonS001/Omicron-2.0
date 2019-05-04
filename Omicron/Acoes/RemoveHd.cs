using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omicron.Acoes
{
    public static class RemoveHd
    {
        public static void RemoverHd(string nomeHd)
        {
            List<string> main = new List<string>();

            var saida = File.Open("MainHd.txt", FileMode.Open);
            using (StreamReader sw = new StreamReader(saida))
            {
                string linha = sw.ReadLine();

                while (linha != null)
                {
                    main.Add(linha);
                    linha = sw.ReadLine();
                }
            }

            if (main.Contains(nomeHd))
            {
                saida = File.Open("MainHd.txt", FileMode.Truncate);
                main[0] = (int.Parse(main[0]) - 1) + "";
                main.Remove(nomeHd);
                File.Delete(nomeHd+".txt");
                
                using (StreamWriter sw = new StreamWriter(saida))
                {
                    foreach (var item in main)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
        }
    }
}
