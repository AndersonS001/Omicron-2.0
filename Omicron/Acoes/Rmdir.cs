using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Omicron.Acoes
{
    public static class Rmdir
    {
        public static void RemoveDiretorio(string contexto, string nomeDir)
        {
            var context = contexto.Replace(">", "").Split('/').ToList();
            if (context.Last().Equals(""))
            {
                _ = context.Remove(context.Last());
            }

            string hd = context[0];
            var arq = File.Open(hd + ".txt", FileMode.Open);
            HD hdManipulado;

            using (StreamReader sr = new StreamReader(arq))
            {
                hdManipulado = JsonConvert.DeserializeObject<HD>(sr.ReadToEnd());
            }

            Diretorio diretorio = new Diretorio();
            var achou = false;

            if (context.Count == 1)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    if(item.NomeDiretorio.Equals(nomeDir))
                    {
                        diretorio = item;
                        achou = true;
                    }
                }

                if(achou)
                {
                    hdManipulado.Diretorio.Remove(diretorio);
                    File.Delete(hd + ".txt");

                    CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
                }
            }
            else if (context.Count == 2)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item2 in item.SubPasta)
                    {
                        if (item2.NomeDiretorio.Equals(nomeDir))
                        {
                            diretorio = item;

                            item.SubPasta.Remove(item2);
                            File.Delete(hd + ".txt");
                            CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
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
                        if (item1.NomeDiretorio.Equals(context.Last()))
                        {
                            item.SubPasta.Remove(item1);
                            File.Delete(hd + ".txt");
                            CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
                        }
                    }
                }
            }
        }
    }
}
