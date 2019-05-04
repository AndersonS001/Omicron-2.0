using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


