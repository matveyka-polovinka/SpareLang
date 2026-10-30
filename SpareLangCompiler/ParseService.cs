using System.Globalization;

namespace SpareLangCompiler
{
    internal static class ParseService
    {
        internal static RuntimeMemory Memory { set; private get; } = new();
        internal static object ParseToObject(string[] tokens, int startindex)
        {
            string ob = tokens[startindex];

            if (int.TryParse(ob, out var rint)) return rint;

            if (bool.TryParse(ob, out var rbool)) return rbool;

            if (ob[0] == '\"')
            {
                string rstr = ob;
                rstr.TrimStart('\"');

                if (tokens.Length == startindex + 1) return rstr.TrimEnd('\"');

                for (int i = startindex+1; i < tokens.Length; i++)
                {
                    rstr += " " + tokens[i];
                    if (tokens[i].EndsWith('\"')) rstr.TrimEnd('\"');
                }

                return rstr;
            }

            if (ob[0] == '[' && ob[^1] == ']')
            {
                List<char> chars = ob.ToList();
                chars.RemoveAt(0);
                chars.RemoveAt(chars.Count - 1);
                int index = int.Parse(ob[1..^1].Trim(), CultureInfo.InvariantCulture);
                return Memory[index].Value;
            }

            throw new Invalid_Type_Exception(ob);
        }

        private static readonly Dictionary<string, Oper> TokenToOper = new()
        {
            {"+", OperService.Add},
            {"-", OperService.Substract},
            {"*", OperService.Multiply},
            {"/", OperService.Divide},
            {"//", OperService.IntegerDivide},
            {"%", OperService.DivideRemain},
        };
        internal static object ParseSetVar(string[] tokens)
        {
            if (TokenToOper.TryGetValue(tokens[3], out var f))
                return f
                (
                    ParseToObject(tokens, 2),
                    ParseToObject(tokens, 4)
                );

            throw new Invalid_Operation_Exception();
        }
    }
    delegate object Oper(object a, object b);
}