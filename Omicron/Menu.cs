using Omicron.Acoes;
using System;

public class Menu
{
    public Menu()
    {
    }

    public void GeraMenu()
    {
        Console.WriteLine("WELCOME TO OMICRON");

        string comando, contexto = ">", hdSelecionado = string.Empty;
        comando = String.Empty;

        while (!comando.Equals("exit"))
        {
            Console.Write(contexto);
            comando = Console.ReadLine();

            string[] comand = comando.Split(' ');

            try
            {
                switch (comand[0])
                {
                    case "createhd":
                        int buffer, linha, coluna;
                        int.TryParse(comand[2], out linha);
                        int.TryParse(comand[3], out coluna);
                        buffer = linha * coluna;

                        CreateHd.CriarHd(comand[1], buffer, true);
                        break;
                    case "cls":
                        Console.Clear();
                        break;
                    case "selecthd":
                        var existe = SelectHd.SelecionaHd(comand[1]);
                        if (existe)
                        {
                            hdSelecionado = comand[1];
                            contexto = hdSelecionado + ">";
                        }
                        else
                            Console.WriteLine("HD não reconhecido");
                        break;
                    case "dirhd":
                        DirHd.ListaHd();
                        break;
                    case "formathd":
                        FormatHd.FormatarHd(comand[1]);
                        break;
                    case "statushd":
                        StatusHd.Status(comand[1]);
                        break;
                    case "typehd":
                        TypeHd.ImprimeTudo(comand[1]);
                        break;
                    case "create":
                        if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            Create.CriaArquivo(contexto.Replace(">", ""), comand[1], comand[2]);
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    case "del":
                        if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            Del.Deleta(contexto.Replace(">", ""), comand[1]);
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    case "rmdir":
                        if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            Rmdir.RemoveDiretorio(contexto.Replace(">", ""), comand[1]);
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    case "type":
                        if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            TypeArq.MostrarTudo(contexto.Replace(">", ""), comand[1]);
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    case "renamedir":
                        if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            RenameDir.RenomeiaDir(contexto.Replace(">", ""), comand[1], comand[2]);
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    case "rename":
                        if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            RenameArq.RenomeiaArquivo(contexto.Replace(">", ""), comand[1], comand[2]);
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    case "mkdir":
                        if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            Mkdir.CriaDiretorio(contexto.Replace(">", ""), comand[1]);
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    case "dir":
                        if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            Dir.MostraDiretorios(contexto.Replace(">", ""));
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    case "copyfrom":
                        if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            CopyFrom.PegaImagem(comand[1], comand[2], contexto.Replace(">", ""));
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    case "copyto":
                        if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            CopyTo.EnviaImagem(comand[1], comand[2], contexto.Replace(">", ""));
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    case "tree":
                        if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            Tree.Arvore(hdSelecionado, contexto.Replace(">", ""));
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    case "removehd":
                        RemoveHd.RemoverHd(comand[1]);
                        break;
                    case "cd":
                        if (comand[1].Equals("..") && string.Concat(hdSelecionado + ">").Equals(contexto))
                        {
                            hdSelecionado = string.Empty;
                            contexto = ">";
                        }
                        else if (!String.IsNullOrEmpty(hdSelecionado))
                        {
                            contexto = SeparaDir(contexto, comand);
                        }
                        else
                            Console.WriteLine("Por favor, selecione um hd");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("....");
            }
        }
    }

    private static string SeparaDir(string contexto, string[] comand)
    {
        Cd.ProximoNivel(hd: contexto.Replace(">", ""), comand[1], ref contexto);
        return contexto;
    }
}
