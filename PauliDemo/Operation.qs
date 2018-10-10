namespace Quantum.PauliDemo
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;
	
	operation ExecuteXOperations (numberOfTimes : Int, initialValue : Result, duplicate : Bool) : Result
    {
        body
        {
			mutable resultValue = initialValue;
			using (register = Qubit[1])
			{
				SetValue(initialValue,register[0]);
				if (duplicate)
				{
					let duplicateAction = CreateDoubleExecution(X);
					DoSoManyTimes(numberOfTimes,register[0],duplicateAction);
				}
				else 
				{
					DoSoManyTimes(numberOfTimes,register[0],X);
				}				
				set resultValue = M(register[0]);
				Reset(register[0]);
			}
            return resultValue;
        }
    }

	operation ApplyOften(op : ((Qubit) => ()), numberOfTimes : Int,  target : Qubit) : () 
	{
		body 
		{
			for (i in 1..numberOfTimes)
			{
				op(target);
			}
		}
	}

	operation CreateDoubleExecution(op : ((Qubit) => ())) : ((Qubit) => ())
	{
		body
		{
			return ApplyOften(op,2,_);
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

	operation DoSoManyTimes(numberOfTimes : Int, target : Qubit, op : ((Qubit) => ())) : ()
	{
		body
		{	
			for (i in 1..numberOfTimes)
			{
				op(target);
			}	
		}
	}
}
