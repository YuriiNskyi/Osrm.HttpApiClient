using System;
using BenchmarkDotNet.Running;

namespace Osrm.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            }

            Console.WriteLine("Arguments were not specified. Running all benchmarks inside assembly.");

            BenchmarkRunner.Run<BuildersBenchmarks>();
        }
    }
}
