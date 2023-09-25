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
using UnlDiagram.Models.Elements;
using UnlDiagram.Models.Parameters;
using UnlDiagram.Views.UserControls;

namespace UnlDiagram.Views
{
    public partial class EditForm : Form
    {
        public ClassElement Ele;

        public EditForm(ClassElement ele)
        {
            Ele = ele;
            InitializeComponent();
            TextNameClass.Text = ele.Name;
            foreach (var classVariable in ele.Variables)
            {
                PanelVaraibles.Controls.Add(new VariableInterface(classVariable));
            }
            foreach (var methodVariable in ele.Methods)
            {
                PanelMethods.Controls.Add(new MethodInterface(methodVariable));
            }
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Ele.Name = TextNameClass.Text;
            Ele.Variables.RemoveAll(x => x.IsDeleted);
            Ele.Methods.RemoveAll(x => x.IsDeleted);
        }

        private void AddVariable_Click(object sender, EventArgs e)
        {
            var variable = new ClassVariable();
            PanelVaraibles.Controls.Add(new VariableInterface(variable));
            Ele.Variables.Add(variable);
        }

        private void AddMethod_Click(object sender, EventArgs e)
        {
            var method = new MethodVariable();
            PanelMethods.Controls.Add(new MethodInterface(method));
            Ele.Methods.Add(method);
        }

        private void button1_Click(object sender, EventArgs e) // opravit
        {
            this.Close();
        }
    }
}
