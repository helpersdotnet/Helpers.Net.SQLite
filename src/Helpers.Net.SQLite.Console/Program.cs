
namespace Helpers.Net.SQLite
{
    class Program
    {
        static int Main(string[] args)
        {
            SQLiteConsole consoleApp = new SQLiteConsole(args);
            return consoleApp.Execute();
        }
    }
}
