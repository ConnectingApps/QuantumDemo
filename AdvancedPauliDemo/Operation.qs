namespace Quantum.AdvancedPauliDemo
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;
	open Microsoft.Quantum.Extensions.Diagnostics;

    operation ShowPauli () : ()
    {
        body
        {
			Xyzh();
            Hxyz();
			Xhyz();
			Zyxh();
			Yxhz();
			Hxxyyzz();
        }
    }

	operation Xyzh () : ()
	{
		body
		{
			using (register = Qubit[1])
			{
				DumpRegister("Default.txt",register[0..0]);
				X(register[0]);
				DumpRegister("X.txt",register[0..0]);
				Y(register[0]);
				DumpRegister("XY.txt",register[0..0]);
				Z(register[0]);
				DumpRegister("XYZ.txt",register[0..0]);
				H(register[0]);
				DumpRegister("XYZH.txt",register[0..0]);
				Reset(register[0]);
			}
		}
	}
	
	operation Hxyz () : ()
	{
		body
		{
			using (register = Qubit[1])
			{
				H(register[0]);
				DumpRegister("H.txt",register[0..0]);
				X(register[0]);
				DumpRegister("HX.txt",register[0..0]);
				Y(register[0]);
				DumpRegister("HXY.txt",register[0..0]);
				Z(register[0]);
				DumpRegister("HXYZ.txt",register[0..0]);
				Reset(register[0]);
			}
		}
	}

	operation Xhyz () : ()
	{
		body
		{
			using (register = Qubit[1])
			{
				X(register[0]);
				H(register[0]);
				DumpRegister("XH.txt",register[0..0]);
				Y(register[0]);
				DumpRegister("XHY.txt",register[0..0]);
				Z(register[0]);
				DumpRegister("XHYZ.txt",register[0..0]);
				Reset(register[0]);
			}
		}
	}

	operation Zyxh () : ()
	{
		body
		{
			using (register = Qubit[1])
			{
				Z(register[0]);
				DumpRegister("Z.txt",register[0..0]);
				Y(register[0]);
				DumpRegister("ZY.txt",register[0..0]);
				X(register[0]);
				DumpRegister("ZYX.txt",register[0..0]);
				H(register[0]);
				DumpRegister("ZYXH.txt",register[0..0]);
				Reset(register[0]);
			}
		}
	}

	operation Yxhz () : ()
	{
		body
		{
			using (register = Qubit[1])
			{
				Y(register[0]);
				DumpRegister("Y.txt",register[0..0]);
				X(register[0]);
				DumpRegister("YX.txt",register[0..0]);
				H(register[0]);
				DumpRegister("YXH.txt",register[0..0]);
				Z(register[0]);
				DumpRegister("YXHZ.txt",register[0..0]);
				Reset(register[0]);
			}
		}
	}

	operation Hxxyyzz () : ()
	{
		body
		{
			using (register = Qubit[1])
			{
				H(register[0]);
				X(register[0]);
				X(register[0]);
				DumpRegister("HXX.txt",register[0..0]);
				Y(register[0]);
				Y(register[0]);
				DumpRegister("HXXYY.txt",register[0..0]);
				Z(register[0]);
				Z(register[0]);
				DumpRegister("HXXYYZZ.txt",register[0..0]);
				Reset(register[0]);
			}
		}
	}
}
