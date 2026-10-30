namespace SpareLangCompiler.ListCodeTypes
{
    internal struct ListCodeCommand
    {
        internal CommandType Command;
        internal object[] args;
    }
    internal enum CommandType
    {
        Marker,
        Goto,
        OulLine,
        Out,
        SetVariable,
        Wait,
    }
}