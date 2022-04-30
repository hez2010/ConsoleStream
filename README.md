# Console Stream for .NET 7 with C# 11

## Usage

```csharp
using static ConsoleStream.ConsoleWriter;
using static ConsoleStream.ConsoleReader;

int a = 0, b = 0;
_ = cin >> To(ref a) >> To(ref b);
_ = cout << "hello " << "world, " << a << " + " << b << " = " << a + b << "!" << endl;
```
