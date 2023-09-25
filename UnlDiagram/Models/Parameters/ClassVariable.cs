using UnlDiagram.Models.Enums;

namespace UnlDiagram.Models.Parameters
{
    public class ClassVariable : Variable
    {
        public override string ToString()
        {
            var ret = "";

            if(!Simple)
                ret += base.GetAccessChar(); // opravit

            if (Type == VariablesTypes.Custom)
            {
                ret += $" {Name} : {Custom}";
            }
            else
            {
                ret += $" {Name} : {Type.ToString().Substring(1)}";
            }

            if (Simple) ret = ret.Substring(1); // opravit

            return ret;
        }

        public bool Simple = false; // opravit

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
