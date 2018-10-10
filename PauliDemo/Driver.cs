using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.PauliDemo
{
    class Driver
    {
        static void Main(string[] args)
        {
            Result[] inputs = { Result.Zero, Result.One };

            using (var sim = new QuantumSimulator())
            {
                Console.WriteLine("First use single X operations");
                Console.WriteLine("-----------------------------");
                foreach (var input in inputs)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        var result = ExecuteXOperations.Run(sim, i, input, false).Result;
                        Console.WriteLine($"Number of X operations is {i}. The input is {input}. The output is {result}");
                    }
                }
                Console.WriteLine("Now use double X operations");
                Console.WriteLine("-----------------------------");
                foreach (var input in inputs)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        var result = ExecuteXOperations.Run(sim, i, input, true).Result;
                        Console.WriteLine($"Number of double X operations is {i}. The input is {input}. The output is {result}");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}