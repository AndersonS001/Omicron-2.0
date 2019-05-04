using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Omicron.Acoes
{
    public static class Mkdir
    {
        public static void CriaDiretorio(string contexto, string nomeDir)
        {
            var context = contexto.Split('/');
            string hd = context[0];
            var arq = File.Open(hd + ".txt", FileMode.Open);
            HD hdManipulado;

            using (StreamReader sr = new StreamReader(arq))
            {
                hdManipulado = JsonConvert.DeserializeObject<HD>(sr.ReadToEnd());
            }

            Diretorio diretorio = new Diretorio
            {
                NomeDiretorio = nomeDir
            };

            if (context.Length == 1)
                hdManipulado.Diretorio.Add(diretorio);
            else if (context.Length == 2)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    if (item.NomeDiretorio.Equals(context[1]))
                    {
                        item.SubPasta.Add(diretorio);
                    }
                }
            }
            else
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item1 in item.SubPasta)
                    {
                        if (item1.NomeDiretorio.Equals(context.Last()))
                        {
                            item1.SubPasta.Add(diretorio);
                        }
                    }
                }
            }

            File.Delete(hd + ".txt");
            CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);

        }
    }
}
