﻿using System;
using System.Collections.Generic;

public class HD
{
    public HD()
    {
        Arquivos = new List<Arquivo>();
        Diretorio = new List<Diretorio>();
    }

    public String NomeHd { get; set; }
    public int Tamanho { get; set; }
    public Imagem Imagem { get; set; }
    public StatusHD StatusHd { get; set; }
    public List<Arquivo> Arquivos { get; set; }
    public List<Diretorio> Diretorio { get; set; }
}
