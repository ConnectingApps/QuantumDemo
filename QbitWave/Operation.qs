namespace Quantum.QbitWave
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;
	open Microsoft.Quantum.Extensions.Diagnostics;

    operation ShowWaveFunction () : ()
    {
        body
        {
            ShowDefaultQbit();
			ShowFlippedDefaultQbit();
			ShowSuperpositionQbit();
			ShowFlippedSuperpositionQbit();
        }
    }

	operation ShowDefaultQbit() : ()
	{
		body
		{
			using (register = Qubit[1])
			{
				DumpRegister("qDefault.txt",register[0..0]);
				let m = M(register[0]);
				DumpRegister("qdefaultAfterMeasurement.txt",register[0..0]);
				Reset(register[0]);
			}
		}
	}

	operation ShowFlippedDefaultQbit() : ()
	{
		body
		{
			using (register = Qubit[1])
			{
				X(register[0]);
				DumpRegister("qFlipped.txt",register[0..0]);
				let m = M(register[0]);
				DumpRegister("qFlippedAfterMeasurement.txt",register[0..0]);
				Reset(register[0]);
			}
		}
	}

	operation ShowSuperpositionQbit() : ()
	{
		body
		{
			using (register = Qubit[1])
			{
				H(register[0]);
				DumpRegister("qSuperposition.txt",register[0..0]);
				let m = M(register[0]);
				DumpRegister("qSuperPositionAfterMeasurement.txt",register[0..0]);
				Reset(register[0]);
			}
		}
	}

	operation ShowFlippedSuperpositionQbit() : ()
	{
		body
		{
			using (register = Qubit[1])
			{
				X(register[0]);
				H(register[0]);
				DumpRegister("qFlippedSuperposition.txt",register[0..0]);
				let m = M(register[0]);
				DumpRegister("qFlippedSuperPositionAfterMeasurement.txt",register[0..0]);
				Reset(register[0]);
			}
		}
	}



}
