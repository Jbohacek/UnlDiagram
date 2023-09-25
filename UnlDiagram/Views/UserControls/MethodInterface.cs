using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnlDiagram.Models;
using UnlDiagram.Models.Enums;
using UnlDiagram.Models.Parameters;

namespace UnlDiagram.Views.UserControls
{
    public partial class MethodInterface : UserControl
    {
        //Vytvořit bool na load, jinak se to přehazuje !

        private readonly MethodVariable _obj;

        public MethodInterface(MethodVariable obj)
        {
            _obj = obj;
            InitializeComponent();
            Element.FillAccessTypes(ref ComboAccess);
            Element.FillVariableTypes(ref ComboVariable);

            VariablesTypes classVarType = obj.Type;// opravit
            string custom = obj.Custom; // opravit

            foreach (var classVariable in _obj.Parameters)
            {
                var newInterface = new VariableInterface(classVariable);
                flowLayoutPanel1.Controls.Add(newInterface); // opravit
            }


            TextNameBox.Text = obj.Name;

            ComboAccess.Text = obj.Access.ToString().Substring(1); // Metoda

            if (classVarType == VariablesTypes.Custom)
            {
                ComboVariable.Text = custom;
            }
            else
            {
                ComboVariable.Text = classVarType.ToString().Substring(1); // Metoda
            }
        }

        private void TextChangedObj(object sender, EventArgs e)
        {
            _obj.Name = TextNameBox.Text;
            if (!string.IsNullOrWhiteSpace(ComboAccess.Text))
            {
                _obj.Access = (AccessModifiers)Enum.Parse(typeof(AccessModifiers), "_" + ComboAccess.Text, true); // Metoda
            }

            if (Enum.TryParse<VariablesTypes>("_" + ComboVariable.Text, out VariablesTypes a))
            {
                _obj.Type = (VariablesTypes)Enum.Parse(typeof(VariablesTypes), "_" + ComboVariable.Text, true); // Metoda
            }
            else
            {
                _obj.Type = VariablesTypes.Custom;
                _obj.Custom = ComboVariable.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e) // opravit
        {
            _obj.IsDeleted = true;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e) // opravit
        {
            var newItem = new ClassVariable() { Simple = true }; // opravit
            var newInterface = new VariableInterface(newItem, true); // opravit
            flowLayoutPanel1.Controls.Add(newInterface); // opravit
            _obj.Parameters.Add(newItem);
        }
    }
}
