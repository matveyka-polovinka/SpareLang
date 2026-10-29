namespace SpareLangCompiler
{
    internal class RuntimeMemory
    {
        private List<Variable> variables = [];
        internal Variable this[int index]
        {
            get
            {
                CheckByIndex(index);
                return variables[index];
            }
            set
            {
                CheckByIndex(index);
                variables[index] = value;
            }
        }
        private void CheckByIndex(int index)
        {
            if(!variables.Any(v => v.ID == index)) 
                variables.Add(new Variable(index, 0));
        }
    }
}