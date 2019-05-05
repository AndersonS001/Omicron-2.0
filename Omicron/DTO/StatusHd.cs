public class StatusHD
{
    public StatusHD()
    {
        NumeroPasta = 0;
        NumeroArquivos = 0;
        EspacoUtilizadoArquivo = 0;
        EspacoUtilizadoDiretorio = 0;
    }

    public int EspacoUtilizadoDiretorio { get; set; }
    public int EspacoUtilizadoArquivo { get; set; }
    public int NumeroPasta { get; set; }
    public int NumeroArquivos { get; set; }
}

