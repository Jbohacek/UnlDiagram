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
    public partial class VariableInterface : UserControl
    {
        //Vytvořit bool na load, jinak se to přehazuje !
        // přesat i na možnou variable
        private ClassVariable _classVar;

        public VariableInterface(ClassVariable classVar, bool isVariable = false)
        {
            _classVar = classVar;
            InitializeComponent();
            Element.FillAccessTypes(ref ComboAccess);
            Element.FillVariableTypes(ref ComboType);

            VariablesTypes classVarType = classVar.Type; // opravit
            string custom = classVar.Custom; // opravit
            AccessModifiers modifiers = classVar.Access;



            TextNameVariable.Text = _classVar.Name;

            ComboAccess.Text = modifiers.ToString().Substring(1); // Metoda


            if (classVarType == VariablesTypes.Custom)
            {
                ComboType.Text = custom;
            }
            else
            {
                ComboType.Text = classVarType.ToString().Substring(1);// opravit
            }

            if (isVariable == true) // opravit
            {
                ComboAccess.Visible = false;
            }

        }

        private void TextChangedObj(object sender, EventArgs e)
        {
            _classVar.Name = TextNameVariable.Text;
            if (!string.IsNullOrWhiteSpace(ComboAccess.Text))
            {
                _classVar.Access = (AccessModifiers)Enum.Parse(typeof(AccessModifiers), "_" + ComboAccess.Text, true); // Metoda
            }

            if (Enum.TryParse<VariablesTypes>("_" + ComboType.Text, out VariablesTypes a))
            {
                _classVar.Type = (VariablesTypes)Enum.Parse(typeof(VariablesTypes), "_" + ComboType.Text, true); // Metoda
            }
            else
            {
                _classVar.Type = VariablesTypes.Custom;
                _classVar.Custom = ComboType.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e) // opravit
        {
            _classVar.IsDeleted = true;
            this.Dispose();
        }
    }
}
