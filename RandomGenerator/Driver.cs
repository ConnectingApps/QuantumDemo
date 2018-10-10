using System;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.RandomGenerator
{
    internal class Driver
    {
        private static void Main(string[] args)
        {
            using (var sim = new QuantumSimulator())
            {
                Console.WriteLine("Random values based on 8 bits ");
                for (var i = 0; i < 10; i++)
                {
                    var result = GenerateRandomInt.Run(sim, 8).Result;
                    Console.Write($" {result} ");
                }

                Console.WriteLine(string.Empty);
                Console.WriteLine("Random values based on 16 bits ");
                for (var i = 0; i < 10; i++)
                {
                    var result = GenerateRandomInt.Run(sim, 16).Result;
                    Console.Write($" {result} ");
                }
            }
            Console.ReadLine();
        }
    }
}