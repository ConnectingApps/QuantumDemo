# QuantumDemo
A demonstration to explain quantum computing with Q# . This solution is intended to be used for training purposes.  If you want to compile this solution make, sure you install the [Quantum Development Kit](https://docs.microsoft.com/en-us/quantum/quantum-installconfig) first and try to compile [this solution](https://github.com/Microsoft/QuantumKatas/blob/master/README.md) before using this one. There are several projects to demo something which can be a language feature, a quantum operation or even both. 

## PauliOperator  ##

The PauliOperator project demonstrates a typical [Pauli operator](https://docs.microsoft.com/nl-nl/quantum/libraries/prelude?view=qsharp-preview#pauli-operators): the X operation. This can be used for several reasons. A typical problem with quantum computing is that there is no way to clone your data because. This problem is called the [No-cloning theorem](https://en.wikipedia.org/wiki/No-cloning_theorem). But some way or another we need to set a value. We do this by using a qbit, measure its value and if the measurement is different from expected switch it by rotating 180 degrees. Once it has been set, we can repeat this X operation. If the number of X operations is even (for example 2), the value has not changed. A 360 degree rotation does not change a position.

In Q#, we can even create a function for doing something two times and use functions as arguments (as typical in functional programming). This is also demonstrated. We do this by [partial application](https://docs.microsoft.com/nl-nl/quantum/quantum-techniques-2-operationsandfunctions?view=qsharp-preview#partially-applying-operations-and-functions). The (bound variables)[https://en.wikipedia.org/wiki/Free_variables_and_bound_variables] are given in the call. The free variables are replaced by an underscore.

The output shows that the difference between even and odd number of X operations is as expected. If the created method does a duplicate X operation, the value is always the same.


