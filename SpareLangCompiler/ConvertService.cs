namespace SpareLangCompiler
{
    internal static class ConvertService
    {
        internal static RuntimeMemory Memory { set; private get; } = new();
        internal static object ParseToObject(string ob)
        {
            if (int.TryParse(ob, out var rint)) return rint;

            if (bool.TryParse(ob, out var rbool)) return rbool;

            if (ob[0] == ob[ob.Length - 1] && ob[0] == '"')
            {
                List<char> chars = ob.ToList();
                chars.RemoveAt(0);
                chars.RemoveAt(chars.Count - 1);
                return chars.ToArray().ToString() ?? "";
            }

            if (ob[0] == '[' && ob[ob.Length - 1] == ']')
            {
                List<char> chars = ob.ToList();
                chars.RemoveAt(0);
                chars.RemoveAt(chars.Count - 1);
                int index = int.Parse(chars.ToArray().ToString() ?? "0");
                return Memory[index];
            }

            throw new Exception();
        }
    }
}