using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Omicron.Acoes
{
    public static class Dir
    {
        public static void MostraDiretorios(string contexto)
        {
            var context = contexto.Split('/').ToList();
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

            if (context.Count == 1)
            {
                foreach (var item in hdManipulado.Arquivos)
                {
                    Console.WriteLine("-" + item.NomeArquivo);
                }

                foreach (var item in hdManipulado.Diretorio)
                {
                    Console.WriteLine("-" + item.NomeDiretorio);
                }
            }
            else if (context.Count == 2)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    if (item.NomeDiretorio.Contains(context[1]))
                    {
                        foreach (var item1 in item.Arquivos)
                        {
                            Console.WriteLine("-" + item1.NomeArquivo);
                        }
                        foreach (var item1 in item.SubPasta)
                        {
                            Console.WriteLine("-" + item1.NomeDiretorio);
                        }

                    }

                    
                }
            }
            else if (context.Count == 3)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item1 in item.SubPasta)
                    {
                        if (item1.NomeDiretorio.Contains(context[2]))
                        {
                            foreach (var item2 in item1.Arquivos)
                            {
                                Console.WriteLine("-" + item2.NomeArquivo);
                            }

                            foreach (var item2 in item1.SubPasta)
                            {
                                Console.WriteLine("-" + item2.NomeDiretorio);
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
                            if (item2.NomeDiretorio.Contains(context.Last()))
                            {
                                foreach (var item3 in item2.Arquivos)
                                {
                                    Console.WriteLine("-" + item3.NomeArquivo);
                                }

                                foreach (var item3 in item2.SubPasta)
                                {
                                    Console.WriteLine("-" + item3.NomeDiretorio);
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
