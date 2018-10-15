using System;
using System.IO;
using System.Reflection;
using Microsoft.Quantum.Simulation.Simulators;
using System.Linq;

namespace Quantum.AdvancedPauliDemo
{
    internal class Driver
    {
        private static void Main(string[] args)
        {
            using (var sim = new QuantumSimulator())
            {
                var res = ShowPauli.Run(sim).Result;
                var currentDirectoryName = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                var files = Directory.EnumerateFiles(currentDirectoryName, "*.txt");
                var toShow = (from file in files.OrderBy(a => a)
                    select new
                    {
                        Operations = file.Split('/','\\').Last().Split(".").First(),
                        WaveFunction = File.ReadAllText(file)
                    }).ToList();
                foreach (var show in toShow)
                {
                    Console.WriteLine(show.Operations);
                    Console.WriteLine(show.WaveFunction);
                }
            }
            Console.ReadLine();
        }
    }
}