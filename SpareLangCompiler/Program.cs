using SpareLangCompiler;

string sourceCode =
    """
    [0] = inl
    marker 67
    outl [0]
    goto 67 : [0] == 67
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

int i = 0;

while(i < code.Length)
{
    string[] tokens = code[i].Split();

    switch (tokens[0])
    {
        case "marker": break;
        case "out": Console.Write(ConvertService.ParseToObject(tokens[1])); break;
        case "outl": Console.WriteLine(ConvertService.ParseToObject(tokens[1])); break;
    }

    i++;
}