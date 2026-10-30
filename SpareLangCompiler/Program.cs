using SpareLangCompiler;

string sourceCode =
    """
    [0] = 5 + 2
    [1] = [0] + 4
    [2] = [1] / 3
    outl [2]
    """;

string[] code = sourceCode.Trim('\t').Trim(' ').Split('\n');

//
//          КОМПИЛЯЦИЯ МАРКЕРОВ
//

List<Marker> markers = MarkerCompiler.GetMarkers(code);

foreach (Marker marker in markers) Console.WriteLine(marker.ToString());

//
//          ИНТЕРПРЕТАЦИЯ КОДА
//

RuntimeMemory memory = new();
ParseService.Memory = memory;

int i = 0;

while (i < code.Length)
{
    string[] tokens = code[i].Split(' ');

    switch (tokens[0])
    {
        case "marker": break;

        case "out": Console.Write(ParseService.ParseToObject(tokens[1])); break;
        case "outl": Console.WriteLine(ParseService.ParseToObject(tokens[1])); break;

        case "goto": i = markers.Where(m => 1 == 1).ToList()[0].Position + 1; break;

        default:
            var t = tokens[0];

            if (t[0] == '[' && t[^1] == ']')
            {
                int index = (int)ParseService.ParseToObject(t);

                Variable v = memory[index];

                v.Value = tokens.Length == 5 ?
                    ParseService.ParseSetVar(tokens)
                    :
                    ParseService.ParseToObject(tokens[2]);

                memory[index] = v;
            }

            break;
    }

    i++;
}