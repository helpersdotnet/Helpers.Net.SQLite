using System;
using System.Collections.Generic;
using NDesk.Options;
using System.Text;

namespace Helpers.Net.SQLite
{
    public class AspNetRegSQLite
    {
        private readonly bool _isDotNetStyleHelp;

        #region Command Line Options

        public bool ShowHelp { get; set; }
        public bool EnableQuietMode { get; set; }
        public IEnumerable<string> Extra { get; set; }
        public string ConnectionString { get; set; }
        public string SqlFileName { get; set; }

        private readonly OptionSet _optionSet;

        #endregion

        public AspNetRegSQLite()
        {
#if DOTNETSTYLE_HELP
            _isDotNetStyleHelp = true;
#endif
        }

        public AspNetRegSQLite(string args) :
            this(args.Split(' '))
        {

        }

        public AspNetRegSQLite(IEnumerable<string> args)
            : this()
        {
            _optionSet = new OptionSet
                             {
                                 {
                                     "?|h|help", "Display this help text.", 
                                     v => ShowHelp = v != null
                                 },
                                 {
                                     "c|connectionString=", "Connection string to SQLite database file.",
                                     v => ConnectionString = v 
                                 },
                                 {
                                     "sqlexportonly=", "Generate the SQL script file for adding or removing the specified features and do not carry out the actual operation.",
                                     v => SqlFileName = v 
                                 },
                                 {
                                     "q|quiet", "Quiet mode; do not display confirmation to remove a feature.",
                                     v => EnableQuietMode = v != null 
                                 }
                             };

            Extra = _optionSet.Parse(args);
        }

        public int Execute()
        {
            if (ShowHelp)
            {
                WriteHelpText(_isDotNetStyleHelp);
                return 0;
            }
            WriteHelpText(_isDotNetStyleHelp);
            return 0;
        }

        private void WriteHelpText(bool dotnetStyle)
        {
            if (dotnetStyle)
                Console.WriteLine(HelpText);
            else
            {
                _optionSet.WriteOptionDescriptions(Console.Out);
            }
        }

        public string HelpText
        {
            get
            {
                StringBuilder sb = new StringBuilder(1000);
                sb.AppendLine("Administrative utility to install and uninstall ASP.NET features on a SQLite");
                sb.AppendLine("database.");
                sb.AppendLine("Copyright (C) Prabir Shrestha (http://www.prabir.me) . All rights reserved.");
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine("\t\t\t   -- GENERAL OPTIONS --");
                sb.AppendLine();
                sb.AppendFormat("{0,-16} Display this help text.{1}", "-?", Environment.NewLine);
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendFormat("\t\t\t-- SQL CONNECTION OPTIONS --");
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine("-c <connection string>");
                sb.AppendFormat("{0,-16} Connection string to SQLite database file.{1}", string.Empty, Environment.NewLine);
                sb.AppendLine();
                sb.AppendLine("-sqlexportonly <filename>");
                sb.AppendFormat("{0,-16} Generate the SQL script file for adding or removing the{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-16} specified features and do not carry out the actual operation.{1}", string.Empty, Environment.NewLine);
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendFormat("\t\t    -- APPLICATION SERVICES OPTIONS --");
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendFormat("{0,-16} Add support for a feature. Multiple values can be specified{1}", "-A all|m|r|p|c|w", Environment.NewLine);
                sb.AppendFormat("{0,-16} together. For example:{1}", string.Empty, Environment.NewLine);
                sb.AppendLine();
                sb.AppendFormat("{0,-23} -A mp{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-23} -A m -A p{1}", string.Empty, Environment.NewLine);
                sb.AppendLine();
                sb.AppendFormat("{0,-16} all: All features{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-16} m: Membership{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-16} r: Role manager{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-16} p: Profiles{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-16} c: Personalization{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-16} w: SQLite Web event provider{1}", string.Empty, Environment.NewLine);
                sb.AppendLine();
                sb.AppendFormat("{0,-16} Remove support for a feature. Multiple values can be specified{1}", "-A all|m|r|p|c|w", Environment.NewLine);
                sb.AppendFormat("{0,-16} together. For example:{1}", string.Empty, Environment.NewLine);
                sb.AppendLine();
                sb.AppendFormat("{0,-23} -R mp{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-23} -R m -R p{1}", string.Empty, Environment.NewLine);
                sb.AppendLine();
                sb.AppendFormat("{0,-16} all: All features{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-16} m: Membership{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-16} r: Role manager{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-16} p: Profiles{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-16} c: Personalization{1}", string.Empty, Environment.NewLine);
                sb.AppendFormat("{0,-16} w: SQLite Web event provider{1}", string.Empty, Environment.NewLine);
                sb.AppendLine();
                sb.AppendFormat("{0,-16} Quiet mode; do not display confirmation to remove a feature.{1}", "-Q", Environment.NewLine);

                return sb.ToString();
            }
        }

    }
}
