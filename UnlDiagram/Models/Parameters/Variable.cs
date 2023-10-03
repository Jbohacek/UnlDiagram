using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnlDiagram.Models.Enums;

namespace UnlDiagram.Models.Parameters
{
    public class Variable
    {
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; }
        public VariablesTypes Type { get; set; }
        public string? Custom { get; set; }

        public AccessModifiers Access { get; set; }

        public Variable(string name, VariablesTypes variable, AccessModifiers access)
        {
            Name = name;
            Type = variable;
            Access = access;
        }

        public Variable(string name, string customVariable, AccessModifiers access)
        {
            Name = name;
            Type = VariablesTypes.Custom;
            Custom = customVariable;
            Access = access;
        }

        public Variable(string name, VariablesTypes variable)
        {
            Name = name;
            Type = variable;
            Access = AccessModifiers._public;
        }

        public Variable(string name, string customVariable)
        {
            Name = name;
            Type = VariablesTypes.Custom;
            Custom = customVariable;
            Access = AccessModifiers._public;
        }


        protected Variable()
        {
            Name = "New";
            Type = VariablesTypes.Custom;
            Custom = null;
            Access = AccessModifiers._public;
        }

        public override string ToString()
        {
            if (Type == VariablesTypes.Custom)
            {
                return $"{Name} : {Custom}";
            }
            return $"{Name} : {Type.ToString()}";
        }

        public string GetAccessChar()
        {
            switch (Access)
            {
                case AccessModifiers._public:
                    return "+ ";
                    break;
                case AccessModifiers._private:
                    return "- ";
                    break;
                case AccessModifiers._protected:
                    return "# ";
                    break;
                case AccessModifiers._internal:
                    return "~ ";
                    break;
                case AccessModifiers._protectedInternal:
                    return "#~";
                    break;
                case AccessModifiers._privateProtected:
                    return "-#";
                    break;
                default:
                    return "? ";
                    break;
            }
        }

        public string GetAccess()
        {
            return this.Access.ToString().Substring(1);
        }

        public new string? GetType()
        {
            return this.Type == VariablesTypes.Custom ? Custom : this.Type.ToString().Substring(1);
        }
    }
}
