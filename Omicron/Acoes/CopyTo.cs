using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;

namespace Omicron.Acoes
{
    public static class CopyTo
    {
        public static void EnviaImagem(string imagem, string nomeImagem, string contexto)
        {
            var context = contexto.Split('/');
            string hd = context[0];

            var arq = File.Open(hd + ".txt", FileMode.Open);
            HD hdManipulado;

            using (StreamReader sr = new StreamReader(arq))
            {
                hdManipulado = JsonConvert.DeserializeObject<HD>(sr.ReadToEnd());
            }

            if (hdManipulado.Imagem.NomeImagem.Equals(imagem))
            {
                byte[] array = Convert.FromBase64String(hdManipulado.Imagem.ImagemTexto);

                Image image = Image.FromStream(new MemoryStream(array));

                image.Save(nomeImagem);
            }
        }
    }
}
