namespace SpareLangCompiler.ListCodeTypes
{
    internal interface IValue<T> { public T Value { get;} }
    internal struct SetOperValue : IValue<object>
    { 
        public SetOper Operation { private get; init; }
        public IValue<object> ArgLeft { private get; set; }
        public IValue<object> ArgRight { private get; set; }

        public readonly object Value => Operation(ArgLeft, ArgRight);
    }
    delegate object SetOper(object a, object b);
    delegate bool CompareOper(object a, object b);
    delegate bool VariantOper(bool[] compares);
}