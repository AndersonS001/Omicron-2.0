using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Omicron.Acoes
{
    public static class Tree
    {
        public static void Arvore(string hd, string contexto)
        {
            var context = contexto.Replace(">", "").Split('/').ToList();
            if (context.Last().Equals(""))
            {
                _ = context.Remove(context.Last());
            }

            var arq = File.Open(hd + ".txt", FileMode.Open);
            HD hdManipulado;

            using (StreamReader sr = new StreamReader(arq))
            {
                var json = sr.ReadToEnd();
                hdManipulado = JsonConvert.DeserializeObject<HD>(json);
            }

            if (context.Count <= 2)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    Console.WriteLine("─" + item.NomeDiretorio);
                    foreach (var item1 in item.SubPasta)
                    {
                        Console.Write(" │");
                        Console.WriteLine("───" + item1.NomeDiretorio);
                        foreach (var item2 in item1.SubPasta)
                        {
                            Console.Write(" │");
                            Console.Write("   │");
                            Console.WriteLine("──────" + item2.NomeDiretorio);
                            foreach (var item3 in item2.SubPasta)
                            {
                                Console.Write(" │");
                                Console.Write("   │");
                                Console.WriteLine("─────────" + item3.NomeDiretorio);
                            }
                        }
                    }
                }
            }
            else if (context.Count == 3)
            {
                foreach (var item in hdManipulado.Diretorio)
                {
                    //Console.WriteLine("─" + item.NomeDiretorio);
                    foreach (var item1 in item.SubPasta)
                    {
                        if (item1.NomeDiretorio.Equals(context.Last()))
                        {
                            //Console.Write(" │");
                            Console.WriteLine("───" + item1.NomeDiretorio);
                            foreach (var item2 in item1.SubPasta)
                            {
                                //Console.Write(" │");
                                Console.Write("   │");
                                Console.WriteLine("──────" + item2.NomeDiretorio);
                                foreach (var item3 in item2.SubPasta)
                                {
                                    Console.Write(" │");
                                    Console.Write("   │");
                                    Console.WriteLine("─────────" + item3.NomeDiretorio);
                                }
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
                        //Console.WriteLine("─" + item.NomeDiretorio);
                        foreach (var item2 in item1.SubPasta)
                        {
                            //Console.Write(" │");
                            //Console.WriteLine("───" + item1.NomeDiretorio);
                            foreach (var item3 in item2.SubPasta)
                            {
                                Console.Write(" │");
                                Console.Write("   │");
                                Console.WriteLine("──────" + item3.NomeDiretorio);
                            }
                        }
                    }
                }
            }
        }
    }
}
