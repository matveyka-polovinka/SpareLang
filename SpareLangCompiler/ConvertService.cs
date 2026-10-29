internal static class ConvertService
{
    internal static object ParseToObject(string ob)
    {
        if (int.TryParse(ob, out var rint)) return rint;

        if (bool.TryParse(ob, out var rbool)) return rbool;

        if (ob[0] == ob[ob.Length - 1] && ob[0] == '"')
        {
            List<char> chars = ob.ToList();
            chars.RemoveAt(0);
            chars.RemoveAt(chars.Count - 1);
            return chars.ToArray().ToString()??"";
        }

        throw new Exception();
    }
}