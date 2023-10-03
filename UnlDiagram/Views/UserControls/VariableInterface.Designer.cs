namespace UnlDiagram.Views.UserControls
{
    partial class VariableInterface
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextNameVariable = new TextBox();
            ComboAccess = new ComboBox();
            ComboType = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // TextNameVariable
            // 
            TextNameVariable.Location = new Point(3, 3);
            TextNameVariable.Name = "TextNameVariable";
            TextNameVariable.Size = new Size(234, 23);
            TextNameVariable.TabIndex = 0;
            TextNameVariable.TextChanged += TextChangedObj;
            // 
            // ComboAccess
            // 
            ComboAccess.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboAccess.FormattingEnabled = true;
            ComboAccess.Location = new Point(3, 32);
            ComboAccess.Name = "ComboAccess";
            ComboAccess.Size = new Size(110, 23);
            ComboAccess.TabIndex = 1;
            ComboAccess.SelectedValueChanged += TextChangedObj;
            ComboAccess.TextChanged += TextChangedObj;
            // 
            // ComboType
            // 
            ComboType.FormattingEnabled = true;
            ComboType.Location = new Point(119, 32);
            ComboType.Name = "ComboType";
            ComboType.Size = new Size(116, 23);
            ComboType.TabIndex = 2;
            ComboType.TextChanged += TextChangedObj;
            // 
            // button1
            // 
            button1.Location = new Point(160, 56);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Remove";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnDelete;
            // 
            // VariableInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(button1);
            Controls.Add(ComboType);
            Controls.Add(ComboAccess);
            Controls.Add(TextNameVariable);
            Name = "VariableInterface";
            Size = new Size(245, 80);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextNameVariable;
        private ComboBox ComboAccess;
        private ComboBox ComboType;
        private Button button1;
    }
}
