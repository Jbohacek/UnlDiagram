namespace UnlDiagram.Views
{
    partial class EditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            TextNameClass = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            PanelMethods = new FlowLayoutPanel();
            PanelVaraibles = new FlowLayoutPanel();
            AddVariable = new Button();
            AddMethod = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SansSerif", 23.9999962F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(183, 37);
            label1.TabIndex = 0;
            label1.Text = "ClassName";
            // 
            // TextNameClass
            // 
            TextNameClass.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            TextNameClass.Location = new Point(25, 49);
            TextNameClass.Name = "TextNameClass";
            TextNameClass.Size = new Size(390, 35);
            TextNameClass.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 110);
            label2.Name = "label2";
            label2.Size = new Size(95, 30);
            label2.TabIndex = 4;
            label2.Text = "Methods";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(343, 113);
            label3.Name = "label3";
            label3.Size = new Size(95, 30);
            label3.TabIndex = 5;
            label3.Text = "Variables";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(479, 405);
            button1.Name = "button1";
            button1.Size = new Size(134, 53);
            button1.TabIndex = 6;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PanelMethods
            // 
            PanelMethods.AutoScroll = true;
            PanelMethods.Location = new Point(12, 143);
            PanelMethods.Name = "PanelMethods";
            PanelMethods.Size = new Size(325, 315);
            PanelMethods.TabIndex = 7;
            // 
            // PanelVaraibles
            // 
            PanelVaraibles.AutoScroll = true;
            PanelVaraibles.Location = new Point(343, 143);
            PanelVaraibles.Name = "PanelVaraibles";
            PanelVaraibles.Size = new Size(270, 255);
            PanelVaraibles.TabIndex = 8;
            // 
            // AddVariable
            // 
            AddVariable.Location = new Point(538, 118);
            AddVariable.Name = "AddVariable";
            AddVariable.Size = new Size(75, 23);
            AddVariable.TabIndex = 9;
            AddVariable.Text = "+ Add";
            AddVariable.UseVisualStyleBackColor = true;
            AddVariable.Click += AddVariable_Click;
            // 
            // AddMethod
            // 
            AddMethod.Location = new Point(262, 117);
            AddMethod.Name = "AddMethod";
            AddMethod.Size = new Size(75, 23);
            AddMethod.TabIndex = 10;
            AddMethod.Text = "+ Add";
            AddMethod.UseVisualStyleBackColor = true;
            AddMethod.Click += AddMethod_Click;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 470);
            Controls.Add(AddMethod);
            Controls.Add(AddVariable);
            Controls.Add(PanelVaraibles);
            Controls.Add(PanelMethods);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextNameClass);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "EditForm";
            FormClosing += EditForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TextNameClass;
        private Label label2;
        private Label label3;
        private Button button1;
        private FlowLayoutPanel PanelMethods;
        private FlowLayoutPanel PanelVaraibles;
        private Button AddVariable;
        private Button AddMethod;
    }
}