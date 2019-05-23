using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Omicron.Acoes
{
    public static class Copy
    {
        public static void Copia(string contexto, string copyFrom, string copiado)
        {
            var context = contexto.Replace(">", "").Split('/').ToList();
            if (context.Last().Equals(""))
            {
                _ = context.Remove(context.Last());
            }
            string hd = context[0];

            var copyTo = copiado.Replace(">", "").Split('/').ToList();
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
                var arquivo = hdManipulado.Arquivos.Find(x => x.NomeArquivo.Equals(copyFrom));

                var pasta = hdManipulado.Diretorio.Find(x => x.NomeDiretorio.Equals(copyFrom));

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
                var arquivo = new Arquivo();// = hdManipulado.Arquivos.Find(x => x.NomeArquivo.Equals(copyFrom));

                var pasta = new Diretorio();// hdManipulado.Diretorio.Find(x => x.NomeDiretorio.Equals(copyFrom));

                foreach (var item in hdManipulado.Diretorio)
                {
                    arquivo = item.Arquivos.Find(x => x.NomeArquivo.Equals(copyFrom));
                    pasta = item.SubPasta.Find(x => x.NomeDiretorio.Equals(copyFrom));
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
                var arquivo = new Arquivo();// = hdManipulado.Arquivos.Find(x => x.NomeArquivo.Equals(copyFrom));

                var pasta = new Diretorio();// hdManipulado.Diretorio.Find(x => x.NomeDiretorio.Equals(copyFrom));

                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item2 in item.SubPasta)
                    {
                        arquivo = item2.Arquivos.Find(x => x.NomeArquivo.Equals(copyFrom));
                        pasta = item2.SubPasta.Find(x => x.NomeDiretorio.Equals(copyFrom));
                        break;
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

                var arquivo = new Arquivo();// = hdManipulado.Arquivos.Find(x => x.NomeArquivo.Equals(copyFrom));

                var pasta = new Diretorio();// hdManipulado.Diretorio.Find(x => x.NomeDiretorio.Equals(copyFrom));

                foreach (var item in hdManipulado.Diretorio)
                {
                    foreach (var item2 in item.SubPasta)
                    {
                        foreach (var item3 in item2.SubPasta)
                        {
                            arquivo = item3.Arquivos.Find(x => x.NomeArquivo.Equals(copyFrom));
                            pasta = item3.SubPasta.Find(x => x.NomeDiretorio.Equals(copyFrom));
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
