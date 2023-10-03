using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnlDiagram.Essentials;
using UnlDiagram.Models;
using UnlDiagram.Models.Enums;
using UnlDiagram.Models.Parameters;

namespace UnlDiagram.Views.UserControls
{
    public partial class MethodInterface : UserControl
    {

        private readonly MethodVariable _obj;
        private readonly bool _isActive = false;

        public MethodInterface(MethodVariable obj)
        {
            _obj = obj;
            InitializeComponent();
            Helper.FillAccessTypes(ref ComboAccess);
            Helper.FillVariableTypes(ref ComboVariable);

            foreach (var classVariable in _obj.Parameters)
            {
                var newInterface = new VariableInterface(classVariable,true);
                VariablePanel.Controls.Add(newInterface); 
            }


            TextNameBox.Text = obj.Name;
            ComboAccess.Text = _obj.GetAccess();
            ComboVariable.Text = _obj.GetType();

            _isActive = true;
        }

        private void TextChangedObj(object sender, EventArgs e)
        {
            if (!_isActive) return;
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

        private void BtnDelete(object sender, EventArgs e)
        {
            _obj.IsDeleted = true;
            this.Dispose();
        }

        private void BtnAddItem(object sender, EventArgs e)
        {
            var newItem = new ClassVariable() { Simple = true }; 
            var newInterface = new VariableInterface(newItem, true);
            VariablePanel.Controls.Add(newInterface);
            _obj.Parameters.Add(newItem);
        }
    }
}
