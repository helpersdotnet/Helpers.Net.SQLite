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
    }
}