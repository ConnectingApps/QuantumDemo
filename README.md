# Introduction
A demonstration to explain quantum computing with Q# . This solution is intended to be used for training purposes.  If you want to compile this solution make, sure you install the [Quantum Development Kit](https://docs.microsoft.com/en-us/quantum/quantum-installconfig) first and try to compile [this solution](https://github.com/Microsoft/QuantumKatas/blob/master/README.md) before using this one. There are several projects to demo something which can be a language feature, a quantum operation or even both.

# Table of contents

  - [Introduction](#introduction)
  - [Run with docker](#run-with-docker)
  - [Projects](#projects)
    - [PauliOperator](#paulioperator)
    - [RandomGenerator](#randomgenerator-using-superposition)
    - [TryCNOT](#trycnot)
  - [How can I contribute?](#how-can-i-contribute)
  - [How can I learn?](#how-can-i-learn)

# Run with docker

The recommended way to work with this solution is compiling and running it in Visual Studio 2017 running on a Windows 10, which is how this solution was initially developed anyway. You can debug the quantum code and see what's happening. If you just want to see it running and do not want to install a quantum development kit on you local machine, you can use docker and cloning the solution. Each project has its own dockerfile. Here is an example how you can do that windows command prompt or bash on Linux. Make sure you have a recent version of docker and git installed. 

```bash
$ git clone https://github.com/ConnectingApps/QuantumDemo.git
cd QuantumDemo
cd PauliDemo
docker build -t randomgenerator .
docker run randomgenerator
```
**DO NOT FORGET THE DOT (.) SIGN IN THE BUILD COMMAND**

# Projects

## PauliOperator  ##

The PauliOperator project demonstrates a typical [Pauli operator](https://docs.microsoft.com/nl-nl/quantum/libraries/prelude?view=qsharp-preview#pauli-operators): the X operation. This can be used for several reasons. A typical problem with quantum computing is that there is no way to clone your data because. This problem is called the [No-cloning theorem](https://en.wikipedia.org/wiki/No-cloning_theorem). But some way or another we need to set a value. We do this by using a qbit, measure its value and if the measurement is different from expected switch it by rotating 180 degrees. Once it has been set, we can repeat this X operation. If the number of X operations is even (for example 2), the value has not changed. A 360 degree rotation does not change a position.

In Q#, we can even create a function for doing something two times and use functions as arguments (as typical in functional programming). This is also demonstrated. We do this by [partial application](https://docs.microsoft.com/nl-nl/quantum/quantum-techniques-2-operationsandfunctions?view=qsharp-preview#partially-applying-operations-and-functions). The [bound variables](https://en.wikipedia.org/wiki/Free_variables_and_bound_variables) are given in the call. The free variables are replaced by an underscore.

The output shows that the difference between even and odd number of X operations is as expected. If the created method does a duplicate X operation, the value is always the same.

## RandomGenerator using superposition ##

The RandomGenerator project demonstrates a random generator. A number of booleans is created. Based on this number of booleans, we can create an integer. Each boolean can be considerd as a bit. With a combination of bits, we can describe and calculate and integer. Similar to [this](https://en.wikipedia.org/wiki/Binary_number#Leibniz_and_the_I_Ching). This is really old mathematics and classical logic. We also need a way to randomize. Therefore, each boolean (to be considered as a bit) needs to have a random value. We do this by putting a qbit in a [superposition state](https://en.wikipedia.org/wiki/Quantum_superposition) using [Hadamard gate operation](https://en.wikipedia.org/wiki/Hadamard_transform#Hadamard_gate_operations); check the code and look for the [H call](https://github.com/ConnectingApps/QuantumDemo/blob/master/RandomGenerator/Operation.qs#L56). When measuring the qbit, we cannot predict the value. It is random. In traditional computing, random generators try to be as random as possible. Quantum computers use fundamental (laws of) physics to generate random numbers. Nature has random behavior [by itself](https://www.nist.gov/news-events/news/2018/04/nists-new-quantum-method-generates-really-random-numbers). So this is a real random generator. 

## TryCNOT ##

The [CNOT](https://docs.microsoft.com/nl-nl/qsharp/api/prelude/microsoft.quantum.primitive.cnot?view=qsharp-preview) is a multiqbit operator and is described nicely [on wikipedia](https://en.wikipedia.org/wiki/Controlled_NOT_gate). Two qbits are needed. The first one is a control qbit. Let's say this is input data. The second qbit is a target qbit. Let's say this is ouput data. If the value is |0> of |1> (if you're not familiar with this notation, read about [Dirac notation](https://en.wikipedia.org/wiki/Bra–ket_notation) or [this](https://docs.microsoft.com/nl-nl/quantum/quantum-concepts-6-diracnotation?view=qsharp-preview)) then we can predict the output qbit. In short, nothing happens to the source qbit. The target qbit is changed if it is |0> and the source qbit is |1>. The CNOT operator can be used for logic problems: change somehing one under a certain condition. When applying a Hadamard gate operation (check the Random generator to see what this is), the behaviour is [different](https://en.wikipedia.org/wiki/Controlled_NOT_gate#Behaviour_in_the_Hadamard_transformed_basis). The following results become clear when you run this program:

- When not applying Hadamard and CNOT, the input qbits and output qbits (well,the measured values) are the same 
- When not applying Hadamard and CNOT, the wave functions of the qbits have simple 0 or 1 values
- When not applying CNOT, but only Hadamard, we see random behaviour of the measurement because of different wave function and thus different probabilities
- When only using CNOT the target qbit can change because of having a different value then the source qbit. 
- When using both, we cannot read the wave function because of [entanglement](https://en.wikipedia.org/wiki/Quantum_entanglement). This creates a special bond between two qbits so their values are not independant.

# How can I contribute? #
If you are familiar with quantum computing, have a look at the [quantum operators](https://docs.microsoft.com/en-us/qsharp/api/prelude/microsoft.quantum.primitive?view=qsharp-preview) available in Q#. Show something we have not shown yet. For example, create a that shows how the Z operator works. Keep in mind that this solution has been created to demonstrate how features and operators in Q# work, not to make a brilliant math model. It is a training solution. Contributions can be done via [pull requests](https://help.github.com/articles/creating-a-pull-request/).

# How can I learn? #
Just have a look at one of the projects and try to understand the input and output when running. Once it is clear, you understand the operators used in the project. If it is not clear, create an [issue](https://github.com/ConnectingApps/QuantumDemo/issues).



