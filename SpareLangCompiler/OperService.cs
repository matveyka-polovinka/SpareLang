namespace SpareLangCompiler
{
    internal static class OperService
    {
        internal static object Add(object a, object b)
        {
            if (a is int && b is int) return (int)a + (int)b;

            if (a is string || b is string) return a.ToString() + b.ToString();

            if (a is bool && b is bool) return (bool)a && (bool)b;

            throw new Invalid_Combination_Exception();
        }
        internal static object Substract(object a, object b)
        {
            if (a is int && b is int) return (int)a - (int)b;

            throw new Invalid_Combination_Exception();
        }

        internal static object Multiply(object a, object b)
        {
            if (a is int && b is int) return (int)a * (int)b;

            if (a is string && b is int) 
            {
                string result = "";
                for (int i = 0; i < (int)b; i++) result += a;
                return result;
            }
            
            if(a is bool && b is bool) return (bool)a == (bool)b;

            throw new Invalid_Combination_Exception();
        }
        internal static object Divide(object a, object b)
        {
            if (a is int && b is int) return (int)a / (int)b;

            throw new Invalid_Combination_Exception();
        }

        internal static object IntegerDivide(object a, object b)
        {
            if (a is int c && b is int d) return (c - c % d) / d;

            throw new Invalid_Combination_Exception();
        }
        internal static object DivideRemain(object a, object b)
        {
            if (a is int && b is int) return (int)a % (int)b;

            throw new Invalid_Combination_Exception();
        }
    }
}
