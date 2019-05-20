using System;
using System.Collections.Generic;

namespace Omicron.Acoes
{
    public static class Help
    {
        public static void Ajuda(string ajuda = "")
        {
            IDictionary<string,string> help = new Dictionary<string, string>();

            help.Add("createhd", "Serve para criar um novo HD Virtual. Sintaxe: createhd [nome] [Num Blocos] [Tam Bloco]\nOnde: [nome] = nome do HD\n[Num Blocos] = numero de blocos do HD\n[ Tam Bloco] = tamanho de cada bloco");
            help.Add("typehd", "Exibe conteúdo do HD Virtual no formato caracter e hexadecimal. Sintaxe: typehd [nome do hd]\nOnde: [nome do HD] = nome do HD");
            help.Add("selecthd", "Serve para selecionar um HD. Sintaxe: selecthd [nome do HD]\nOnde: [nome do HD] = nome do HD");
            help.Add("dirhd", "Serve para exibir a lista dos HDs que já foram criados pelo Sistema. Sintaxe: dirhd");
            help.Add("formathd", "Serve para formatar um HD previamente criado inicializando os blocos com seus valores iniciais como no momento de sua criação Sintaxe: formathd [nome do hd]\nOnde: [nome do hd] = nome do HD");
            help.Add("cd", "Serve para selecionar um diretório (pasta) alterando o prompt de acordo com a pasta selecionada Sintaxe: cd [nome da pasta]\nOnde: [nome da pasta] = nome da pasta a ser selecionada\nDois pontos (..) recua um nível na hierarquia de pastas\nPermite caminho completo da pasta");
            help.Add("cls", "Serve para limpar a tela da interface de comandos Sintaxe: cls");
            help.Add("create", "Permite a criação de um arquivo texto Sintaxe: create [nome do arquivo]\nOnde: [nome do arquivo] = nome do arquivo");
            help.Add("del", "Exclui um arquivo Sintaxe: del [nome do arquivo]\nOnde: [nome do arquivo] = nome do arquivo\nPode ser o nome completo do arquivo incluindo a pasta onde ele está");
            help.Add("dir", "Serve para exibir a lista de arquivos de uma determinada pasta incluindo o tamanho dos arquivos em número de bytes Sintaxe: dir [nome de pasta]\nOnde: [nome da pasta] = nome de pasta");
            help.Add("mkdir", "Cria um diretório (pasta) Sintaxe: mkdir [nome de pasta]\nOnde: [nome de pasta] = nome de pasta");
            help.Add("type", "Serve para exibir o conteúdo de um arquivo. Dá uma pausa quando preencher uma tela. Sintaxe: type [nome do arquivo]\nOnde: [nome do arquivo] = nome do arquivo");


            help.Add("statushd", "Exibe propriedades (espaço) do HD Virtual Sintaxe: statushd [nome]\nOnde: [nome do arquivo] = nome do arquivo");
            help.Add("removehd", "Remove HD Virtual Sintaxe: removehd [nome]\nOnde: [nome do arquivo] = nome do arquivo");
            help.Add("copyfrom", "Copia arquivo jpg do HD REAL para o HD VIRTUAL Sintaxe: copyfrom[nome][novo nome]\nOnde: [nome] = nome do arquivo no HD REAL\n[novonome] = nome do arquivo no HD VIRTUAL");
            help.Add("copyto", "Copia arquivo jpg do HD VIRTUAL para o HD REAL Sintaxe: copyto [nome] [novo nome]\nOnde: [nome] = nome do arquivo no HD VIRTUAL\n[novonome] = nome do arquivo no HD REAL");
            help.Add("renamedir", "Altera o nome de uma pasta Sintaxe: renamedir [nome] [novo nome]\nOnde: [nome] = nome de uma pasta\n[novonome] = novo nome da pasta");
            help.Add("copy", "Copia um arquivo ou arquivos de uma pasta para uma pasta destino Sintaxe: copy [nome] [local destino]\nOnde: [nome] = nome de arquivo ou pasta\n[local destino] = nome da pasta destino");
            help.Add("help", "Ajuda ou help sobre os comandos Sintaxe: help [comando]\nOnde: [comando] = nome de um comando");
            help.Add("move", "Move um arquivo ou pasta (e todo o seu conteúdo) para outra pasta Sintaxe: move [nome] [nomedepasta]\nOnde: [nome] = nome de um arquivo ou pasta\n[nomedepasta] = nome da pasta destino");
            help.Add("rename", "Altera o nome de um arquivo Sintaxe: rename [nome] [novonome\nOnde: [nome] = nome de arquivo\n[novonome] = novo nome do arquivo");
            help.Add("rmdir", "Remove diretório (pasta) e todo o seu conteúdo Sintaxe: rmdir [nome]\nOnde: [nome] = nome de uma pasta (diretório)");
            help.Add("tree", "Exibe graficamente a estrutura de diretórios (pastas) Sintaxe: tree");

            if (string.IsNullOrEmpty(ajuda))
            {
                foreach (var item in help.Keys)
                {
                    var text = help[item];
                    Console.WriteLine(item.PadRight(20,' ') + text.Substring(0, text.IndexOf("Sintaxe")));
                }
            }
            else
            {
                var text = help[ajuda];
                Console.WriteLine(text.Insert(text.IndexOf("Sintaxe"),"\n"));
            }
        }
    }
}