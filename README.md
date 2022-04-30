# Console Stream for .NET 7 with C# 11

[![nuget](https://img.shields.io/nuget/vpre/Skyake.ConsoleStream.svg)](https://www.nuget.org/packages/Skyake.ConsoleStream)

## Usage

```csharp
using static ConsoleStream.ConsoleWriter;
using static ConsoleStream.ConsoleReader;

int a = 0, b = 0;
_ = cin >> To(ref a) >> To(ref b);
_ = cout << "hello " << "world, " << a << " + " << b << " = " << a + b << "!" << endl;
```
