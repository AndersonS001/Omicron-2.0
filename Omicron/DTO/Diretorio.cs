using System.Collections.Generic;

public class Diretorio
{
    public Diretorio()
    {
        Arquivos = new List<Arquivo>();
        SubPasta = new List<Diretorio>();
    }

    public string NomeDiretorio { get; set; }
    public List<Arquivo> Arquivos { get; set; }
    public List<Diretorio> SubPasta { get; set; }
}


