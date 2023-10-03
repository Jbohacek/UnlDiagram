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
    public partial class VariableInterface : UserControl
    {
        public readonly ClassVariable ClassVar;
        public readonly bool IsActive = false;


        public VariableInterface(ClassVariable classVar, bool isVariable = false)
        {
            ClassVar = classVar;
            InitializeComponent();
            Helper.FillAccessTypes(ref ComboAccess);
            Helper.FillVariableTypes(ref ComboType);

            TextNameVariable.Text = ClassVar.Name;

            ComboAccess.Text = classVar.GetAccess();
            ComboType.Text = classVar.GetType();

            if (isVariable)
            {
                ComboAccess.Visible = false;
            }

            IsActive = true;
        }

        private void TextChangedObj(object sender, EventArgs e)
        {
            if(!IsActive) return;
            ClassVar.Name = TextNameVariable.Text;
            if (!string.IsNullOrWhiteSpace(ComboAccess.Text))
            {
                ClassVar.Access = (AccessModifiers)Enum.Parse(typeof(AccessModifiers), "_" + ComboAccess.Text, true); // Metoda
            }

            if (Enum.TryParse<VariablesTypes>("_" + ComboType.Text, out VariablesTypes a))
            {
                ClassVar.Type = (VariablesTypes)Enum.Parse(typeof(VariablesTypes), "_" + ComboType.Text, true); // Metoda
            }
            else
            {
                ClassVar.Type = VariablesTypes.Custom;
                ClassVar.Custom = ComboType.Text;
            }
        }

        private void BtnDelete(object sender, EventArgs e)
        {
            ClassVar.IsDeleted = true;
            this.Dispose();
        }
    }
}
