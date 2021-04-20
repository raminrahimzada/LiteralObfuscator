using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace LiteralObfuscator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(R.MySalary);
            Console.WriteLine(R.AgeOfYildizTilbe);
            Console.WriteLine(R.SuperSecurePassword);

            var context=new ObfuscationContext();
            if (args.Length == 4)
            {
                context.ConfigFileLocation = args[0];
                context.OutputFileLocation = args[1];
                context.NameSpace = args[2];
                context.ClassName = args[3];
            }
            else
            {
                context.ConfigFileLocation = @"D:\PROJECTS\LiteralObfuscator\r.config.json";
                context.OutputFileLocation = @"D:\PROJECTS\LiteralObfuscator\R.cs";
                context.NameSpace = "LiteralObfuscator";
                context.ClassName = "R";
            }

            var obfuscator=new ByteConversionObfuscator(context);
            obfuscator.Obfuscate();
        }
    }
}
