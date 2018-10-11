using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.TryCNOT
{
    class Driver
    {
        static void Main(string[] args)
        {
            Console.WriteLine("firstQbit\tsecondQbit\tdoHamamardOnFirst\tdoCnot\tfirstResult\tsecondResult");
            using (var sim = new QuantumSimulator())
            {
                (Result firstQbit, Result secondQbit, bool doHadamardOnFirst, bool doCnot) = (Result.Zero, Result.One,false,false);
                var (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}");

                (firstQbit, secondQbit,  doHadamardOnFirst,  doCnot) = (Result.Zero, Result.Zero, false, false);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.Zero, false, false);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.One, false, false);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.Zero, Result.Zero, false, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.Zero, false, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.Zero, Result.One, false, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}");

                (firstQbit, secondQbit, doHadamardOnFirst, doCnot) = (Result.One, Result.One, false, true);
                (firstResult, secondResult) = TryTheCNOT.Run(sim, firstQbit, secondQbit, doHadamardOnFirst, doCnot).Result;
                Console.WriteLine($"{firstQbit}\t{secondQbit}\t{doHadamardOnFirst}\t{doCnot}\t{firstResult}\t{secondResult}");
            }
            Console.ReadLine();
        }
    }
}