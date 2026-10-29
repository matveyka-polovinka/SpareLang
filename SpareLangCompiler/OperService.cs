namespace SpareLangCompiler
{
    internal static class OperService
    {
        internal static object Add(object a, object b)
        {
            if (a is int && b is int) return (int)a + (int)b;

            if(a is string || b is string) return a.ToString() + b.ToString();

            if (a is bool && b is bool) return (bool)a && (bool)b;
        }
    }
}
