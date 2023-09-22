using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnlDiagram.Models.Enums;

namespace UnlDiagram.Models.Parameters
{
    public class MethodVariable : Variable
    {

        public List<Variable> Parameters = new List<Variable>();

        public override string ToString()
        {
            var ret = "";

            ret += base.GetAccessChar();

            if (Custom != null)
            {
                ret += $" {Name} ({string.Join(", ",Parameters)}) : {Custom}";
            }
            else
            {
                ret += $" {Name} ({string.Join(", ", Parameters)}) : {Type.ToString().Substring(1)}";
            }
            return ret;
        }

        public MethodVariable(string name, VariablesTypes variable, AccessModifiers access) : base(name, variable, access)
        {
        }

        public MethodVariable(string name, string customVariable, AccessModifiers access) : base(name, customVariable, access)
        {
        }

        public MethodVariable()
        {
            
        }
    }
}
