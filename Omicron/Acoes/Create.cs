using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Omicron.Acoes
{
    public static class Create
    {
        public static void CriaArquivo(string contexto, string nomeArq, string valorArq)
        {
            var context = contexto.Split('/');
            string hd = context[0];

            var arq = File.Open(hd + ".txt", FileMode.Open);
            HD hdManipulado;

            using (StreamReader sr = new StreamReader(arq))
            {
                hdManipulado = JsonConvert.DeserializeObject<HD>(sr.ReadToEnd());
            }

            Arquivo arquivo = new Arquivo
            {
                NomeArquivo = nomeArq,
                ValorArquivo = valorArq
            };

            if (hdManipulado.Arquivos == null)
                hdManipulado.Arquivos = new List<Arquivo>();

            if (context.Length == 1)
                hdManipulado.Arquivos.Add(arquivo);
            else if (context.Length == 2)
            {
                Diretorio ax = hdManipulado.Diretorio.Find(x => x.NomeDiretorio.Equals(context.Last()));

                foreach (var item in hdManipulado.Diretorio)
                {
                    if (item.NomeDiretorio.Equals(context[1]))
                    {
                        item.Arquivos.Add(arquivo);
                    }
                }
            }
            else if(context.Length == 3)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item1 in item.SubPasta)
                    {
                        if (item1.NomeDiretorio.Equals(context[2]))
                        {
                            item1.Arquivos.Add(arquivo);
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
                        foreach (var item2 in item1.SubPasta)
                        {
                            if (item2.NomeDiretorio.Equals(context[3]))
                            {
                                item2.Arquivos.Add(arquivo);
                            }
                        }
                    }
                }
            }
            File.Delete(hd + ".txt");
            CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);

        }
    }
}
