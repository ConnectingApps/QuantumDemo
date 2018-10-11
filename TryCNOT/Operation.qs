namespace Quantum.TryCNOT
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

    operation TryTheCNOT (firstValue : Result, secondValue : Result, doHadamardOnFirst : Bool, doCNOT : Bool) : (Result,Result)
    {
        body
        {
			mutable firstResult = Zero;
			mutable secondResult = Zero;
			using (register = Qubit[2])
			{
				SetValue(firstValue,register[0]);
				SetValue(secondValue,register[1]);
				if (doHadamardOnFirst)
				{
					H(register[0]);				
				}
				if (doCNOT)
				{
					CNOT(register[0],register[1]);
				}
				set firstResult = M(register[0]);
				set secondResult = M(register[1]);
				Reset(register[0]);
				Reset(register[1]);
			}		
            return (firstResult,secondResult);
        }
    }

	operation SetValue (desired: Result, q1: Qubit) : ()
    {
        body
        {
		    let current = M(q1);

            if (desired != current)
            {
                X(q1);
            }        
        }
	}
}
