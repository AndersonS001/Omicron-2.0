﻿using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;

namespace Omicron.Acoes
{
    public static class CopyFrom
    {
        public static void PegaImagem(string imagem, string nomeImagem, string contexto)
        {
            var context = contexto.Split('/');
            string hd = context[0];

            var arq = File.Open(hd + ".txt", FileMode.Open);
            HD hdManipulado;

            using (StreamReader sr = new StreamReader(arq))
            {
                hdManipulado = JsonConvert.DeserializeObject<HD>(sr.ReadToEnd());
            }

            Image im = Image.FromFile(imagem);

            MemoryStream ms = new MemoryStream();

            im.Save(ms, im.RawFormat);

            byte[] array = ms.ToArray();

            var imText = Convert.ToBase64String(array);

            hdManipulado.Imagem.NomeImagem = nomeImagem;
            hdManipulado.Imagem.ImagemTexto = imText;

            File.Delete(hd + ".txt");
            CreateHd.CriaHdComJson(hdManipulado, hd, hdManipulado.Tamanho);
        }
    }
}
