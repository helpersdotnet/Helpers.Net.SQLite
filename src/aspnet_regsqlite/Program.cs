
namespace Helpers.Net.SQLite
{
    class Program
    {
        static int Main(string[] args)
        {
            AspNetRegSQLite consoleApp = new AspNetRegSQLite(args);
            return consoleApp.Execute();
        }
    }
}
