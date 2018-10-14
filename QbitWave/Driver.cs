using System;
using System.IO;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.QbitWave
{
    internal class Driver
    {
        private static void PresentWaveFunction(string name)
        {
            Console.WriteLine(name);
            var content = File.ReadAllText($"{name}.txt");
            Console.Write(content);
            Console.WriteLine(string.Empty);
        }

        private static void Main(string[] args)
        {
            using (var sim = new QuantumSimulator())
            {
                var doe = ShowWaveFunction.Run(sim).Result;
                PresentWaveFunction("qDefault");
                PresentWaveFunction("qdefaultAfterMeasurement");
                PresentWaveFunction("qFlipped");
                PresentWaveFunction("qFlippedAfterMeasurement");
                PresentWaveFunction("qSuperposition");
                PresentWaveFunction("qSuperPositionAfterMeasurement");
                PresentWaveFunction("qFlippedSuperposition");
                PresentWaveFunction("qFlippedSuperPositionAfterMeasurement");
            }
            Console.ReadLine();
        }
    }
}