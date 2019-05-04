using System.IO;

namespace Omicron
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("MainHd.txt"))
            {
                Stream saida = File.Open("MainHd.txt", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(saida);
                streamWriter.WriteLine("0");
                streamWriter.Close();
                saida.Close();
            }

            Menu menu = new Menu();
            menu.GeraMenu();

        }
    }
}
