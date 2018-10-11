using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.TryCNOT
{
    class Driver
    {
        static string CreateRelevantLine(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var relevantLines = (from line in lines
                where line.Length > 2 && !line.StartsWith("Ids") && !line.StartsWith("Wavefunction")
                select line.Replace('\t',' ')).ToList();
            string result = $"[{string.Join(";",relevantLines)}]";
            return result;
        }

        static string ReadWaveFunctions()
        {
            string[] allFileName = { "q0initial.txt", "q1initial.txt","q0after.txt", "q1after.txt" };
            (string fileName, string Description)[] fileNamesWithDescription = new (string fileName, string Description)[]
            {
                ("q0initial.txt","Initial WaveFunction1"),
                ("q1initial.txt","Initial WaveFunction2"),
                ("q0after.txt",  "Final WaveFunction1  "),
                ("q1after.txt",  "Final WaveFunction2  "),
            };

            var relevantLines = fileNamesWithDescription.Select(a => a.Description + ":" + CreateRelevantLine(a.fileName)).ToList();
            var joinedLines = string.Join("\n", relevantLines);
            return joinedLines;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("firstQbit\tsecondQbit\tdoHamamardOnFirst\tdoCnot\tfirstResult\tsecondResult");
            Console.WriteLine(string.Empty);
            using (var sim = new QuantumSimulator())
            {
                (Result firstQbit, Result secondQbit, bool doHadamardOnFirst, bool doCnot) = (Result.Zero, Result.One,false,false);
                var (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                var extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit,  doHadamardOnFirst,  doCnot) = (Result.Zero, Result.Zero, false, false);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.Zero, false, false);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.One, false, false);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                Console.ForegroundColor = ConsoleColor.Blue;

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.Zero, Result.Zero, false, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.Zero, false, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.Zero, Result.One, false, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.One, false, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                Console.ForegroundColor = ConsoleColor.Red;

                (firstQbit,  secondQbit,  doHadamardOnFirst,  doCnot) = (Result.Zero, Result.One, true, false);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.Zero, Result.Zero, true, false);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.Zero, true, false);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.One, true, false);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                Console.ForegroundColor = ConsoleColor.Green;

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.Zero, Result.One, true, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.Zero, Result.Zero, true, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.Zero, true, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.One, true, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                extraLine = ReadWaveFunctions();
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}\n{extraLine}");
            }
            Console.ReadLine();
        }
    }
}