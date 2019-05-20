using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Omicron.Acoes
{
    public static class Move
    {
        public static void Movimenta(string contexto, string moveFrom, string movido)
        {
            var context = contexto.Replace(">", "").Split('/').ToList();
            if (context.Last().Equals(""))
            {
                _ = context.Remove(context.Last());
            }
            string hd = context[0];

            var copyTo = movido.Replace(">", "").Split('/').ToList();
            if (copyTo.Last().Equals(""))
                _ = copyTo.Remove(copyTo.Last());

            var arq = File.Open(hd + ".txt", FileMode.Open);
            HD hdManipulado;

            using (StreamReader sr = new StreamReader(arq))
            {
                hdManipulado = JsonConvert.DeserializeObject<HD>(sr.ReadToEnd());
            }

            if (context.Count == 1)
            {
                var arquivo = hdManipulado.Arquivos.Find(x => x.NomeArquivo.Equals(moveFrom));
                hdManipulado.Arquivos.Remove(arquivo);

                var pasta = hdManipulado.Diretorio.Find(x => x.NomeDiretorio.Equals(moveFrom));
                hdManipulado.Diretorio.Remove(pasta);

                if (arquivo != null)
                {
                    for (int i = 0; i < hdManipulado.Diretorio.Count; i++)
                    {
                        if (copyTo.Count > 1)
                        {
                            for (int j = 0; j < hdManipulado.Diretorio[i].SubPasta.Count; j++)
                            {

                                var xx = hdManipulado.Diretorio[i].SubPasta.FindIndex(x => x.NomeDiretorio.Equals(copyTo.Last()));

                                if (xx > -1)
                                    hdManipulado.Diretorio[i].SubPasta[xx].Arquivos.Add(arquivo);
                            }
                        }
                        else
                        {
                            var xx = hdManipulado.Diretorio.FindIndex(x => x.NomeDiretorio.Equals(copyTo.Last()));

                            if (xx > -1)
                                hdManipulado.Diretorio[i].Arquivos.Add(arquivo);
                        }
                    }
                }
                else if (pasta != null)
                {
                    //for (int i = 0; i < hdManipulado.Diretorio.Count; i++)
                    //{
                    //    if (copyTo.Count > 1)
                    //    {
                    //        for (int j = 0; j < hdManipulado.Diretorio[i].SubPasta.Count; j++)
                    //        {

                    //            var xx = hdManipulado.Diretorio[i].SubPasta.FindIndex(x => x.NomeDiretorio.Equals(copyTo.Last()));

                    //            if (xx > -1)
                    //                hdManipulado.Diretorio[i].SubPasta[xx].SubPasta.Add(pasta);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        var xx = hdManipulado.Diretorio.FindIndex(x => x.NomeDiretorio.Equals(copyTo.Last()));

                    //        if (xx > -1)
                    //            hdManipulado.Diretorio[i].SubPasta.Add(pasta);
                    //    }
                    //}
                }
            }
            else if (context.Count == 2)
            {
                var arquivo = new Arquivo();// = hdManipulado.Arquivos.Find(x => x.NomeArquivo.Equals(moveFrom));

                var pasta = new Diretorio();// hdManipulado.Diretorio.Find(x => x.NomeDiretorio.Equals(moveFrom));

                foreach (var item in hdManipulado.Diretorio)
                {
                    arquivo = item.Arquivos.Find(x => x.NomeArquivo.Equals(moveFrom));
                    item.Arquivos.Remove(arquivo);
                    pasta = item.SubPasta.Find(x => x.NomeDiretorio.Equals(moveFrom));
                    item.SubPasta.Remove(pasta);
                }

                if (arquivo != null)
                {
                    for (int i = 0; i < hdManipulado.Diretorio.Count; i++)
                    {
                        if (copyTo.Count >= 1)
                        {
                            for (int j = 0; j < hdManipulado.Diretorio[i].SubPasta.Count; j++)
                            {

                                var xx = hdManipulado.Diretorio[i].SubPasta.FindIndex(x => x.NomeDiretorio.Equals(copyTo.Last()));

                                if (xx > -1)
                                    hdManipulado.Diretorio[i].SubPasta[xx].Arquivos.Add(arquivo);
                            }
                        }
                        else
                        {
                            var xx = hdManipulado.Diretorio.FindIndex(x => x.NomeDiretorio.Equals(copyTo.Last()));

                            if (xx > -1)
                                hdManipulado.Diretorio[i].Arquivos.Add(arquivo);
                        }
                    }


                }
                else if (pasta != null)
                {

                }

            }
            else if (context.Count == 3)
            {
                var arquivo = new Arquivo();// = hdManipulado.Arquivos.Find(x => x.NomeArquivo.Equals(moveFrom));

                var pasta = new Diretorio();// hdManipulado.Diretorio.Find(x => x.NomeDiretorio.Equals(moveFrom));

                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item2 in item.SubPasta)
                    {
                        arquivo = item2.Arquivos.Find(x => x.NomeArquivo.Equals(moveFrom));
                        item2.Arquivos.Remove(arquivo);
                        pasta = item2.SubPasta.Find(x => x.NomeDiretorio.Equals(moveFrom));
                        item2.SubPasta.Remove(pasta);
                    }
                }

                if (arquivo != null)
                {
                    for (int i = 0; i < hdManipulado.Diretorio.Count; i++)
                    {
                        if (copyTo.Count > 1)
                        {
                            for (int j = 0; j < hdManipulado.Diretorio[i].SubPasta.Count; j++)
                            {

                                var xx = hdManipulado.Diretorio[i].SubPasta.FindIndex(x => x.NomeDiretorio.Equals(copyTo.Last()));

                                if (xx > -1)
                                    hdManipulado.Diretorio[i].SubPasta[xx].Arquivos.Add(arquivo);
                            }
                        }
                        else
                        {
                            var xx = hdManipulado.Diretorio.FindIndex(x => x.NomeDiretorio.Equals(copyTo.Last()));

                            if (xx > -1)
                                hdManipulado.Diretorio[i].Arquivos.Add(arquivo);
                        }
                    }


                }
                else if (pasta != null)
                {

                }

            }
            else
            {

                var arquivo = new Arquivo();// = hdManipulado.Arquivos.Find(x => x.NomeArquivo.Equals(moveFrom));

                var pasta = new Diretorio();// hdManipulado.Diretorio.Find(x => x.NomeDiretorio.Equals(moveFrom));

                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item2 in item.SubPasta)
                    {
                        foreach (var item3 in item2.SubPasta)
                        {
                            arquivo = item3.Arquivos.Find(x => x.NomeArquivo.Equals(moveFrom));
                            item2.Arquivos.Remove(arquivo);
                            pasta = item3.SubPasta.Find(x => x.NomeDiretorio.Equals(moveFrom));
                            item3.SubPasta.Remove(pasta);
                        }
                    }
                }

                if (arquivo != null)
                {
                    for (int i = 0; i < hdManipulado.Diretorio.Count; i++)
                    {
                        if (copyTo.Count > 1)
                        {
                            for (int j = 0; j < hdManipulado.Diretorio[i].SubPasta.Count; j++)
                            {
                                var xx = hdManipulado.Diretorio[i].SubPasta.FindIndex(x => x.NomeDiretorio.Equals(copyTo.Last()));

                                if (xx > -1)
                                    hdManipulado.Diretorio[i].SubPasta[xx].Arquivos.Add(arquivo);
                            }
                        }
                        else
                        {
                            var xx = hdManipulado.Diretorio.FindIndex(x => x.NomeDiretorio.Equals(copyTo.Last()));

                            if (xx > -1)
                                hdManipulado.Diretorio[i].Arquivos.Add(arquivo);
                        }
                    }


                }
                else if (pasta != null)
                {

                }


            }


            File.Delete(hd + ".txt");
            CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);

        }
    }
}