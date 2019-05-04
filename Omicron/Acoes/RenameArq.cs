using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omicron.Acoes
{
    public static class RenameArq
    {
        public static void RenomeiaArquivo(string contexto, string nomeArq, string nomeArqNovo)
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
                foreach (var item in hdManipulado.Arquivos)
                {
                    if (item.NomeArquivo.Equals(nomeArq))
                    {
                        item.NomeArquivo = nomeArqNovo;
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
                    foreach (var item1 in item.Arquivos)
                    {
                        if (item1.NomeArquivo.Equals(nomeArq))
                        {
                            item1.NomeArquivo = nomeArqNovo;
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
                        foreach (var item2 in item.Arquivos)
                        {
                            if (item2.NomeArquivo.Equals(nomeArq))
                            {
                                item2.NomeArquivo = nomeArqNovo;
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
                            foreach (var item3 in item2.Arquivos)
                            {
                                if (item3.NomeArquivo.Equals(nomeArq))
                                {
                                    item3.NomeArquivo = nomeArqNovo;
                                    achou = true;
                                }
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
