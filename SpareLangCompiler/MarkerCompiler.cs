namespace SpareLangCompiler
{
    internal static class MarkerCompiler
    {
        internal static List<Marker> GetMarkers(string[] code)
        {
            List<Marker> markers = [];
            for (int i = 0; i < code.Length; i++)
            {
                string[] tokens = code[i].Split();

                if (tokens[0] == "marker")
                {
                    Marker marker = new Marker(ParseService.ParseToObject(tokens, 1), i);
                    if (!markers.Contains(marker)) markers.Add(marker);
                }
            }
            return markers;
        }
    }
}