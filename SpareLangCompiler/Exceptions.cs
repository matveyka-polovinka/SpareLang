namespace SpareLangCompiler
{
    internal class Invalid_Combination_Exception : Exception { }
    internal class Invalid_Type_Exception(string message) : Exception(message) { }
    internal class Invalid_Operation_Exception : Exception { }
}