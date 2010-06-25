using Helpers.Net.SQLite;
using Xunit;
using Xunit.Extensions;

namespace Helpers.Net.Console.Tests
{
    public class ConsoleParametersParsingTests
    {
        [Theory]
        [InlineData("-h")]
        [InlineData("-?")]
        [InlineData("--help")]
        [InlineData("-help")]
        public void ShowsHelp(string args)
        {
            AspNetRegSQLite app = new AspNetRegSQLite(args);
            Assert.True(app.ShowHelp);
        }

        [Theory]
        [InlineData("-q")]
        public void QuietMode(string args)
        {
            AspNetRegSQLite aspNetRegSqLite = new AspNetRegSQLite(args);
            Assert.True(aspNetRegSqLite.EnableQuietMode);
        }

        [Theory]
        [InlineData(new[] { "-c=sqlite.db" }, "sqlite.db")]
        [InlineData(new[] { "-connectionString=sqlite.db" }, "sqlite.db")]
        [InlineData(new[] { "-c=Data Source=sqlite.db;Version=3" }, "Data Source=sqlite.db;Version=3")]
        [InlineData(new[] { "-c=Data Source=c:\\My Documents\\sqlite.db;Version=3" }, "Data Source=c:\\My Documents\\sqlite.db;Version=3")] // directory containing spaces
        public void ConnectionString(string[] args, string connectionString)
        {
            AspNetRegSQLite aspNetRegSqLite = new AspNetRegSQLite(args);
            Assert.Equal(connectionString, aspNetRegSqLite.ConnectionString);
        }

        [Theory]
        [InlineData(new[] { "-sqlexportonly=aspnetdb.sql" }, "aspnetdb.sql")]
        [InlineData(new[] { "-sqlexportonly=c:\\aspnetdb.sql" }, "c:\\aspnetdb.sql")] // windows format
        [InlineData(new[] { "-sqlexportonly=c:\\My Documents\\aspnetdb.sql" }, "c:\\My Documents\\aspnetdb.sql")] // windows format: directory containing spaces
        [InlineData(new[] { "-sqlexportonly=~/aspnetdb.sql" }, "~/aspnetdb.sql")] // linux format 
        [InlineData(new[] { "-sqlexportonly=/usr/Prabir Shrestha/aspnetdb.sql" }, "/usr/Prabir Shrestha/aspnetdb.sql")] // linux format: direcotry containing spaces
        public void SqlExportOnly(string[] args, string sqlFileName)
        {
            AspNetRegSQLite aspNetRegSqLite = new AspNetRegSQLite(args);
            Assert.Equal(sqlFileName, aspNetRegSqLite.SqlFileName);
        }
    }
}