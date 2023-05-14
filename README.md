<p align="center"><b>"Keep decompilers at bay, forever"</b></p>

<br>

A secure based .NET Obfuscator developed in C# made by loom (loomisntreal).

## Current Features

* String Encryption (encodes strings in the program)
* Online Decryption (decrypts the encrypted strings (string encryption must checked true for this to work) from the online method inside of the source-code)
* Control Flow (mangles with the methods inside of the code so decompilers cannot decompile the methods)
* Integer Confusion (this will add calculations inside of all integers)
* Math Calculations (this adds arithmetic inside of all constants)
* Constant Fields (converts all constants to fields with randomly selected names)
* Local Fields (converts all locals to fields with randomly selected names)
* Calli Conversion (converts all calls & calculations to calli calculations)
* Proxy Strings (hides string references that were referenced to a type, method, or field)
* Proxy Constants (hides constant references that were referenced to a type, method, or field)
* Proxy Methods (hides references that were referenced to a type, method, or field)
* Index Fields (indexes types/methods/fields)
* Flow Conversion (floods decompilers)
* Anti-Debug (prevents the assembly from being debugged or profiled)
* Anti-Dump (prevents the assembly from being dumped from memory)
* Anti-Tamper (ensures the integrity of the application)
* Anti-Decompile (prevents decompilers from working)
* Invalid Metadata (adds invalid metadata to modules to prevent disassemblers/decompilers from opening the application)
* Stack Conversion (adds a piece of code in front of all methods and converts them to a stack)
* Resource Conversion (converts all resources in the application to fields)

## FAQ

* Q: Is there a binary available? A: No, you have to build it yourself.
* Q: Will this project still be updated? A: Yes, if any decompilers are made for this obfuscator, minor & major bugs, or even a new feature, we will update this repository.
