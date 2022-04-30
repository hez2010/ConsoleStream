using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleStream;

public class ConsoleWriter
{
    private readonly TextWriter _target;
    private ConsoleWriter(TextWriter target) => _target = target;
    public readonly static ConsoleWriter cout = new(Console.Out);
    public readonly static ConsoleWriter cerr = new(Console.Error);
    public readonly static string endl = Environment.NewLine;
    private static ConsoleWriter Write<T>(ConsoleWriter output, T? value)
    {
        output._target.Write(value?.ToString());
        return output;
    }
    public static ConsoleWriter operator <<(ConsoleWriter output, sbyte value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, byte value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, short value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, ushort value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, int value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, uint value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, char value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, long value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, ulong value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, nint value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, nuint value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, string value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, DateOnly value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, TimeOnly value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, DateTime value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, DateTimeOffset value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, double value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, float value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, decimal value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, Half value) => Write(output, value);
    public static ConsoleWriter operator <<(ConsoleWriter output, object value) => Write(output, value);
}

public class ConsoleReader
{
    private readonly TextReader _source;
    private ConsoleReader(TextReader source) => _source = source;
    public readonly static ConsoleReader cin = new(Console.In);
    public static Span<T> To<T>(ref T value) => MemoryMarshal.CreateSpan(ref value, 1);
    private static ConsoleReader Read(ConsoleReader input, Span<string> target)
    {
        MemoryMarshal.GetReference(target) = ReadBlock(input._source);
        return input;
    }
    private static ConsoleReader Read<T>(ConsoleReader input, Span<T> target) where T : IParsable<T>
    {
        MemoryMarshal.GetReference(target) = T.Parse(ReadBlock(input._source), default);
        return input;
    }
    public static ConsoleReader operator >>(ConsoleReader input, Span<sbyte> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<byte> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<short> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<ushort> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<int> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<uint> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<char> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<long> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<ulong> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<nint> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<nuint> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<string> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<DateOnly> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<TimeOnly> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<DateTime> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<DateTimeOffset> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<double> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<float> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<decimal> target) => Read(input, target);
    public static ConsoleReader operator >>(ConsoleReader input, Span<Half> target) => Read(input, target);
    private static string ReadBlock(TextReader reader)
    {
        static bool IsBlank(int ch) => ch is '\n' or '\r' or '\t' or ' ' or '\0';
        var sb = new StringBuilder();
        var ch = 0;
        while (IsBlank(ch))
        {
            ch = reader.Read();
            if (ch == -1) return string.Empty;
        }
        do
        {
            sb.Append((char)ch);
            ch = reader.Read();
        } while (!IsBlank(ch) && ch != -1);
        return sb.ToString();
    }
}
