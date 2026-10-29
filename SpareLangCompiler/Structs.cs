internal struct Variable(int id, object v)
{
    internal int ID = id;
    internal object Value = v;
}
internal struct Marker(object t, int p)
{
    internal object Tag = t;
    internal int Position = p;

    public override string ToString() =>
        $"Tag: {Tag}; Tag type: {Tag.GetType().Name}; Position: {Position}.";
}