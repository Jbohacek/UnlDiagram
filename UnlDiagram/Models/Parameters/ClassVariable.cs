using UnlDiagram.Models.Enums;

namespace UnlDiagram.Models.Parameters
{
    public class ClassVariable : Variable
    {
        public override string ToString()
        {
            var ret = "";

            ret += base.GetAccessChar();

            if (Custom != null)
            {
                ret += $" {Name} : {Custom}";
            }
            else
            {
                ret += $" {Name} : {Type.ToString().Substring(1)}";
            }
            return ret;
        }


        public ClassVariable(string name, VariablesTypes variable, AccessModifiers access) : base(name, variable, access)
        {
        }

        public ClassVariable(string name, string customVariable, AccessModifiers access) : base(name, customVariable, access)
        {
        }
        

        public ClassVariable() : base()
        {
            
        }
    }




}
