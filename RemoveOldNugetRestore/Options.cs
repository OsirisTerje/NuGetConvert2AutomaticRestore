﻿using System.Reflection;
using System.Text;
using CommandLine;

namespace IFix
{


    public abstract class CommonOptions
    {
        [Option('c', "check", HelpText = "Only check if we have an issue. No changes done")]
        public bool Check { get; set; }


        [Option('f', "fix", HelpText = "Fix all files with issues")]
        public bool Fix { get; set; }

        [Option('v', "verbose", HelpText = "More verbose output")]
        public bool Verbose { get; set; }

        [HelpOption]
        public string Help()
        {
            var usage = new StringBuilder();
            usage.AppendLine(
                "Use :  -c or --check to only check without fixing, or -f or --fix to check and fix the errors");
            usage.AppendLine(
                "Use option -v or --verbose in addition to get more information.  Default for this is false.");
            return usage.ToString();
        }
    }

    public class Options
    {
       

        [VerbOption("NuGetRestore")]
        public NuGetRestoreOptions NuGetRestore { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var usage = new StringBuilder();
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            usage.AppendLine("IFix  "+version);
            usage.AppendLine("IFix: Fixes common solution and project file issues");
            usage.AppendLine("Verbs:  NuGetRestore: Converts all projects in a directory tree to remove old nuget restore, by removing nuget.target and exe files and converts all csproj and sln files.");
            usage.AppendLine("Usage: IFix  NuGetRestore [-c](Check only) [-f](Fix)  [-v](Verbose mode");
            usage.AppendLine("For more instructions and information see blogpost at http://geekswithblogs.net/Terje");
            usage.AppendLine("by Terje Sandstrom, Inmeta Consulting, 2014");
            
            return usage.ToString();
        }
    }

    public class NuGetRestoreOptions : CommonOptions
    {
    }
}
