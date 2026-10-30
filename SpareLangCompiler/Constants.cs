namespace SpareLangCompiler
{
    internal interface IConstant<T> { public T Value { get; } }

    internal struct InputInt : IConstant<int> { public readonly int Value => int.Parse(Console.ReadLine() ?? "0"); }
    internal struct EndLine : IConstant<string> { public readonly string Value => "\n"; }
}