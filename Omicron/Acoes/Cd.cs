using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;

namespace Omicron.Acoes
{
    public static class Cd
    {
        public static void ProximoNivel(string hd, string proximoNivel, ref string contexto)
        {
            hd = hd.Split('/')[0];

            if (proximoNivel.Equals(".."))
            {
                var context = contexto.Replace(">", "").Split('/').ToList();
                if (context.Last().Equals(""))
                {
                    _ = context.Remove(context.Last());
                }

                context.Remove(context.Last());

                StringBuilder sb = new StringBuilder("");
                foreach (var item in context)
                {
                    sb.Append(item);
                    sb.Append("/");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(">");
                contexto = sb.ToString();
            }
            else
            {
                var arq = File.Open(hd + ".txt", FileMode.Open);
                HD hdManipulado;

                using (StreamReader sr = new StreamReader(arq))
                {
                    hdManipulado = JsonConvert.DeserializeObject<HD>(sr.ReadToEnd());
                }

                var context = contexto.Replace(">", "").Split('/').ToList();                
                if (context.Last().Equals(""))
                {
                    _ = context.Remove(context.Last());
                }


                if (context.Count == 1)
                {
                    foreach (var item in hdManipulado.Diretorio)
                    {
                        if (item.NomeDiretorio.Equals(proximoNivel))
                            contexto = string.Concat(contexto.Replace(">", "").Replace("/", ""), "/", proximoNivel, ">");
                    }
                }
                else if (context.Count == 2)
                {
                    foreach (var item in hdManipulado.Diretorio)
                    {
                        foreach (var item1 in item.SubPasta)
                        {
                            if (item1.NomeDiretorio.Equals(proximoNivel))
                                contexto = string.Concat(contexto.Replace(">", ""), "/", proximoNivel, ">");
                        }
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
                                if (item2.NomeDiretorio.Equals(proximoNivel))
                                    contexto = string.Concat(contexto.Replace(">", ""),"/", proximoNivel, ">");
                            }
                        }
                    }
                }
            }
        }
    }
}