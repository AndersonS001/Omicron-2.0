using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omicron.Acoes
{
    public static class SelectHd
    {
        public static bool SelecionaHd(string hd)
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
                return true;
            }

            return false;
        }
    }
}
