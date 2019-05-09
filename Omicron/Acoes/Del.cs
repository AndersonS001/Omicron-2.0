using Newtonsoft.Json;
using System;
using System.IO;

namespace Omicron.Acoes
{
    public static class Del
    {
        public static void Deleta(string contexto, string nome)
        {
            try
            {
                var context = contexto.Split('/');
                string hd = context[0];
                var arq = File.Open(hd + ".txt", FileMode.Open);
                HD hdManipulado;

                using (StreamReader sr = new StreamReader(arq))
                {
                    hdManipulado = JsonConvert.DeserializeObject<HD>(sr.ReadToEnd());
                }

                Arquivo arquivo = new Arquivo();

                if (context.Length == 1)
                {
                    foreach (var item in hdManipulado.Arquivos)
                    {
                        if (item.NomeArquivo.Equals(nome))
                        {
                            arquivo = item;

                            hdManipulado.Arquivos.Remove(arquivo);
                            hdManipulado.StatusHd.NumeroArquivos--;
                            File.Delete(hd + ".txt");

                            CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
                        }
                    }
                }
                else if (context.Length == 2)
                {
                    foreach (var item in hdManipulado.Diretorio)
                    {
                        foreach (var item1 in item.Arquivos)
                        {
                            if (item1.NomeArquivo.Equals(nome))
                            {
                                arquivo = item1;
                                item.Arquivos.Remove(item1);
                                hdManipulado.StatusHd.NumeroArquivos--;
                                File.Delete(hd + ".txt");
                                CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
                            }
                        }
                    }
                }
                else if(context.Length == 3)
                {
                    foreach (var item in hdManipulado.Diretorio)
                    {
                        foreach (var item1 in item.SubPasta)
                        {
                            foreach (var item2 in item1.Arquivos)
                            {
                                if (item2.NomeArquivo.Equals(nome))
                                {
                                    arquivo = item2;
                                    hdManipulado.StatusHd.NumeroArquivos--;
                                    item1.Arquivos.Remove(item2);
                                    File.Delete(hd + ".txt");
                                    CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
                                }
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
                                foreach (var item3 in item2.Arquivos)
                                {
                                    if (item3.NomeArquivo.Equals(nome))
                                    {
                                        hdManipulado.StatusHd.NumeroArquivos--;
                                        item2.Arquivos.Remove(item3);
                                        File.Delete(hd + ".txt");
                                        CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("Arquivo não encontrado");
            }
        }
    }
}
