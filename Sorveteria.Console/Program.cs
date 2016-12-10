using Sorveteria.Dao;

namespace Sorveteria.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var ping = new Ping().TemosConexao();

            System.Console.WriteLine(ping.Message);
            System.Console.ReadKey();
        }
    }
}
