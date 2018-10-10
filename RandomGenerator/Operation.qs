namespace Quantum.RandomGenerator
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

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

	operation GenerateRandomMultiBool(numberofBools : Int) : Bool[]
	{
		body
		{
			mutable result = new Bool[numberofBools];
			for (i in 1..numberofBools)
			{
				set result[i-1] = GenerateRandomBool();
			}
			return result;
		}
	}

	function BoolsToInt(numberofBools : Int, bools : Bool[]) : Int
	{
		mutable multiplier = 1;
		mutable result = 0;
		for (i in 1..numberofBools)
		{
			if (bools[i-1])
			{
				set result = result + multiplier;
			}
			set multiplier = multiplier * 2;
		}
		return result;
	}


    operation GenerateRandomBool () : Bool
    {
        body
        {
			mutable res = false;
            using (register = Qubit[1])
			{
				SetValue(Zero,register[0]);
				H(register[0]);
				let measurement = M(register[0]);
				if (measurement == Zero)
				{
					set res = false;
				}
				else
				{
					set res = true;
				}
				Reset(register[0]);
			}
			return res;
        }
    }

	operation GenerateRandomInt(numberofBits : Int) : Int
	{
		body
		{
			let allBools = GenerateRandomMultiBool(numberofBits);
			let result = BoolsToInt(numberofBits,allBools);
			return result;
		}
	}
}
