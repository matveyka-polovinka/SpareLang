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

List<Marker> markers = [];
for (int i = 0; i < code.Length; i++)
{
    string[] tokens = code[i].Split();

    if (tokens[0] == "marker")
    {
        Marker marker = new Marker(LineToListCode.ParseToObject(tokens[1]), i);
        if (!markers.Contains(marker)) markers.Add(marker);
    }
}
foreach (Marker marker in markers) Console.WriteLine(marker.ToString());

//
//          ИНТЕРПРЕТАЦИЯ КОДА
//

//...