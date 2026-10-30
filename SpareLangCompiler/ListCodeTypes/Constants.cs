namespace SpareLangCompiler.ListCodeTypes
{
    internal struct InputInt : IValue<int> { public readonly int Value => int.Parse(Console.ReadLine() ?? "0"); }
    internal struct EndLine : IValue<string> { public readonly string Value => "\n"; }
}