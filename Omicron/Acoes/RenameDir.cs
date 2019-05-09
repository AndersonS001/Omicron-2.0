using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Omicron.Acoes
{
    public static class RenameDir
    {
        public static void RenomeiaDir(string contexto, string nomeDir, string nomeDirNovo)
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

            var achou = false;

            if (context.Count == 1)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    if (item.NomeDiretorio.Equals(nomeDir))
                    {
                        item.NomeDiretorio = nomeDirNovo;
                        achou = true;
                    }
                }

                if (achou)
                {
                    File.Delete(hd + ".txt");
                    CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
                }
            }
            else if (context.Count == 2)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item1 in item.SubPasta)
                    {
                        if (item1.NomeDiretorio.Equals(nomeDir))
                        {
                            item1.NomeDiretorio = nomeDirNovo;
                            achou = true;
                        }
                    }
                }

                if (achou)
                {
                    File.Delete(hd + ".txt");
                    CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
                }
            }
            else if (context.Count == 3)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item1 in item.SubPasta)
                    {
                        foreach (var item2 in item1.SubPasta)
                        {
                            if (item2.NomeDiretorio.Equals(nomeDir))
                            {
                                item2.NomeDiretorio = nomeDirNovo;
                                achou = true;
                            }
                        }
                    }
                }

                if (achou)
                {
                    File.Delete(hd + ".txt");
                    CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
                }
            }
            else
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item1 in item.SubPasta)
                    {
                        foreach (var item2 in item1.SubPasta)
                        {
                            if (item2.NomeDiretorio.Equals(nomeDir))
                            {
                                item2.NomeDiretorio = nomeDirNovo;
                                achou = true;
                            }
                        }
                    }
                }

                if (achou)
                {
                    File.Delete(hd + ".txt");
                    CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
                }
            }
        }
    }
}
